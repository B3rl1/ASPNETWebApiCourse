using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AspNETWebAPI_Course.Data.ViewModels
{
	public class PublisherVM
	{
		public string Name { get; set; }
		
	}

	public class PublisherWithBooksAndAuthors
	{
		public string Name { get; set; }
		public List<BookAuthorVM> BookAuthors { get; set; }
	}

	public class BookAuthorVM
	{
		public string BookName { get; set; }
		public List<string> BookAuthors { get; set; }
	}
}
