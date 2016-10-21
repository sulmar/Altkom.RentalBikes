using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Altkom.RentalBikes.Service.Handlers;
using Altkom.RentalBikes.Service.Formatters;
using Altkom.RentalBikes.Service.Filters;
using FluentValidation.WebApi;

namespace Altkom.RentalBikes.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new TraceHandler());
            config.MessageHandlers.Add(new SecretKeyHandler());

            config.Formatters.Add(new GoogleQrCodeFormatter());

            config.Filters.Add(new ExecutionTimeFilterAttribute());
            config.Filters.Add(new ValidationModelStateAttribute());

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
