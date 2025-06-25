using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryManagement.Application.DTOs.BorrowedBook;
using SimpleLibraryManagement.Application.Interfaces;

namespace SimpleLibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBooksController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowedBookService;
    
        public BorrowedBooksController(IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
      
        }
        [HttpPost]
        [Authorize(Policy = "AdminOrBorrower")]
        public async Task<IActionResult> CreateBorrowing([FromQuery] int bookId, [FromQuery] int borrowerId, [FromBody] BorrowedBookDto borrowedBookModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, "Model is Not Valid");

            var response = await _borrowedBookService.CreateBorrowingAsync(bookId,borrowerId,borrowedBookModel);

            return StatusCode(response.StatusCode, response.Message);
        }
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetBorrowedBooks()
            => Ok(await _borrowedBookService.GetBorrowedBooksAsync());

        [HttpGet("{bookId}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetBorrowersByBookId(int bookId)
        {
            var borrowers = await _borrowedBookService.GetBorrowersByBookIdAsync(bookId);

            return borrowers.Success ? StatusCode(borrowers.StatusCode, borrowers.Data) : StatusCode(borrowers.StatusCode, borrowers.Message);
        }
        [HttpGet("/BorrowerBooks/{borrowerId}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetBorrowedBookByBorrowerId(int borrowerId)
        {
            var borrowedBooks = await _borrowedBookService.GetBorrowedBookByBorrowerIdAsync(borrowerId);

            return borrowedBooks.Success ? StatusCode(borrowedBooks.StatusCode, borrowedBooks.Data) : StatusCode(borrowedBooks.StatusCode, borrowedBooks.Message);

        }
        [HttpDelete("{bookId},{borrowerId}")]
        [Authorize(Policy = "AdminOrBorrower")]
        public async Task<IActionResult> DeleteBorrowedBook(int bookId, int borrowerId)
        {
            var response = await _borrowedBookService.DeleteBorrowedBookAsync(bookId,borrowerId);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
