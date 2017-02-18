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
using Microsoft.Practices.Unity;
using Altkom.RentalBikes.Interfaces;
using Altkom.RentalBikes.Services;
using System.Web.Http.ExceptionHandling;
using Altkom.RentalBikes.Service.Exceptions;

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
            //   config.MessageHandlers.Add(new SecretKeyHandler());
            config.MessageHandlers.Add(new FormatMessageHandler());
            config.MessageHandlers.Add(new CustomHeaderHandler());
            config.MessageHandlers.Add(new MethodOverrideHandler());

            config.Formatters.Add(new GoogleQrCodeFormatter());

            config.Filters.Add(new ExecutionTimeFilterAttribute());
            config.Filters.Add(new ValidationModelStateAttribute());

            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            // Przykład wstrzykiwania zależności (Dependency Injection)
            var container = new UnityContainer();
            container.RegisterType<IBikesService, MockBikesService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStationsService, MockStationsService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsersService, MockUsersService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRentalsService, MockRentalsService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);



            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
