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

        // POST 
        /// <summary>
        /// Insere uma conta
        /// </summary>
        /// <param name="account"></param>/> 
        /// <returns>Uma nova conta criada</returns>
        /// <response code="201">Retorna que a conta foi criada</response>
        /// <response code="400">Se a conta não for criada</response>  
        [HttpPost]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            var response = _service.InsertAccount(account);
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
