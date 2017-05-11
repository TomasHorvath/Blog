using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.BL.Interface
{
	public interface IBlogPostService
	{
		/// <summary>
		/// Create new blog post
		/// </summary>
		void AddBlogPost(Domain.BlogPost post, Domain.Slug url);
		/// <summary>
		/// Update BlogPost
		/// </summary>
		void UpdateBlogPost(Domain.BlogPost post, Domain.Slug url);

		/// <summary>
		/// Delete blog post
		/// </summary>
		void DeleteBlogPost(Guid Id);

		/// <summary>
		/// Return entity for paging
		/// </summary>
		IPagedList<Domain.DTO.BlogPost.BlogPostPreviewDto> GetByPage(int pageNumber, int pageSize, out int totalRowCount);

		/// <summary>
		/// Get Blog post by Id
		/// </summary>
		Domain.DTO.BlogPost.BlogPostDetailDTO GetById(Guid Id);

		/// <summary>
		/// Add Comment to blog post
		/// </summary>
		void AddComment(Guid BlogPostId, Domain.Comment comment);


	}
}
