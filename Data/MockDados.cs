using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtEasy.Data
{
	public class MockDados
	{
		public class cliente
		{
			public string id { get; set; }
			public string cpf { get; set; }
			public string nome { get; set; }
			public string telefone { get; set; }
			public string email { get; set; }
		}
		public class debito
		{
			public string id { get; set; }
			public string clientes_id { get; set; }
			public string credor { get; set; }
			public string referencia { get; set; }
			public string contrato { get; set; }
			public string vencimento_original { get; set; }
			public string valor_original { get; set; }
			public string max_parcelas { get; set; }
			public string juros_tipo { get; set; }
			public string juros_taxa_ad { get; set; }
			public string comissao { get; set; }
		}
		public cliente[] clientes { get; set; }
		public debito[] debitos { get; set; }
	}
}
