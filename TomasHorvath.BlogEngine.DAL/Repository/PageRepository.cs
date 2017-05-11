using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;
using TomasHorvath.BlogEngine.Domain.DTO;

namespace TomasHorvath.BlogEngine.DAL.Repository
{
	public class PageRepository : EntityFrameworkRepositoryBase<Domain.Page, Guid>, Interfaces.IPageRepository
	{
		public PageRepository(IDataSession session) : base(session)
		{
		}

		public IEnumerable<Domain.DTO.BlogPost.BlogPostPreviewDto> GetByPage(int PageSize, int PageNumber, out int totalRowCount)
		{
			totalRowCount = _dataSession.Set<Domain.BlogPost>().Count();

			var query =
				from post in _dataSession.Set<Domain.BlogPost>()
				.OrderByDescending(e => e.DateOfPublished)
				.Skip((PageNumber - 1) * PageSize)
				.Take(PageSize)
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

			return query.ToList();
		}

		public IEnumerable<MenuItemDto> GetMenu()
		{
			var query =
			from page in _dataSession.Set<Domain.Page>().OrderBy(e => e.DisplayOrder)
			join slug in _dataSession.Set<Domain.Slug>() on page.Id equals slug.EntityId
			select new Domain.DTO.MenuItemDto
			{
				Url = slug.Url,
				Name = page.Name,
				DisplayOrder = page.DisplayOrder
			};

			return query.ToList();
		}
	}
}
