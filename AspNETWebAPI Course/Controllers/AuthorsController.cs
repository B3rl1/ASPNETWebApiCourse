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
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private AuthorsService _authorsService;

		public AuthorsController(AuthorsService authorsService)
		{
			_authorsService = authorsService;
		}

		[HttpPost("add-author")]
		public IActionResult AddAuthor([FromBody] AuthorVM book)
		{
			_authorsService.AddAuthor(book);
			return Ok();
		}

		[HttpGet("get-author/{id}")]
		public IActionResult GetAuthor(int id)
		{
			var _author = _authorsService.GetAuthor(id);
			return Ok(_author);
		}

		[HttpDelete("delete-author/{id}")]
		public IActionResult DelteAuthor(int id)
		{
			_authorsService.DeleteAuthor(id);
			return Ok();
		}
	}
}
