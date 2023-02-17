using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthor2.Controllers
{
    [Route("api/bookAuthor")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(BookAuthorMapDTOs dto)
        {

            try
            {
                var data = BookAuthorMapServices.Add(dto);

                if (data == null)
                {
                    throw new Exception("Failed to add value");
                }

                return Ok(new { status = "success", data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "Failed", message = ex.Message });
            }
        }

        [HttpDelete("{authorId}/{bookId}")]
        public IActionResult Delete(int authorId, int bookId)
        {
            try
            {
                BookAuthorMapServices.Delete(authorId, bookId);
                return Ok(new {status = "Success"});
            }
            catch(Exception ex)
            {
                return BadRequest(new { status = "Failed", message = ex.Message });
            }
        }
    }
}
