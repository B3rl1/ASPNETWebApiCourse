using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNETWebAPI_Course.Data.Services;
using AspNETWebAPI_Course.Data.ViewModels;

namespace AspNETWebAPI_Course.Controllers
{

	//Добавление API Endpoint
	//1 ADd service
	//2 Configure service
	//3 Add API Endpoint
	//4 Test API

	//По стандарту Controller не имеют Api Endpoint
	[Route("api/[controller]")]
	[ApiController]//Указывает что это APIController
	public class BooksController : ControllerBase
	{
		private BooksService _booksService;

		public BooksController(BooksService booksService)
		{
			_booksService = booksService;
		}

		[HttpGet("get-all-books")]
		public IActionResult GetAllBooks()
		{
			var books = _booksService.GetAllBooks();
			return Ok(books);
		}

		[HttpGet("get-book/{id}")]
		public IActionResult GetBook(int id)
		{
			var book = _booksService.GetBook(id);
			return Ok(book);
		}

		//Создаём первый EndPoint
		[HttpPost("add-book-with-authors")]
		public IActionResult AddBook([FromBody] BookVM book)
		{
			_booksService.AddBookWithAuthors(book);
			return Ok();
		}

		[HttpPut("update-book/{id}")]
		public IActionResult UpdateBook(int id, [FromBody] BookVM book)
		{
			var updatedBook = _booksService.UpdateBook(id, book);
			return Ok(updatedBook);
		}

		[HttpDelete("delete-book/{id}")]
		public IActionResult DeleteBook(int id)
		{
			_booksService.DeleteBook(id);
			return Ok();
		}
	}
}
