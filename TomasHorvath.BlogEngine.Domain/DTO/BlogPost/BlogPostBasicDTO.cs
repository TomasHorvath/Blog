using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Domain.DTO.BlogPost
{
	public class BlogPostBasicDTO
	{
		public Guid Id { get; set; }
		public string Headline { get; set; }
	}
}
