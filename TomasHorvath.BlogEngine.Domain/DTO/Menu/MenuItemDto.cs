using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Domain.DTO
{
	public class MenuItemDto
	{
		public int DisplayOrder { get; set; }
		public string Url { get; set; }
		public string Name { get; set; }
	}
}
