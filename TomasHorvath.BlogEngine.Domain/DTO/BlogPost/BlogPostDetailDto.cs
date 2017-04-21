using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Domain.DTO.BlogPost
{
	public class BlogPostDetailDTO
	{
		public string AuthorName { get; set; }
		public Guid Id { get; set; }
		public string Perex { get; set; }
		public string Headline { get; set; }
		public string Content { get; set; }
		public string Keyword { get; set; }
		public string Description { get; set; }
		public DateTime DateOfPublished { get; set; }
	}
}
