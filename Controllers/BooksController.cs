using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers {
    [ApiController]
    [Route("api/Books")]
    public class BooksController : ControllerBase {
        private readonly IBooksRepository boksRepository;

        public BooksController(IBooksRepository boksRepository) {
            this.boksRepository = boksRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id) {
            var book = await boksRepository.GetBookAsync(id);    
            if (book!=null) {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks() {
            var books = await boksRepository.GetBooksAsync(); 
            if (books!=null) {
                return Ok(books);
            }
            return NotFound();
        }
    }
}
