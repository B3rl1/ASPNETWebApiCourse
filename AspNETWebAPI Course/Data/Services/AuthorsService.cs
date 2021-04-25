using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNETWebAPI_Course.Data.Models;
using AspNETWebAPI_Course.Data.ViewModels;

namespace AspNETWebAPI_Course.Data.Services
{
	public class AuthorsService
	{
		private AppDbContext _context;

		public AuthorsService(AppDbContext context)
		{
			_context = context;
		}

		public void AddAuthor(AuthorVM author) //Использование AuthorVM обусловлено тем, что в модели Author, есть поля,
											   //которые не нужны для добавления(Id).
		{
			var _author = new Author()
			{
				FullName = author.FullName
			};

			_context.Authors.Add(_author);
			_context.SaveChanges();
		}

		public AuthorWithBooksVM GetAuthor(int id)
		{
			var _author = _context.Authors.Where(n => n.Id == id).Select(n => new AuthorWithBooksVM()
			{
				FullName = n.FullName,
				BookTitles = n.Book_Authors.Select(n=>n.Book.Title).ToList()
			}).FirstOrDefault();

			return _author;
		}

		public void DeleteAuthor(int id)
		{
			var _author = _context.Authors.FirstOrDefault(a => a.Id == id);

			if (_author != null)
			{
				_context.Authors.Remove(_author);
				_context.SaveChanges();
			}
		}
	}
}
