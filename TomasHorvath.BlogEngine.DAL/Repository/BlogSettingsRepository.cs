using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.DAL.Repository
{
	public class BlogSettingsRepository : EntityFrameworkRepositoryBase<Domain.BlogSettings, Guid>, Interfaces.IBlogSettingsRepository
	{
		public BlogSettingsRepository(IDataSession session) : base(session)
		{
		}

		public BlogSettings GetByKey(string key)
		{
		  return	_dataSession.Set<Domain.BlogSettings>().Where(e => e.Key == key).FirstOrDefault();
		}
	}
}
