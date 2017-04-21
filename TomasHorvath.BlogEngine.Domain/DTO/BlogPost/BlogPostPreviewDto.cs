using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Domain.DTO.BlogPost
{
	public class BlogPostPreviewDto
	{
		public string Author { get; set; }
		public string Headline { get; set; }
		public DateTime DateOfPublish { get; set; }
		public string Perex { get; set; }
		public string Url { get; set; }
	}
}
