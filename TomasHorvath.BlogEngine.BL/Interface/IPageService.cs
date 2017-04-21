using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.BL.Interface
{
	public interface IPageService
	{
		IEnumerable<Domain.DTO.MenuItemDto> GetMenu();
	}
}
