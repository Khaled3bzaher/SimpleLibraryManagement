using SimpleLibraryManagement.Application.DTOs.Book;
using SimpleLibraryManagement.Application.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.Interfaces
{
    public interface IBookService
    {
        Task<ApiResponse<bool>> CreateBookAsync(int authorId, int categoryId, BookDto bookModel);

        Task<ApiResponse<bool>> EditBookAsync(int bookId, int authorId, int categoryId, BookDto bookModel);

        Task<List<DisplayBookDto>> GetBooksAsync();
        Task<ApiResponse<DisplayBookDto>> GetBookAsync(int bookId);
        Task<ApiResponse<List<DisplayBookDto>>> GetCategoryBooksAsync(int categoryId);
        Task<ApiResponse<List<DisplayBookDto>>> GetAuthorBooksAsync(int authorId);

        Task<ApiResponse<bool>> DeleteBookAsync(int bookId);


    }
}
