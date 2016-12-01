using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWithUnitTests.Interfaces;
using WebApiWithUnitTests.Data;
using WebApiWithUnitTests.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Reflection;

namespace WebApiWithUnitTests.Ioc
{
    public class AppRegistration
    {
        public static IContainer Register()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JsonHelper>().As<IJsonHelper>().InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            return container;

        }
    }
}