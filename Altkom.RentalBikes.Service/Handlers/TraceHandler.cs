using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Altkom.RentalBikes.Service.Handlers
{
    public class TraceHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"{request.Method}: {request.RequestUri}");

            var response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine($"{response.StatusCode} {response.ReasonPhrase}");

            return response;
        }
    }
}