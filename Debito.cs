using System;
using System.Linq;

namespace DebtEasy
{
	public class Debito
	{
		public enum TipoJuros { SIMPLES, COMPOSTO }
		public class Parcela
		{
			public DateTime data_vencimento { get; set; }
			public double valor { get; set; }
			public Parcela (DateTime data_vencimento, double valor)
			{
				this.data_vencimento = data_vencimento;
				this.valor = valor;
			}
		}
		public double valor_original { get; set; }
		public DateTime vencimento_original { get; set; }
		protected int max_parcelas { get; set; }
		public int dias_atraso => DateTime.Now.Subtract(vencimento_original).Days;

		protected TipoJuros juros_tipo { get; set; }
		protected double juros_taxa_ad { get; set; }
		public double valor_juros
		{
			get
			{
				if (juros_tipo == TipoJuros.SIMPLES)
				{
					// Fórmula: Juros = capital * taxa * tempo
					return valor_original * (juros_taxa_ad * .01) * dias_atraso;
				}
				else
				{
					// Fórmula: Montante = capital * (1 + taxa) ^ tempo
					return valor_original * Math.Pow(1 + juros_taxa_ad * .01, dias_atraso);
				}
			}
		}
		public double valor_final => valor_original + valor_juros;
		public Parcela[] parcelas
		{
			get
			{
				// Determina que a primeira parcela será no dia seguinte ao cálculo
				DateTime data_primeira_parcela = DateTime.Now.AddDays(1);
				double valor_parcela = valor_final / max_parcelas;
				//Cria um vetor com a quantidade de parcelas pré-definida
				return new Parcela[max_parcelas]
					// Utilizando System.Linq, percorre o vetor configurando o vencimento de cada parcela com base na data da primeira
					.Select((item, parcela) => new Parcela(data_primeira_parcela.AddMonths(parcela), valor_parcela))
					.ToArray();
			}
		}
		protected double comissao { get; set; }
		public double valor_comissao => valor_final * comissao * .01;
		public Debito () { }
		public Debito (double valor_original, DateTime vencimento_original, int max_parcelas, TipoJuros juros_tipo, double juros_taxa_ad, double comissao)
		{
			this.valor_original = valor_original;
			this.vencimento_original = vencimento_original;
			this.max_parcelas = max_parcelas;
			this.juros_tipo = juros_tipo;
			this.juros_taxa_ad = juros_taxa_ad;
			this.comissao = comissao;
		}
	}
}
