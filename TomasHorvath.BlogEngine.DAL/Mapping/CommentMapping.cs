using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.DAL.Mapping
{
	public class CommentMapping : EntityTypeConfiguration<Comment>
	{
		public CommentMapping()
		{
			this.ToTable("Comments");
			this.HasKey<Guid>(e => e.Id);
			this.Property(e => e.Content).HasMaxLength(500).IsRequired();
			HasRequired(e => e.BlogPost).WithMany(c => c.Comments).HasForeignKey(t => t.BlogPostId).WillCascadeOnDelete(false);
		}
	}
}
