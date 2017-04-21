using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.Domain
{

	public class Author : IdentityUser, IEntity<string>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		private ICollection<BlogPost> _blogPost;
		public virtual ICollection<BlogPost> BlogPost
		{
			get { return _blogPost ?? (_blogPost = new Collection<BlogPost>()); }
			protected set { _blogPost = value; }
		}

		private ICollection<Page> _pages;
		public virtual ICollection<Page> Pages
		{
			get { return _pages ?? (_pages = new Collection<Page>()); }
			protected set { _pages = value; }
		}

	}

}
