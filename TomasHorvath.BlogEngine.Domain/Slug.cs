using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.Domain
{
	public class Slug : IEntity<Guid>
	{
		public Slug()
		{
			Id = Guid.NewGuid();
		}
		public Guid Id { get; set; }
		public string Url { get; set; }
		public Guid EntityId { get; set; }
		public EntityType EntityType {get;set;}
	}
}
