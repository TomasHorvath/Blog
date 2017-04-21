using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.Domain
{

	public class Page : BaseEntity, IEntity<Guid>
	{
		public Page()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Headline { get; set; }
		public string Content { get; set; }
		public string Keyword { get; set; }
		public string Description { get; set; }
		public DateTime DateOfPublished { get; set; }
		public virtual Author Author { get; set; }
		public string AuthorId { get; set; }
		public bool IsContantPage { get; set; }
		public int DisplayOrder { get; set; }

	}
}
