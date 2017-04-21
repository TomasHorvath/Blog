using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.BL.Infrastucture.Caching;
using TomasHorvath.BlogEngine.Domain.DTO;

namespace TomasHorvath.BlogEngine.BL.Services
{
	public class PageService : Interface.IPageService
	{

		#region Cache Constants
		/// <summary>
		/// Key for caching
		/// </summary>
		/// <remarks>
		/// {0} : clanek ID
		/// </remarks>
		private const string PAGE_BY_ID_KEY = "BlogEngine.page.id-{0}";
		/// <summary>
		/// Key pattern to clear cache
		/// </summary>
		private const string PAGE_PATTERN_KEY = "BlogEngine.page.";
		#endregion

		private readonly Core.IDataSession _dataSession;
		private readonly DAL.Interfaces.IPageRepository _pageRepository;
		private readonly DAL.Interfaces.ISlugRepository _slugRepository;
		private readonly BL.Infrastucture.Caching.ICacheManager _cache;
		private readonly BL.Infrastucture.Logging.ILogingManager _log;

		public PageService(
			Core.IDataSession session,
			DAL.Interfaces.IPageRepository pages,
			DAL.Interfaces.ISlugRepository urls,
			BL.Infrastucture.Caching.ICacheManager cache,
			BL.Infrastucture.Logging.ILogingManager log
			)
		{
			_dataSession = session;
			_cache = cache;
			_log = log;
			_pageRepository = pages;
			_slugRepository = urls;
		}

		public IEnumerable<Domain.DTO.MenuItemDto> GetMenu()
		{
			return _pageRepository.GetMenu();
		}

		public Domain.Page GetById(Guid Id)
		{
			if (Id == Guid.Empty)
				throw new ArgumentNullException("neplatný objekt id");

			string key = string.Format(PAGE_BY_ID_KEY, Id);
			return _cache.Get(key, () => _pageRepository.GetById(Id));
		}

	}
}
