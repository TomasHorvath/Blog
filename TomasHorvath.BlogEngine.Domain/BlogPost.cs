using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.Domain
{
	public class BlogPost : BaseEntity , IEntity<Guid>
	{
		public BlogPost()
		{
			Id = Guid.NewGuid();		
		}

		public Guid Id{ get; set; }
		public string	Perex { get; set; }
		public string Headline { get; set; }
		public string Content { get; set; }
		public string Keyword { get; set; }
		public string Description { get; set; }
		public DateTime DateOfPublished { get; set; }
		public virtual Author Author { get; set; }
		public string AuthorId { get; set; }

		private ICollection<Comment> _comments;
		public virtual ICollection<Comment> Comments
		{
			get { return _comments ?? (_comments = new Collection<Comment>()); }
			protected set { _comments = value; }
		}

		private ICollection<Tag> _tag;
		public virtual ICollection<Tag> Tags
		{
			get { return _tag ?? (_tag = new Collection<Tag>()); }
			protected set { _tag = value; }
		}


	}
}
