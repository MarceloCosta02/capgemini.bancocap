using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {

        public OperationController() { }

        [HttpPost]
        public IActionResult MakeOperation()
        {
            return Ok();
        }              

        [HttpPost]
        public IActionResult MakeTransfer()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBalance()
        {
            return Ok();
        }
    }
}
