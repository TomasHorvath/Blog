using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.DAL.Repository
{
	public class TagRepository : EntityFrameworkRepositoryBase<Domain.Tag, Guid>, Interfaces.ITagRepository
	{
		public TagRepository(IDataSession session) : base(session)
		{
		}
	}
}
