using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Frontend.App_Start
{
	public class AutoMapperConfig
	{
		/// <summary>
		/// Initialize automapper mapping 
		/// </summary>
		public static void CreateMapping(IContainer container)
		{
			Mapper.Initialize(mapper =>
			{
				foreach (var mapping in container.Resolve<IEnumerable<Core.IMapping>>())
				{
					mapping.ConfigureMap(mapper);
				}
			});

			Mapper.AssertConfigurationIsValid();
		}
	}
}
