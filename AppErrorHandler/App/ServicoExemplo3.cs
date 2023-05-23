using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppErrorHandler.App
{
    [ApiController]
    [Route("api/exemplo3")]
    public class ServicoExemplo3 : ControllerBase
    {
        private readonly ILogger<ServicoExemplo3> _logger;

        public ServicoExemplo3(ILogger<ServicoExemplo3> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Lógica do endpoint aqui
                
                throw new ApplicationException("Erro ocorreu durante o processamento do endpoint");
                // Ou você pode retornar um erro específico como BadRequest, NotFound, etc.
                // return BadRequest("Erro ocorreu durante o processamento do endpoint");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante o processamento do endpoint");
                // O filtro de exceção personalizado irá lidar com a exceção e retornar uma resposta de erro adequada

                throw;
            }
        }
    }
}
