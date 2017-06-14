using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Core
{
	public class PagedList<T> : List<T>, IPagedList<T>
	{


		public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
		{
			int total = source.Count();

			var totalPages = (int)Math.Ceiling((decimal)total / (decimal)pageSize);
			var currentPage = pageIndex != null ? (int)pageIndex : 1;
			var startPage = currentPage - 5;
			var endPage = currentPage + 4;
			if (startPage <= 0)
			{
				endPage -= (startPage - 1);
				startPage = 1;
			}
			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			TotalCount = total;
			PageIndex = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
			this.AddRange(source);


			this.PageSize = pageSize;
			this.PageIndex = pageIndex;
			this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
		}


		public PagedList(IList<T> source, int pageIndex, int pageSize)
		{
			TotalCount = source.Count();
			TotalPages = TotalCount / pageSize;

			if (TotalCount % pageSize > 0)
				TotalPages++;

			this.PageSize = pageSize;
			this.PageIndex = pageIndex;
			this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
		}

		/// <summary>
		/// for special collection 
		/// </summary>
		public PagedList(IList<T> source, int? pageIndex, int pageSize, int totalCount)
		{
			var totalPages = (int)Math.Ceiling((decimal)totalCount / (decimal)pageSize);
			var currentPage = pageIndex != null ? (int)pageIndex : 1;
			var startPage = currentPage - 5;
			var endPage = currentPage + 4;
			if (startPage <= 0)
			{
				endPage -= (startPage - 1);
				startPage = 1;
			}
			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			TotalCount = totalCount;
			PageIndex = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
			this.AddRange(source);
		}

		public PagedList(IEnumerable<T> source, int? pageIndex, int pageSize, int totalCount)
		{
			var totalPages = (int)Math.Ceiling((decimal)totalCount / (decimal)pageSize);
			var currentPage = pageIndex != null ? (int)pageIndex : 1;
			var startPage = currentPage - 5;
			var endPage = currentPage + 4;
			if (startPage <= 0)
			{
				endPage -= (startPage - 1);
				startPage = 1;
			}
			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			TotalCount = totalCount;
			PageIndex = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
			this.AddRange(source);
		}

		public string FilterJson { get; set; }

		public int PageIndex { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }
		public int TotalPages { get; private set; }
		public int StartPage { get; private set; }
		public int EndPage { get; private set; }
		
		public bool HasPreviousPage
		{
			get { return (PageIndex > 0); }
		}
		public bool HasNextPage
		{
			get { return (PageIndex + 1 < TotalPages); }
		}
	}
}
