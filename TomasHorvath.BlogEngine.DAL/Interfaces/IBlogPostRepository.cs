using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.DAL.Interfaces
{
	public interface IBlogPostRepository : IRepository<Domain.BlogPost, Guid>
	{
		IPagedList<Domain.DTO.BlogPostPreviewDto> GetByPage(int pageNumber, int pageSize, out int totalRowCount);
		Domain.DTO.BlogPostDto GetDtoById(Guid id);
	}
}
