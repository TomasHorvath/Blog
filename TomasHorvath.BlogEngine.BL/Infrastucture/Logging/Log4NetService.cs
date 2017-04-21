using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.BL.Infrastucture.Logging
{
	public class LoggingService : ILogingManager
	{
		private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public void Debug(string message)
		{
			this.log.Debug(message);
		}

		public void Error(string message)
		{
			this.log.Error(message);
		}

		public void Fatal(string message)
		{
			this.log.Fatal(message);
		}

		public void Info(string message)
		{
			this.log.Info(message);
		}

		public void Warn(string message)
		{
			this.log.Warn(message);
		}
	}
}
