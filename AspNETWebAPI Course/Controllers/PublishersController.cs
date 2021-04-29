using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNETWebAPI_Course.Data.Services;
using AspNETWebAPI_Course.Data.ViewModels;
using AspNETWebAPI_Course.Exceptions;

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
			try
			{
				var publisher = _publishersService.AddPublisher(book);
				return Created(nameof(AddPublisher), publisher);
			}
			catch (PublisherNameException ex)
			{
				return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("get-publisher/{id}")]
		public IActionResult GetPublisher(int id)
		{
			var _publisher = _publishersService.GetPublisher(id);
			if (_publisher != null)
			{
				return Ok(_publisher);
			}
			else
			{
				return NotFound();
			} 
		}

		[HttpGet("get-publisherdata/{id}")]
		public IActionResult GetPublisherData(int id)
		{
			var _publisher = _publishersService.GetPublisherData(id);
			return Ok(_publisher);
		}

		[HttpDelete("delete-publisher/{id}")]
		public IActionResult DeletePublisher(int id)
		{
			try
			{
				_publishersService.DeletePublisher(id);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
