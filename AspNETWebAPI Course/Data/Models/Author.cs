using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNETWebAPI_Course.Data.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string FullName { get; set; }

		//Navigations properties
		//Need to add Join Model for Many to many
		 public List<Book_Author> Book_Authors { get; set; }	
	}
}
