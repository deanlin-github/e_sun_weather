using Autofac;
using Autofac.Integration.Mvc;
using e_sun_weather.Application.Command.OpenWeatherDataCommand;
using e_sun_weather.Application.Predicition;
using e_sun_weather.Controllers;
using e_sun_weather.DomainModel.Repository;
using e_sun_weather.DomainModel.Repository.OpenWeather;
using e_sun_weather.Infra.Core.Componets.HttpClientTool;
using e_sun_weather.Infra.Core.Model.Response.OpenWeather;
using e_sun_weather.Infra.Data.Repositories;
using e_sun_weather.Infra.Data.Repositories.OpenWeather;
using MediatR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace e_sun_weather
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Register Autofac
            AutofacRegistration();
        }

        public static void AutofacRegistration()
        {
            var builder = new ContainerBuilder();
            // Controller
            builder.RegisterControllers(typeof(HomeController).Assembly);

            //此段落依據個人需求增減
            var applicationAssemblies = System.Reflection.Assembly.GetExecutingAssembly().
                                       GetReferencedAssemblies().
                                       Where(w => w.FullName.StartsWith("e_sun_weather.Application")).
                                       Select(a => System.Reflection.Assembly.Load(a)).
                                       Union(new List<System.Reflection.Assembly>() { System.Reflection.Assembly.GetExecutingAssembly() }).ToArray();

            builder.RegisterAssemblyTypes(applicationAssemblies)
                    .Where(t => t.Name.EndsWith("App"))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterType<InfraHttpClient>().As<InfraHttpClient>();

            var master = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
            var slave = ConfigurationManager.ConnectionStrings["MSSQLRead"].ConnectionString;

            builder.RegisterType<DapperContext>().As<IDapperContext>()
                .WithParameter("masterConn", new SqlConnection(master))
                .WithParameter("slaveConn", new SqlConnection(slave));

            builder.RegisterType<OpenWeatherPredictionRecordRepository>()
                .WithParameter("MSSqlConStr", master)
                .As<IOpenWeatherPredictionRecordRepository>();

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterType<GetPrediction36HoursCommandHandler>()
            .As<IRequestHandler<GetPrediction36HoursCommand, WeatherPrediction>>();            

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
