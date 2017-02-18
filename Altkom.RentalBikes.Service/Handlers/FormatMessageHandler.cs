using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Altkom.RentalBikes.Service.Handlers
{
    public class FormatMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var parameters = request.GetQueryNameValuePairs();

            var keyvalue = parameters.FirstOrDefault(s => s.Key == "format");

            if (keyvalue.Value != null)
            {
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(keyvalue.Value, 1));
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}