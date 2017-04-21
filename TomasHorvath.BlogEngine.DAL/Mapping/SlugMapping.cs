using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.DAL.Mapping
{
	public class SlugMapping : EntityTypeConfiguration<Slug>
	{
		public SlugMapping()
		{
			this.ToTable("Slugs");
			this.HasKey<Guid>(e => e.Id);
			this.Property(e => e.EntityId).IsRequired();
			this.Property(e => e.Url).IsRequired();
		}

	}
}
