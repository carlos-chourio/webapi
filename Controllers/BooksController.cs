using System;
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
        private readonly IBooksRepository booksRepository;
        private readonly IMapper mapper;
        private readonly IAuthorRepository authorRepository;

        public BooksController(IBooksRepository booksRepository, IMapper mapper, IAuthorRepository authorRepository) {
            this.booksRepository = booksRepository;
            this.mapper = mapper;
            this.authorRepository = authorRepository;
        }

        [HttpPost]
        [BookMapperFilter]
        public async Task<IActionResult> CreateBook([FromBody]BookForCreationDto bookDto) {
            if (ModelState.IsValid) {
                if (authorRepository.AuthorExists()) {
                    var bookEntity = mapper.Map<Book>(bookDto);
                    booksRepository.CreateBook(bookEntity);
                    if (await booksRepository.SaveChangesAsync()) {
                        return CreatedAtRoute("GetBooks", new { bookEntity.Id }, bookEntity);
                    }
                    return BadRequest(new ErrorModel("The author of this book doesn't exist in our database"));
                }
                return new StatusCodeResult(500);
            }
            return new UnprocessableEntityObjectResult(ModelState);
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
            if (books!=null) {
                return Ok(books);
            }
            return NotFound();
        }
    }
}
