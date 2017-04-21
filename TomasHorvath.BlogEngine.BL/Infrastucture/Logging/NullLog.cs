using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.BL.Infrastucture.Logging
{
	/// <summary>
	/// Just Fake class for unit testing
	/// </summary>
	public class NullLog : ILogingManager
	{
		public void Debug(string message)
		{
			
		}

		public void Error(string message)
		{
			
		}

		public void Fatal(string message)
		{
			
		}

		public void Info(string message)
		{
			
		}

		public void Warn(string message)
		{
			
		}
	}
}
