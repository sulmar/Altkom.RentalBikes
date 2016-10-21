using Altkom.RentalBikes.Interfaces;
using Altkom.RentalBikes.Models;
using Altkom.RentalBikes.Service.Controllers;
using Altkom.RentalBikes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Altkom.RentalBikes.Service.Controllers
{
    public class StationsController : BaseApiController<Station, IStationsService, int>
    {
        public StationsController()
            : base(new MockStationsService())
        {

        }

        //[HttpGet]
        //public IHttpActionResult Find(double latitude, double longitude)
        //{
        //    var location = new Location { Latitude = latitude, Longitude = longitude };
        //    return Ok(Service.Find(location));
        //}

        [HttpGet]
        [Route("api/stations")]
        public async Task<IHttpActionResult> Find(Location location)
        {
            var station = await Service.FindAsync(location);

            return Ok(station);
        }
    }
}
