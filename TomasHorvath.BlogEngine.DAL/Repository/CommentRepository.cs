using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.DAL.Repository
{
	public class CommentRepository : EntityFrameworkRepositoryBase<Domain.Comment, Guid>, Interfaces.ICommentRepository
	{
		public CommentRepository(IDataSession session) : base(session)
		{
		}
	}
}
