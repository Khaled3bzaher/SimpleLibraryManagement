using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryManagement.Application.DTOs.Book;
using SimpleLibraryManagement.Application.Interfaces;

namespace SimpleLibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrAuthor")]
        public async Task<IActionResult> CreateBook([FromQuery]int authorId, [FromQuery] int categoryId, [FromBody] BookDto bookModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, "Model is Not Valid");

            var response = await _bookService.CreateBookAsync(authorId, categoryId,bookModel);

            return StatusCode(response.StatusCode, response.Message);

        }

        [HttpPut("{bookId}")]
        [Authorize(Policy = "AdminOrAuthor")]
        public async Task<IActionResult> EditBook(int bookId,[FromQuery] int authorId, [FromQuery] int categoryId, [FromBody] BookDto bookModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, "Model is Not Valid");

            var response = await _bookService.EditBookAsync(bookId, authorId, categoryId, bookModel);

            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBooks()
            => Ok(await _bookService.GetBooksAsync());

        [HttpGet("{bookId}")]
        [Authorize]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var book = await _bookService.GetBookAsync(bookId);

            return book.Success ? StatusCode(book.StatusCode, book.Data) : StatusCode(book.StatusCode, book.Message);
        }

        [HttpGet("Authors/{authorId}")]
        [Authorize]
        public async Task<IActionResult> GetAuthorBooks(int authorId)
        {
            var books = await _bookService.GetAuthorBooksAsync(authorId);

            return books.Success ? StatusCode(books.StatusCode, books.Data) : StatusCode(books.StatusCode, books.Message);
        }
        [HttpGet("Categories/{categoryId}")]
        [Authorize]
        public async Task<IActionResult> GetCategoryBooks(int categoryId)
        {
            var books = await _bookService.GetCategoryBooksAsync(categoryId);

            return books.Success ? StatusCode(books.StatusCode, books.Data) : StatusCode(books.StatusCode, books.Message);
        }

        [HttpDelete("{bookId}")]
        [Authorize(Policy = "AdminOrAuthor")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var response = await _bookService.DeleteBookAsync(bookId);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
