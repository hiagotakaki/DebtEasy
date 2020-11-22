using System.Text.RegularExpressions;

namespace DebtEasy
{
	public class Cliente
	{
		public string cpf { get; set; }
		public string nome { get; set; }
		public string telefone { get; set; }
		public string email { get; set; }
		public Cliente (string cpf, string nome, string telefone, string email)
		{
			this.cpf = cpf;
			this.nome = nome;
			this.telefone = telefone;
			this.email = email;
		}
	}
}
