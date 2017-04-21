using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.BL.Infrastucture.Caching;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.BL.Services
{
	public class SlugService : Interface.ISlugService
	{

		#region Constants
		/// <summary>
		/// Key for caching
		/// </summary>
		/// <remarks>
		/// {0} : clanek ID
		/// </remarks>
		private const string URLRECORD_BY_ID_KEY = "BlogEngine.urlrecord.slug.{0}";
		/// <summary>
		/// Key pattern to clear cache
		/// </summary>
		private const string URLRECORD_PATTERN_KEY = "BlogEngine.urlrecord.";
		#endregion

		private readonly Core.IDataSession _dataSession;
		private readonly DAL.Interfaces.ISlugRepository _slugRepository;
		private readonly BL.Infrastucture.Caching.ICacheManager _cache;
		private readonly BL.Infrastucture.Logging.ILogingManager _log;

		public SlugService(
			Core.IDataSession session,
			DAL.Interfaces.ISlugRepository urls,
			BL.Infrastucture.Caching.ICacheManager cache,
			BL.Infrastucture.Logging.ILogingManager log
			)
		{
			_dataSession = session;
			_cache = cache;
			_log = log;
			_slugRepository = urls;
		}

		public Slug GetBySlug(string seoFriendlyName)
		{

			if (string.IsNullOrEmpty(seoFriendlyName))
				return null;

			string key = string.Format(URLRECORD_BY_ID_KEY, seoFriendlyName);

			return _cache.Get(key, () => _slugRepository.GetBySlug(seoFriendlyName));


		}

	}
}
