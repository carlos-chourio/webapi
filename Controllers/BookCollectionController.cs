using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.DTOs;
using WebApi.Entities;
using CcLibrary.AspNetCore.Common;
using WebApi.Filters;

namespace WebApi.Controllers {
    [ApiController]
    [Route("api/BooksCollection")]
    public class BookCollectionController : ControllerBase {
        private readonly IMapper mapper;
        private readonly IBooksRepository booksRepository;

        public BookCollectionController(IMapper mapper, IBooksRepository booksRepository) {
            this.mapper = mapper;
            this.booksRepository = booksRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookCollection(IEnumerable<BookForCreationDto> booksDto) {
            if (ModelState.IsValid) {
                var books = mapper.Map<IEnumerable<Book>>(booksDto);
                foreach (var book in books) {
                    booksRepository.CreateBook(book);
                }
                if (await booksRepository.SaveChangesAsync()) {
                    return Ok();
                }
                return StatusCode(500);
            }
            return new UnprocessableEntityObjectResult(ModelState);
        }

        [HttpGet("{ids}")]
        [BooksMapperFilter]
        public async Task<IActionResult> GetBooksCollection([ModelBinder(BinderType = typeof(ArrayModelBinder<int>))] int[] ids) {
            var books = await booksRepository.GetBooksAsync(ids);
            if (books!=null) {
                return Ok(books);
            }
            return NotFound();
        }
    }
}
