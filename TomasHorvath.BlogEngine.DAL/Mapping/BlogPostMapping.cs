using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.DAL.Mapping
{
	public class BlogPostMapping : EntityTypeConfiguration<BlogPost>
	{
		public BlogPostMapping()
		{
			this.ToTable("BlogPosts");
			this.HasKey<Guid>(e => e.Id);
			this.HasRequired<Author>(s => s.Author).WithMany(s => s.BlogPost).HasForeignKey(e=>e.AuthorId);
			this.Property(e => e.Keyword).HasMaxLength(300);
			this.Property(e => e.Description).HasMaxLength(300);
			this.Property(e => e.Headline).HasMaxLength(200);
			this.Property(e => e.Perex).HasMaxLength(255);
			this.Property(e => e.Content).IsRequired();
			this.Property(e => e.RowVersion).IsRowVersion();

		}
	}
}
