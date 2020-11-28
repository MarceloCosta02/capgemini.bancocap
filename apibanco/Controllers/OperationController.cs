using apibanco.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost("MakeOperation")]
        public IActionResult MakeOperation()
        {
            return Ok();
        }

        [HttpPost("MakeTransfer")]
        public IActionResult MakeTransfer()
        {
            return Ok();
        }
    }
}
