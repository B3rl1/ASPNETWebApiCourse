using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNETWebAPI_Course.Data.Models;
using AspNETWebAPI_Course.Data.ViewModels;

namespace AspNETWebAPI_Course.Data.Services
{
	public class PublishersService
	{
		private AppDbContext _context;

		public PublishersService(AppDbContext context)
		{
			_context = context;
		}

		public void AddPublisher(PublisherVM publisher) //Использование AuthorVM обусловлено тем, что в модели Author, есть поля,
											   //которые не нужны для добавления(Id, DateAdded).
		{
			var _publisher = new Publisher()
			{
				Name = publisher.Name
			};

			_context.Publishers.Add(_publisher);
			_context.SaveChanges();
		}

		public PublisherWithBooksAndAuthors GetPublisher(int id)
		{
			var _publisher = _context.Publishers.Where(p => p.Id == id).Select(pub => new PublisherWithBooksAndAuthors()
			{
				Name = pub.Name,
				BookAuthors = pub.Books.Select(b => new BookAuthorVM()
				{
					BookName = b.Title,
					BookAuthors = b.Book_Authors.Select(n => n.Author.FullName).ToList()
				}).ToList()
			}).FirstOrDefault();

			return _publisher;
		}

		public void DeletePublisher(int id)
		{
			var _publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);

			if (_publisher != null)
			{
				_context.Publishers.Remove(_publisher);
				_context.SaveChanges();
			}
		}
	}
}
