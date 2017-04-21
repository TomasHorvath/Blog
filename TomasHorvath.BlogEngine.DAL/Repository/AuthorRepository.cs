using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.DAL.Repository
{

	public class AuthorRepository : EntityFrameworkRepositoryBase<Domain.Author, string>, Interfaces.IAuthorRepository
	{
		public AuthorRepository(IDataSession session) : base(session)
		{
		}
	}
}
