using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Core
{
	/// <summary>
	/// Interface pro AutoMapper mapovani 
	/// </summary>
	public interface IMapping
	{
		void ConfigureMap(IMapperConfigurationExpression mapper);		
	}
}
