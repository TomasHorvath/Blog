using Autofac;
using AutoMapper;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.BL
{
    public class Bootstrap
    {
		public static void Start()
		{
			
			// provede konfiguraci log4net 
			XmlConfigurator.Configure();
		}

	}
}
