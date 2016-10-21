using Altkom.RentalBikes.Interfaces;
using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Altkom.RentalBikes.Service.Controllers
{
    public abstract class BaseApiController<TItem, TService, TKey> : ApiController
        where TService : IBaseService<TItem, TKey>
        where TItem : Base
    {
        protected readonly TService Service;

        public BaseApiController(TService service)
        {
            this.Service = service;
        }

        
        public virtual IList<TItem> Get()
        {
            return Service.Get();
        }


        public virtual IHttpActionResult Get(TKey id)
        {
            var item = Service.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        public virtual IHttpActionResult Post(TItem item)
        {
            Service.Add(item);

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        [Route("api/{controller}/{id}")]
        public virtual IHttpActionResult Put(TKey id, TItem item)
        {
            var foundItem = Service.Get(id);

            if (foundItem == null)
                return NotFound();

            Service.Update(item);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [Route("api/{controller}/{id}")]
        public virtual IHttpActionResult Patch(TKey id, TItem item)
        {
            // TODO: czesciowa modyfikacja

            return StatusCode(HttpStatusCode.Accepted); 
        }

        public virtual IHttpActionResult Delete(TKey id)
        {
            var item = Service.Get(id);

            if (item == null)
                return NotFound();

            Service.Delete(id);

            return Ok();
        }


    }
}
