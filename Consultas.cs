using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DebtEasy
{
	public class Consultas
	{
		private Data.MockDados Database { get; set; }
		public Consultas()
		{
			using (StreamReader file = new StreamReader("Data/MockDados.json"))
			{
				Database = JsonSerializer.Deserialize<Data.MockDados>(file.ReadToEnd());
			}
		}
		public Cliente GetCliente(string cpf)
		{
			return Database.clientes
				.Where(cliente => cliente.cpf == cpf)
				.Select(cliente => new Cliente(cliente.cpf, cliente.nome, cliente.telefone, cliente.email))
				.ElementAtOrDefault(0);
		}

		public DebitoInfo[] GetDebitos(string cpf)
		{
			string id = Database.clientes
				.Where(cliente => cliente.cpf == cpf)
				.Select(cliente => cliente.id)
				.ElementAtOrDefault(0);
			if (id == null)
			{
				return new DebitoInfo[] { };
			}
			return Database.debitos
				.Where(divida => divida.clientes_id == id)
				.Select(divida => new DebitoInfo(
					divida.credor,
					divida.referencia,
					divida.contrato,
					Convert.ToDouble(divida.valor_original),
					Convert.ToDateTime(divida.vencimento_original),
					Convert.ToInt32(divida.max_parcelas),
					(Debito.TipoJuros)Convert.ToInt32(divida.juros_tipo),
					Convert.ToDouble(divida.juros_taxa_ad),
					Convert.ToDouble(divida.comissao)
				))
				.ToArray();
		}
	}
}
