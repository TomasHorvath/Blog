using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.DAL.Mapping
{

	public class TagMapping : EntityTypeConfiguration<Tag>
	{
		public TagMapping()
		{
			this.ToTable("Tags");
			this.HasKey<Guid>(e => e.Id);
			this.Property(e => e.TagName).HasMaxLength(100).IsRequired();
			HasRequired(e => e.BlogPost).WithMany(c => c.Tags).HasForeignKey(t => t.BlogPostId).WillCascadeOnDelete(false);
		}
	}
}
