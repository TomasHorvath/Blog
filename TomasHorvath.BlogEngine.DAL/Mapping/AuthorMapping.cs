using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.DAL.Mapping
{

	public class AuthorMapping : EntityTypeConfiguration<Author>
	{
		public AuthorMapping()
		{
			this.ToTable("Authors");
			this.Property(e => e.FirstName).IsRequired();
			this.Property(e => e.LastName).IsRequired();
			this.HasKey<string>(e => e.Id);

		}
	}
}
