using SimpleLibraryManagement.Application.DTOs.BorrowedBook;
using SimpleLibraryManagement.Application.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.Interfaces
{
    public interface IBorrowedBookService
    {
        Task<ApiResponse<bool>> CreateBorrowingAsync(int bookId, int borrowerId, BorrowedBookDto borrowedBookModel);

        Task<List<DisplayBorrowedBook>> GetBorrowedBooksAsync();
        Task<ApiResponse<List<DisplayBorrowedBook>>> GetBorrowersByBookIdAsync(int bookId);
        Task<ApiResponse<List<DisplayBorrowedBook>>> GetBorrowedBookByBorrowerIdAsync(int borrowerId);
        Task<ApiResponse<bool>> DeleteBorrowedBookAsync(int bookId, int borrowerId);

    }
}
