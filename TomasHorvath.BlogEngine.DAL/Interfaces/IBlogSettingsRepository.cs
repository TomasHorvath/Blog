using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.DAL.Interfaces
{
	public interface IBlogSettingsRepository : IRepository<Domain.BlogSettings, Guid>
	{
		Domain.BlogSettings GetByKey(string key);
	}
}
