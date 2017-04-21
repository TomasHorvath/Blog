using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.Domain
{
	public class Comment : IEntity<Guid>
	{
		public Comment()
		{
			Id = Guid.NewGuid();
		}
		public Guid Id { get; set; }
		public DateTime DateOfCreated;
		public string Content { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public bool IsPublished { get; set; }
		public virtual BlogPost BlogPost { get; set; }
		public Guid BlogPostId { get; set; }
	}
}
