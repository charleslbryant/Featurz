[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Featurz.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Featurz.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Featurz.Web.App_Start
{
	using System;
	using System.Web;
	using Archer.Core;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Archer.Core.Repository;
	using Archer.Infrastructure;
	using Archer.Infrastructure.Configuration;
	using Archer.Infrastructure.Data.MongoDb;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Extensions.Conventions;
	using Ninject.Web.Common;

	public static class NinjectWebCommon
	{
		public static readonly Bootstrapper Bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			Bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			Bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

			RegisterServices(kernel);
			return kernel;
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind(typeof(IConfiguration)).To(typeof(AppConfig));
			kernel.Bind(typeof(IQueryDispatcher)).To(typeof(QueryDispatcher));
			kernel.Bind(typeof(ICommandDispatcher)).To(typeof(CommandDispatcher));
			kernel.Bind(typeof(IReadRepository<>)).To(typeof(MongoReadRepository<>));
			kernel.Bind(typeof(IWriteRepository<>)).To(typeof(MongoWriteRepository<>));
			
			kernel.Bind(x => x
					.FromAssembliesMatching("Featurz.Application.dll")
					.SelectAllClasses().InheritedFrom(typeof(IQueryHandler<,,>))
					.BindAllInterfaces());

			kernel.Bind(x => x
					.FromAssembliesMatching("Featurz.Application.dll")
					.SelectAllClasses().InheritedFrom(typeof(ICommandHandler<,,>))
					.BindAllInterfaces());
		}
	}
}
