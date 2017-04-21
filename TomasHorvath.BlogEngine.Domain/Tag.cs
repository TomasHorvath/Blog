using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.Domain
{
	public class Tag : IEntity<Guid>
	{
		public Tag()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id{ get; set; }
		public string TagName { get; set; }
		public virtual BlogPost BlogPost { get; set; }
		public Guid BlogPostId { get; set; }
	}
}
