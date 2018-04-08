using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using System.Text;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [HMACAuthentication]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/confidentials/{email}")]
        public bool confidentials(string email)
        {
            return true;
        }




    }


    




}
