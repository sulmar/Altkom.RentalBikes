using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Altkom.RentalBikes.Service.Controllers
{
    public class FilesController : ApiController
    {
        public async Task<IHttpActionResult> Post()
        {
            var provider = new MultipartMemoryStreamProvider();

            await this.Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName;

                var buffer = await file.ReadAsByteArrayAsync();

                File.WriteAllBytes(filename, buffer);
            }

            return Ok();
        }
    }
}
