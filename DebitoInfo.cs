using System;

namespace DebtEasy
{
	public class DebitoInfo : Debito
	{
		public string credor { get; set; }
		public string referencia { get; set; }
		public string contrato { get; set; }
		public DebitoInfo() { }
		public DebitoInfo(string credor, string referencia, string contrato, double valor_original, DateTime vencimento_original, int max_parcelas, TipoJuros juros_tipo, double juros_taxa_ad, double comissao)
		{
			this.credor = credor;
			this.referencia = referencia;
			this.contrato = contrato;
			this.valor_original = valor_original;
			this.vencimento_original = vencimento_original;
			this.max_parcelas = max_parcelas;
			this.juros_tipo = juros_tipo;
			this.juros_taxa_ad = juros_taxa_ad;
			this.comissao = comissao;
		}
	}
}
