using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.Domain
{
	public class BlogSettings : IEntity<Guid>
	{
		public BlogSettings()
		{
			Id = Guid.NewGuid();
		}
		public Guid Id { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }
		public string DataType { get; set; }
	}
}
