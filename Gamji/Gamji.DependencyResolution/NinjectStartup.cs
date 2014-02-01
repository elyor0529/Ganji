#region credits
// ***********************************************************************
// Assembly	: DemoApplication.DependencyResolution
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion
#region

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Gamji.DependencyResolution;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using System;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectStartup), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(NinjectStartup), "Stop")]

namespace Gamji.DependencyResolution
{
	#region



	#endregion

	public partial class NinjectStartup
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
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

			GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

			RegisterServices(kernel);
			return kernel;
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{

		}

		public class NinjectControllerFactory : DefaultControllerFactory
		{
			private readonly IKernel ninjectKernel;

			public NinjectControllerFactory(IKernel kernel)
			{
				ninjectKernel = kernel;
			}

			protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
			{
				return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
			}
		}
	}
}