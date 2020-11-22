using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DebtEasy.Controllers
{
	public class DebitoController : ControllerBase
	{
		private readonly ILogger<DebitoController> _logger;
		public DebitoController(ILogger<DebitoController> logger)
		{
			_logger = logger;
		}

		[HttpGet("cliente/{cpf}/debitos")]
		public IEnumerable<Debito> Get(string cpf)
		{
			Consultas consulta = new Consultas();
			return consulta.GetDebitos(cpf);
		}
	}
}
