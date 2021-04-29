using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AspNETWebAPI_Course.Data.Models;
using AspNETWebAPI_Course.Data.ViewModels;
using AspNETWebAPI_Course.Exceptions;

namespace AspNETWebAPI_Course.Data.Services
{
	public class PublishersService
	{
		private AppDbContext _context;

		public PublishersService(AppDbContext context)
		{
			_context = context;
		}

		public Publisher AddPublisher(PublisherVM publisher) //Использование AuthorVM обусловлено тем, что в модели Author, есть поля,
											   //которые не нужны для добавления(Id, DateAdded).
		{
			if (StringStartsWithNumber(publisher.Name))
				throw new PublisherNameException("Name starts with number", publisher.Name);

			var _publisher = new Publisher()
			{
				Name = publisher.Name
			};

			_context.Publishers.Add(_publisher);
			_context.SaveChanges();

			return _publisher;
		}

		public Publisher GetPublisher(int id) => _context.Publishers.FirstOrDefault(p => p.Id == id);

		public PublisherWithBooksAndAuthors GetPublisherData(int id)
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
			else
			{
				throw new Exception($"The publisher with id {id} does not exist");
			} 
		}

		private bool StringStartsWithNumber(string name) => Regex.IsMatch(name, @"^\d");
	}
}
