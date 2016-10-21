using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Altkom.RentalBikes.MicroService.Controllers
{
    public class UsersController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Hello");
        }

        public IHttpActionResult Get(int id)
        {
            return Ok($"Hello {id}");
        }
    }
}
