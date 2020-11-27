using apibanco.Interfaces.Service;
using apibanco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        /// <summary>
        /// Insere uma conta
        /// <param name="account"></param>        
        /// /// </summary>
        [HttpPost]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            _service.InsertAccount(account);
            return new ObjectResult(string.Empty) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
