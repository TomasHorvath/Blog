using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.BL.Infrastucture.Logging
{
	public interface ILogingManager
	{
		void Debug(string message);
		void Info(string message);
		void Warn(string message);
		void Error(string message);
		void Fatal(string message);
	}
}
