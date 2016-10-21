using Altkom.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Altkom.RentalBikes.Service.Formatters
{
    public class GoogleQrCodeFormatter : MediaTypeFormatter
    {
        private const string supportedMediaType = "image/png";

        public GoogleQrCodeFormatter()
        {
            SupportedMediaTypes.Add(
                new System.Net.Http.Headers.MediaTypeHeaderValue(supportedMediaType));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Bike);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var bike = value as Bike;

            var uri = $"https://chart.googleapis.com/chart?cht=qr&chs=200x200&chl={bike.Number}";

            using (var client = new WebClient())
            {
                var data = await client.DownloadDataTaskAsync(uri);

                await writeStream.WriteAsync(data, 0, data.Length);
            }

        }
    }
}