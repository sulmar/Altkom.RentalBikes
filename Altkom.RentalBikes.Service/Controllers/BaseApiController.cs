using Altkom.RentalBikes.Interfaces;
using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        
        public virtual async Task<IHttpActionResult> Get()
        {
            var items = await Service.GetAsync();

            return Ok(items);
        }


        public virtual async Task<IHttpActionResult> Get(TKey id)
        {
            var item = await Service.GetAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        public virtual async Task<IHttpActionResult> Post(TItem item)
        {
            await Service.AddAsync(item);

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        [Route("api/{controller}/{id}")]
        public virtual async Task<IHttpActionResult> Put(TKey id, TItem item)
        {
            var foundItem = await Service.GetAsync(id);

            if (foundItem == null)
                return NotFound();

            await Service.UpdateAsync(item);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [Route("api/{controller}/{id}")]
        public virtual IHttpActionResult Patch(TKey id, TItem item)
        {
            // TODO: czesciowa modyfikacja

            return StatusCode(HttpStatusCode.Accepted); 
        }

        public virtual async Task<IHttpActionResult> Delete(TKey id)
        {
            var item = await Service.GetAsync(id);

            if (item == null)
                return NotFound();

            await Service.DeleteAsync(id);

            return Ok();
        }


    }
}
