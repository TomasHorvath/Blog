using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.BL.Infrastucture.Caching
{
	/// <summary>
	/// Cache manager interface
	/// </summary>
	public interface ICacheManager : IDisposable
	{
		/// <summary>
		/// Gets or sets the value associated with the specified key.
		/// </summary>
		T Get<T>(string key);

		/// <summary>
		/// Adds the specified key and object to the cache.
		/// </summary>
		void Set(string key, object data, int cacheTime);

		/// <summary>
		/// Gets a value indicating whether the value associated with the specified key is cached
		/// </summary>
		bool IsSet(string key);

		/// <summary>
		/// Removes the value with the specified key from the cache
		/// </summary>
		void Remove(string key);

		/// <summary>
		/// Removes items by pattern
		/// </summary>
		void RemoveByPattern(string pattern);

		/// <summary>
		/// Clear all cache data
		/// </summary>
		void Clear();
	}
}
