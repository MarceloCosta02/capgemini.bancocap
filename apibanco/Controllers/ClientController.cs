using apibanco.Interfaces.Service;
using apibanco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // POST 
        /// <summary>
        /// Insere clientes no banco
        /// </summary>
        /// <param name="client"></param>/> 
        /// <returns>Um novo cliente criado</returns>
        /// <response code="201">Retorna que o cliente foi criado</response>
        /// <response code="400">Se o cliente não for criado</response>  
        [HttpPost]
        public IActionResult CreateClient([FromBody] Client client)
        {
            _service.InsertClient(client);
            return new ObjectResult("Cliente cadastrado com sucesso.") { StatusCode = StatusCodes.Status201Created };
        }
    }
}
