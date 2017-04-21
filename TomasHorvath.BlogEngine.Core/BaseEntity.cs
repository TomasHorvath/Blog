using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Core
{
	public class BaseEntity
	{
		public byte[] RowVersion { get; set; }
		public DateTime DateOfCreated { get; set; }
		public DateTime DateOfChange { get; set; }
		
	}
}
