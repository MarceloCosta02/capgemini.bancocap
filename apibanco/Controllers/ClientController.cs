using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apibanco.Interfaces.Service;
using apibanco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apibanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Inserindo Cliente no banco
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateClient([FromBody] Client client)
        {
            _service.InsertClient(client);
            return new ObjectResult("Cliente cadastrado com sucesso.") { StatusCode = StatusCodes.Status201Created };
        }
    }
}
