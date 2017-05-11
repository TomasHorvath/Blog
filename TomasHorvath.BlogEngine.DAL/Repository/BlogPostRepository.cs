using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.DAL.Repository
{
	public class BlogPostRepository : EntityFrameworkRepositoryBase<Domain.BlogPost, Guid>, Interfaces.IBlogPostRepository
	{
		public BlogPostRepository(IDataSession session) : base(session)
		{
		}

		public Domain.DTO.BlogPost.BlogPostDetailDTO GetDtoById(Guid id)
		{
			var query =
				from post in _dataSession.Set<Domain.BlogPost>()
				.Where(e => e.Id == id)
				join author in _dataSession.Set<Domain.Author>() on post.AuthorId equals author.Id
				select new Domain.DTO.BlogPost.BlogPostDetailDTO()
				{
					AuthorName = author.FirstName + " " + author.LastName,
					DateOfPublished = post.DateOfPublished,
					Headline = post.Headline,
					Perex = post.Perex,
					Keyword = post.Keyword,
					Id = post.Id,
					Description = post.Description,
					Content = post.Content
				};

			return query.FirstOrDefault();
		}

		public IPagedList<Domain.DTO.BlogPost.BlogPostPreviewDto> GetByPage(int PageSize, int PageNumber, out int totalRowCount)
		{
			totalRowCount = _dataSession.Set<Domain.BlogPost>().Count();

			var query =
				from post in _dataSession.Set<Domain.BlogPost>()
				.OrderByDescending(e=>e.DateOfPublished)
				join author in _dataSession.Set<Domain.Author>() on post.AuthorId equals author.Id
				join slug in _dataSession.Set<Domain.Slug>() on post.Id equals slug.EntityId
				select new Domain.DTO.BlogPost.BlogPostPreviewDto()
				{
					 Author = author.FirstName + " " + author.LastName,
					 DateOfPublish = post.DateOfPublished,
					 Headline = post.Headline,
					 Perex = post.Perex,
					 Url = slug.Url
				};
			query = query.OrderByDescending(e => e.DateOfPublish);

			return  new PagedList<Domain.DTO.BlogPost.BlogPostPreviewDto>(query, PageNumber, PageSize);

		}
	}
}
