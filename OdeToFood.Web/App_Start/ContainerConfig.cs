using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OdeToFood.Data.Services;
using System.Web.Mvc;
using OdeToFood.Web.Controllers;
using Autofac.Integration.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        public static ContainerBuilder RegisterControllers { get; private set; }

        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryRestaurantData>()
                    .As<IRestaurantData>()
                    .SingleInstance();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}