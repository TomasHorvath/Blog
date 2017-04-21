using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;
using TomasHorvath.BlogEngine.Domain.DTO;

namespace TomasHorvath.BlogEngine.DAL.Interfaces
{


	public interface IPageRepository : IRepository<Domain.Page, Guid>
	{
		IEnumerable<Domain.DTO.MenuItemDto> GetMenu();
	}
}
