using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Entites;
using WebAPIDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;
        public BookController(IBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetBooks")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.GetBooks());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent,ex.Message);
            }
        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("GetBookById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.GetBookById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        [Route("AddBook")]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                int result = service.AddBook(book);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult Put([FromBody] Book book)
        {
            try
            {
                int result = service.UpdateBook(book);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteBook(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
