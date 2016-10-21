using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Altkom.RentalBikes.Service.Handlers
{
    public class SecretKeyHandler : DelegatingHandler
    {
        private const string _headerKey = "Secret-Key";
        private const string _secretKey = "12345";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (IsValid(request))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

                return response;
            }
           

        }

        public bool IsValid(HttpRequestMessage request)
        {
            bool result = false;

            IEnumerable<string> secretKeys;

            if (request.Headers.TryGetValues(_headerKey, out secretKeys))
            {
                var secretKey = secretKeys.First();

                result = IsValidSecretKey(secretKey);
            }

            return result;

        }

        private bool IsValidSecretKey(string secretKey)
        {
            return secretKey == _secretKey;
        }
    }
}