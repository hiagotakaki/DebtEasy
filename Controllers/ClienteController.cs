using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DebtEasy.Controllers
{
	public class ClienteController : ControllerBase
	{
		private readonly ILogger<ClienteController> _logger;
		public ClienteController(ILogger<ClienteController> logger)
		{
			_logger = logger;
		}

		[HttpGet("cliente/{cpf}")]
		public Cliente Get(string cpf)
		{
			Consultas consulta = new Consultas();
			Cliente cliente = consulta.GetCliente(cpf);
			if (cliente == null)
			{
				Response.StatusCode = 404;
			}
			return cliente;
		}
	}
}
