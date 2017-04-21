using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Core
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}

}
