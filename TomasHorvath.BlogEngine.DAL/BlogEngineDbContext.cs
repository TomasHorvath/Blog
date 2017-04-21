using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Domain;
using System.Data.Entity;

namespace TomasHorvath.BlogEngine.DAL
{
	public class BlogEngineDbContext : IdentityDbContext<Author>
	{

		public BlogEngineDbContext(): base("name=eshop")
		{
			//Database.SetInitializer(new ApplicationDbInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new Mapping.AuthorMapping());
			modelBuilder.Configurations.Add(new Mapping.BlogPostMapping());
			modelBuilder.Configurations.Add(new Mapping.CommentMapping());
			modelBuilder.Configurations.Add(new Mapping.TagMapping());
			modelBuilder.Configurations.Add(new Mapping.SlugMapping());
			modelBuilder.Configurations.Add(new Mapping.PageMapping());
			modelBuilder.Configurations.Add(new Mapping.BlogSettingsMapping());
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Comment> Comments { get; set; }
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<Page> Pages { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Slug> Slugs { get; set; }
		public DbSet<BlogSettings> Settings { get; set; }
	}
}
