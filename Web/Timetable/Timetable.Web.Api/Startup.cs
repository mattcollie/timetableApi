using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Timetable.Web.Api;
using Timetable.Web.Api.Common.Helpers;
using Timetable.Web.Api.Common.Interfaces.Repositories;
using Timetable.Web.Api.Common.Repositories;
using Timetable.Web.Api.Repository.Interfaces;
using Timetable.Web.Api.Repository.Repositories;
using Timetable.Data.Access.Context;
using Timetable.Data.Objects.Tables;
using Microsoft.Owin;
using Owin;
using System.Net.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace Timetable.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<FixContentTypeHeader>();

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterServices(builder);

            IContainer container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Map the help path and force next to be invoked
            app.Map("/Help", appbuilder => appbuilder.UseHandlerAsync((request, response, next) => next()));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            app.UseAutofacWebApi(GlobalConfiguration.Configuration);
            app.UseWebApi(GlobalConfiguration.Configuration);
        }
        
        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => HttpContext.Current).InstancePerRequest();
            builder.RegisterType<TimetableContext>().InstancePerRequest();
            builder.RegisterType<HttpClient>().InstancePerRequest();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TimeslotRepository>().As<ITimeslotRepository>().InstancePerLifetimeScope();
        }
    }
}