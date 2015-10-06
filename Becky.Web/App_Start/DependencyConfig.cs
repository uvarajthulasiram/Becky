using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Task;
using Becky.Web.Helpers;

namespace Becky.Web
{
    public class DependencyConfig
    {
        private static readonly Assembly TaskAssembly = typeof (TaskBase).Assembly;

        public static void Configure(ContainerBuilder builder)
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            builder.RegisterAssemblyTypes(typeof (ContextAdapter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterType<BeckyContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<ContextAdapter>().As<IObjectSetFactory, IObjectContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<MappingService>().As<IMappingService>().InstancePerRequest();
            builder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>)).InstancePerRequest();
            builder.RegisterAssemblyTypes(TaskAssembly)
                .Where(type => typeof (TaskBase).IsAssignableFrom(type) && !type.IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterControllers(assemblies);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}