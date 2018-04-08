using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AuthenticateController : ApiController
    {
        [HttpGet]
        [Route("api/authenticate/{email}/{password}")]
        public bool authenticate(string email, string password)
        {
            return true;
        }
    }
}
