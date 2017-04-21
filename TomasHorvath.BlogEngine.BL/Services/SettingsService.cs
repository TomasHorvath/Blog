using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.BL.Infrastucture.Caching;

namespace TomasHorvath.BlogEngine.BL.Services
{
	public class SettingsService : Interface.ISettingsService
	{
		#region Cache Constants
		/// <summary>
		/// Key for caching
		/// </summary>
		/// <remarks>
		/// {0} : nastaveni hodnota
		/// </remarks>
		private const string SETTING_BY_ID_KEY = "BlogEngine.settings.id-{0}";
		/// <summary>
		/// Key pattern to clear cache
		/// </summary>
		private const string SETTING_PATTERN_KEY = "BlogEngine.settings.";
		#endregion

		private readonly Core.IDataSession _dataSession;
		private readonly DAL.Interfaces.IBlogSettingsRepository _settingsRepository;
		private readonly BL.Infrastucture.Caching.ICacheManager _cache;
		private readonly BL.Infrastucture.Logging.ILogingManager _log;

		public SettingsService(
		Core.IDataSession session,
		DAL.Interfaces.IBlogSettingsRepository settings,
		BL.Infrastucture.Caching.ICacheManager cache,
		BL.Infrastucture.Logging.ILogingManager log
		)
		{
			_dataSession = session;
			_cache = cache;
			_log = log;
			_settingsRepository = settings;
		}

	

		public Domain.BlogSettings GetByKey(string key)
		{
			string cacheKey = string.Format(SETTING_BY_ID_KEY, key);
			return _cache.Get(cacheKey, () => _settingsRepository.GetByKey(key));
		}
	}
}
