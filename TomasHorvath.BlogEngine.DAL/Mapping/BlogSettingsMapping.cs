using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.DAL.Mapping
{

	public class BlogSettingsMapping : EntityTypeConfiguration<BlogEngine.Domain.BlogSettings>
	{
		public BlogSettingsMapping()
		{
			this.ToTable("BlogSetting");
			this.HasKey<Guid>(e => e.Id);
			this.Property(e => e.Key).HasMaxLength(150).IsRequired();
			this.Property(e => e.Value).HasMaxLength(300).IsRequired();
			this.Property(e => e.DataType).HasMaxLength(150);
	
		}
	}
}
