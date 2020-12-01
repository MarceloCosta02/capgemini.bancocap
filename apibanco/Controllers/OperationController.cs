using apibanco.DTO;
using apibanco.Interfaces.Service;
using apibanco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace apibanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _service;

        public OperationController(IOperationService service)
        {
            _service = service;
        }

        // GET
        /// <summary>
        /// Lista o resultado do consolidado das operações
        /// </summary>
        /// <param name="hash"></param>/>   
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Retorna o valor consolidado</response>
        /// <response code="400">Se ocorrer algum erro no hash informado</response>  
        [HttpGet]
        public IActionResult GetBalance([FromQuery] string hash)
        {
            try
            {
                var value = _service.GetByHash(hash);
                return new ObjectResult(value) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/MakeOperation
        /// <summary>
        /// Realiza a operação de deposito ou saque
        /// </summary>
        /// <param name="operation"></param>/>
        /// <param name="hash"></param>/>
        /// <remarks>
        /// Observação:       
        /// No campo Type são aceitos 'D' para operações de depósito e 'S' para operações de saque      
        /// </remarks> 
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpPost("MakeOperation")]
        public IActionResult MakeOperation([FromBody] Operation operation, [FromQuery] string hash)
        {
            try
            {
                _service.MakeOperations(operation, hash);
                return new ObjectResult("") { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/MakeTransfer
        /// <summary>
        /// Realiza a operação de transferência
        /// </summary>
        /// <param name="transfer"></param>/>   
        /// <returns>Transferência entre contas criada</returns>
        /// <response code="201">Retorna que a transferência foi criada</response>
        /// <response code="400">Se a transferência não for criada</response>  
        [HttpPost("MakeTransfer")]
        public IActionResult MakeTransfer([FromBody] Transfer transfer)
        {
            try
            {
                var response = _service.MakeTransfer(transfer);
                return new ObjectResult(response) { StatusCode = response.Status };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
