using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Core
{
	public interface IPagedList<T> : IList<T>
	{
		int PageIndex { get; }
		int PageSize { get; }
		int TotalCount { get; }
		int TotalPages { get; }
		bool HasPreviousPage { get; }
		bool HasNextPage { get; }
		int StartPage { get; }
		int EndPage { get; }
		string FilterJson { get; }
	}
}
