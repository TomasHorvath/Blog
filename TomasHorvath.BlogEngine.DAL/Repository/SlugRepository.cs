using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.DAL.Repository
{
	public class SlugRepository : EntityFrameworkRepositoryBase<Domain.Slug, Guid>, Interfaces.ISlugRepository
	{
		public SlugRepository(IDataSession session) : base(session)
		{
		}

		public Slug GetBySlug(string seoFriendlyName)
		{
			return _dataSession.Set<Slug>().Where(e => e.Url == seoFriendlyName).FirstOrDefault();
		}
	}
}
