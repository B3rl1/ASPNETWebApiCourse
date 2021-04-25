using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNETWebAPI_Course.Data.Models
{
	public class Publisher
	{
		public int Id { get; set; }
		public string Name { get; set; }

		//Navigation properties used for define relationship between models
		public List<Book> Books { get; set; }
	}
}
