using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TomasHorvath.BlogEngine.BL.Mapping
{
	public class BlogPostMapping : Core.IMapping
	{
		public void ConfigureMap(IMapperConfigurationExpression mapper)
		{
			mapper.CreateMap<Domain.BlogPost, Domain.DTO.BlogPost.BlogPostDetailDTO>()
				.ForMember(
					a => a.AuthorName,
					b => b.ResolveUsing(c => c.Author.FirstName + " " + c.Author.LastName));
		}
	}
}
