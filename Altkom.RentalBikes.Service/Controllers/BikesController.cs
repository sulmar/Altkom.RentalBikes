using Altkom.RentalBikes.Interfaces;
using Altkom.RentalBikes.Models;
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
    public class BikesController : ApiController
    {
        private readonly IBikesService BikesService = new MockBikesService();


        /// <summary>
        /// Pobierz rowery
        /// </summary>
        /// <returns></returns>
        public IList<Bike> Get()
        {
            return BikesService.GetBikes();
        }

        public Bike GetByNumber([FromUri] string number)
        {
            return BikesService.GetBike(number);
        }

        [Route("api/bikes/{bikeId:int}")]
        public IHttpActionResult Get(int bikeId)
        {
            var bike = BikesService.GetBike(bikeId);

            if (bike == null)
                return NotFound();

            return Ok(bike);
        }

        [Route("api/bikes/{number}")]
        public Bike Get(string number)
        {
            return BikesService.GetBike(number);
        }

        public IHttpActionResult Post(Bike bike)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            BikesService.AddBike(bike);

            return CreatedAtRoute("DefaultApi", new { id = bike.BikeId }, bike);
        }

        [Route("api/bikes/{id}")]
        public void Put(int id, Bike bike)
        {
            BikesService.UpdateBike(bike);
        }

        [Route("api/bikes/{id}")]
        public void Delete(int id)
        {
            BikesService.RemoveBike(id);
        }

        [HttpHead]
        [Route("api/bikes/{id}")]
        public IHttpActionResult Head(int id)
        {
            var bike = BikesService.GetBike(id);

            if (bike == null)
                return NotFound();
            else
                return Ok();

        }


        
    
    }
}
