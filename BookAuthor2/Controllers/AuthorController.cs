using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthor2.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add(AuthorDTOs dto)
        {
            try
            {
                return Ok(new {status="success", data=AuthorServices.Add(dto)});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var ret = AuthorServices.Delete(id);

                if (ret != null) return NoContent();

                throw new Exception();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("update")]
        public IActionResult Update(AuthorDTOs dto)
        {
            try
            {
                return Ok(new {status="success", data=AuthorServices.Update(dto)});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("np")]
        public IActionResult Get()
        {
            try
            {
                return Ok(new { status = "success", data = AuthorServices.GetNP() });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromQuery] RouteParamsDTO dto)
        {
            try
            {
                return Ok(new { status = "success", data = AuthorServices.Get(dto) });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(new { status = "success", data = AuthorServices.Get(id) });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
