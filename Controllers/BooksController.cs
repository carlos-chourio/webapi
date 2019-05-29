using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CcLibrary.AspNetCore.Common;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Filters;

namespace WebApi.Controllers {
    [ApiController]
    [Route("api/Books")]
    public class BooksController : ControllerBase {
        private readonly IBookRepository booksRepository;
        private readonly IMapper mapper;
        private readonly IAuthorRepository authorRepository;

        public BooksController(IBookRepository booksRepository, IMapper mapper, IAuthorRepository authorRepository) {
            this.booksRepository = booksRepository;
            this.mapper = mapper;
            this.authorRepository = authorRepository;
        }

        [HttpPost]
        [BookMapperFilter]
        public async Task<IActionResult> CreateBook([FromBody]BookForCreationDto bookDto) {
            if (await authorRepository.AuthorExistsAsync()) {
                var bookEntity = mapper.Map<Book>(bookDto);
                booksRepository.CreateBook(bookEntity);
                if (await booksRepository.SaveChangesAsync()) {
                    return CreatedAtRoute("GetBooks", new { bookEntity.Id }, bookEntity);
                }
                return new StatusCodeResult(500);
            }
            return BadRequest(new ErrorModel("The author of this book doesn't exist in our database"));
        }

        [HttpGet("{id:int}")]
        [BookMapperFilter]
        public async Task<IActionResult> GetBook(int id) {
            var book = await booksRepository.GetBookAsync(id);    
            if (book!=null) {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpGet(Name ="GetBooks")]
        [BooksMapperFilter]
        public async Task<IActionResult> GetBooks() {
            var books = await booksRepository.GetBooksAsync();
            var bookCovers = await booksRepository.GetBookCoversAsync("5");
            if (books!=null) {
                return Ok(books);
            }
            return NotFound();
        }
    }
}
