using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Task;

namespace Becky.WebApi
{
    public class DependencyConfig
    {
        private static readonly Assembly TaskAssembly = typeof(TaskBase).Assembly;

        public static void Configure(ContainerBuilder builder)
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            builder.RegisterAssemblyTypes(typeof(ContextAdapter).Assembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<BeckyContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<ContextAdapter>().As<IObjectSetFactory, IObjectContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterAssemblyTypes(TaskAssembly).Where(type => typeof(TaskBase).IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            /*
            For MVC applications register all classes inherited from Controller class
            builder.RegisterControllers(assemblies);
            */

            builder.RegisterApiControllers(assemblies);

            var container = builder.Build();

            /*
            For MVC applications set dependency resolver with new AutofacDependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            */

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}