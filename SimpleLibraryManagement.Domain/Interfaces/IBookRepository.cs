using SimpleLibraryManagement.Domain.Models;

namespace SimpleLibraryManagement.Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(int bookId);
        Task<List<Book>> GetAllAuthorBooks(int authorId);
        Task<List<Book>> GetAllCategoryBooks(int categoryId);

    }
}
