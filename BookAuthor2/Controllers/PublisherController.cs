using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthor2.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        // ----------------------------------------------- Add an author -------------------------------------------------
        [HttpPost("add")]
        public IActionResult Add(PublisherDTO3 dto)
        {
            try
            {
                return Ok(new { status="success", data=PublisherServices.Add(dto) });
            }
            catch(Exception ex)
            {
                return BadRequest(new { status="failed", message=ex.Message });
            }
        }

        // ----------------------------------------------- Get all publishers -------------------------------------------------
        [HttpGet]
        public IActionResult Get([FromQuery] RouteParamsDTO dto)
        {
            try
            {
                return Ok(new { status = "success", data = PublisherServices.Get(dto) });

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("np")]
        public IActionResult GetWithNoPaging()
        {
            try
            {
                return Ok(new { status = "success", data = PublisherServices.GetWithNoPaging() });

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // ----------------------------------------------- Get all authors -------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(new { status = "success", data = PublisherServices.Get(id) });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // ----------------------------------------------- Update an author -------------------------------------------------
        [HttpPatch("edit")]
        public IActionResult Update(PublisherDTO3 dto)
        {
            try
            {
                return Ok(new { status="success", data=PublisherServices.Update(dto)});
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "Failed", message = ex.Message });
            }
        }


        // ----------------------------------------------- Delete an author -------------------------------------------------
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var data = PublisherServices.Delete(Id);
                return StatusCode(203);
            }
            catch (Exception ex)
            {
                return BadRequest(new {status="Failed", message="Unable to delete author or author not available"});
            }
        }

        // ----------------------------------------------- Get books by authors -------------------------------------------------
        [HttpGet("getbooks/{Id}")]
        public IActionResult GetBooks(int Id)
        {
            try
            {
                return Ok(new { status = "Success", data=PublisherServices.GetBooks(Id) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "Failed", message=ex.Message });
            }
        }


    }
}
