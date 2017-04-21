using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TomasHorvath.BlogEngine.Frontend.App_Start;
using TomasHorvath.BlogEngine.Frontend.ViewModels;

namespace TomasHorvath.BlogEngine.Frontend
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			BL.Bootstrap.Start();
			// Set up IoC
			var IoCcontainer = BuildContainer();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(IoCcontainer));
			
			AutoMapperConfig.CreateMapping(IoCcontainer);


			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			

		}


		/// <summary>
		/// Build container
		/// </summary>
		private IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			// logovani 
			builder.RegisterType<BL.Infrastucture.Logging.LoggingService>().As<BL.Infrastucture.Logging.ILogingManager>();
			builder.RegisterType<BL.Infrastucture.Caching.MemoryCacheManager>().As<BL.Infrastucture.Caching.ICacheManager>();
			builder.RegisterType<DAL.EntityDataSession>().As<Core.IDataSession>();
			builder.RegisterType<DAL.BlogEngineDbContext>().As<System.Data.Entity.DbContext>().InstancePerRequest();
	
			#region old 
			//// Services
			//builder.RegisterType<BL.Services.BlogPostService>().As<BL.Interface.IBlogPostService>();
			//builder.RegisterType<BL.Services.SlugService>().As<BL.Interface.ISlugService>();
			//builder.RegisterType<BL.Services.SettingsService>().As<BL.Interface.ISettingsService>();
			//builder.RegisterType<BL.Services.PageService>().As<BL.Interface.IPageService>();

			//// Repositories 
			//builder.RegisterType<DAL.Repository.BlogPostRepository>().As<DAL.Interfaces.IBlogPostRepository>();
			//builder.RegisterType<DAL.Repository.AuthorRepository>().As<DAL.Interfaces.IAuthorRepository>();
			//builder.RegisterType<DAL.Repository.CommentRepository>().As<DAL.Interfaces.ICommentRepository>();
			//builder.RegisterType<DAL.Repository.SlugRepository>().As<DAL.Interfaces.ISlugRepository>();
			//builder.RegisterType<DAL.Repository.BlogSettingsRepository>().As<DAL.Interfaces.IBlogSettingsRepository>();
			//builder.RegisterType<DAL.Repository.TagRepository>().As<DAL.Interfaces.ITagRepository>();
			//builder.RegisterType<DAL.Repository.PageRepository>().As<DAL.Interfaces.IPageRepository>();
			#endregion

			// Services 
			var assemblyServices = typeof(TomasHorvath.BlogEngine.BL.Bootstrap).Assembly;

			builder.RegisterAssemblyTypes(assemblyServices)
						 .Where(t => t.Name.EndsWith("Service"))
						 .AsImplementedInterfaces()
						 .InstancePerRequest();

			//// Repositories
			var assemblyDataAccess = typeof(TomasHorvath.BlogEngine.DAL.EntityDataSession).Assembly;

			builder.RegisterAssemblyTypes(assemblyDataAccess)
						 .Where(t => t.Name.EndsWith("Repository"))
						 .AsImplementedInterfaces()
						 .InstancePerRequest();

			//// AutoMapper Mapping

			builder.RegisterAssemblyTypes(assemblyServices)
				.Where(t => typeof(Core.IMapping).IsAssignableFrom(t))
				.InstancePerLifetimeScope()
				.AsImplementedInterfaces();

			return builder.Build();
		}
	}
}
