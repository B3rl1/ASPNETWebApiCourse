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
	public class PublishersController : ControllerBase
	{
		private PublishersService _publishersService;

		public PublishersController(PublishersService publishersService)
		{
			_publishersService = publishersService;
		}

		[HttpPost("add-publisher")]
		public IActionResult AddPublisher([FromBody] PublisherVM book)
		{
			_publishersService.AddPublisher(book);
			return Ok();
		}

		[HttpGet("get-publisher/{id}")]
		public IActionResult GetPublisher(int id)
		{
			var _publisher = _publishersService.GetPublisher(id);
			return Ok(_publisher);
		}

		[HttpDelete("delete-publisher/{id}")]
		public IActionResult DeletePublisher(int id)
		{
			_publishersService.DeletePublisher(id);
			return Ok();
		}
	}
}
