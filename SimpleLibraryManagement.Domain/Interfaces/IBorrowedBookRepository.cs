using SimpleLibraryManagement.Domain.Models;

namespace SimpleLibraryManagement.Domain.Interfaces
{
    public interface IBorrowedBookRepository : IGenericRepository<BorrowedBook>
    {
        Task<List<BorrowedBook>> GetDisplayBorrowedBooks();
        Task<List<BorrowedBook>> GetDisplayBorrowersByBookId(int bookId);
        Task<List<BorrowedBook>> GetDisplayBorrowedBookByBorrowerId(int borrowerId);
        Task<BorrowedBook?> GetBorrowedBook(int bookId, int borrowerId);
        Task<bool> isBorrowed(int book, int borrowerId);
    }
}
