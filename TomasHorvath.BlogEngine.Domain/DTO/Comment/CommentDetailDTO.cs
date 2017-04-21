using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Domain.DTO
{
	public class CommentDetailDTO
	{
		public Guid BlogPostId { get; set; }
		public Guid Id { get; set; }
		public DateTime DateOfCreate { get; set; }
		public string Comment { get; set; } 
	}
}
