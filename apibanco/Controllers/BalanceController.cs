﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {

        public BalanceController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
