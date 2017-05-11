using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Domain;
using TomasHorvath.BlogEngine.DAL;
using TomasHorvath.BlogEngine.BL.Infrastucture.Caching;
using AutoMapper;

namespace TomasHorvath.BlogEngine.BL.Services
{
	public class BlogPostService : Interface.IBlogPostService
	{

		#region Cache Constants
		/// <summary>
		/// Key for caching
		/// </summary>
		/// <remarks>
		/// {0} : clanek ID
		/// </remarks>
		private const string BLOGPOST_BY_ID_KEY = "BlogEngine.post.id-{0}";
		/// <summary>
		/// Key pattern to clear cache
		/// </summary>
		private const string BLOGPOST_PATTERN_KEY = "BlogEngine.post.";
		#endregion

		private readonly Core.IDataSession _dataSession;
		private readonly DAL.Interfaces.IBlogPostRepository _blogpostRepository;
		private readonly DAL.Interfaces.ISlugRepository _slugRepository;
		private readonly DAL.Interfaces.ICommentRepository _comments;
		private readonly BL.Infrastucture.Caching.ICacheManager _cache;
		private readonly BL.Infrastucture.Logging.ILogingManager _log;

		public BlogPostService(
			Core.IDataSession session,
			DAL.Interfaces.IBlogPostRepository blogposts,
			DAL.Interfaces.ISlugRepository urls,
			DAL.Interfaces.ICommentRepository comments,
			BL.Infrastucture.Caching.ICacheManager cache,
			BL.Infrastucture.Logging.ILogingManager log
			)
		{
			_dataSession = session;
			_cache = cache;
			_log = log;
			_blogpostRepository = blogposts;
			_slugRepository = urls;
		}

		public void AddBlogPost(BlogPost post, Domain.Slug url)
		{
			if (post == null)
				throw new ArgumentNullException("neplatný objekt blogpost");

			try
			{
				url.EntityId = post.Id;

				_blogpostRepository.Insert(post);
				_slugRepository.Insert(url);
				_dataSession.Commit();

			}
			catch (Exception ex)
			{
				_log.Error(ex.Message);
				throw ex;
			}
		}

		public void DeleteBlogPost(Guid Id)
		{
			try
			{
				_blogpostRepository.Delete(Id);
				_dataSession.Commit();
			}
			catch (Exception ex)
			{
				_log.Error(ex.Message);
				throw ex;
			}
		}

		public Domain.DTO.BlogPost.BlogPostDetailDTO GetById(Guid Id)
		{
			if (Id == Guid.Empty)
				throw new ArgumentNullException("neplatný objekt id");

			string key = string.Format(BLOGPOST_BY_ID_KEY, Id);
			return _cache.Get(key, () => _blogpostRepository.GetDtoById(Id));
		}

		public void UpdateBlogPost(BlogPost post, Domain.Slug url)
		{
			try
			{
				_blogpostRepository.Update(post);
				_slugRepository.Update(url);
				_dataSession.Commit();
			}
			catch (Exception ex)
			{
				_log.Error(ex.Message);
				throw ex;
			}
		}

		public void AddComment(Guid BlogPostId, Comment comment)
		{
			throw new NotImplementedException();
		}

		public Core.IPagedList<Domain.DTO.BlogPost.BlogPostPreviewDto> GetByPage(int pageNumber, int pageSize, out int totalRowCount)
		{
			return _blogpostRepository.GetByPage(pageNumber, pageSize, out totalRowCount);
		}
	}
}
