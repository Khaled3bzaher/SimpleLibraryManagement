using Microsoft.EntityFrameworkCore;
using SimpleLibraryManagement.Domain.Interfaces;
using SimpleLibraryManagement.Domain.Models;
using SimpleLibraryManagement.Infrastructure.Data;
using System.Net;

namespace SimpleLibraryManagement.Infrastructure.Repositories
{
    public class BorrowedBookRepository : GenericRepository<BorrowedBook>, IBorrowedBookRepository
    {
        private readonly LibraryDbContext _context;

        public BorrowedBookRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BorrowedBook>> GetDisplayBorrowedBookByBorrowerId(int borrowerId)
        {
            return await GetAsQueryAble().Where(bb => bb.BorrowerId == borrowerId).Include(bb => bb.Borrower).Include(bb => bb.Book).OrderByDescending(bb => bb.BorrowedDate).ToListAsync();
        }

        

        public async Task<BorrowedBook?> GetBorrowedBook(int bookId, int borrowerId)
        {
            return await GetAsQueryAble().FirstOrDefaultAsync(bb => bb.BorrowerId == borrowerId && bb.BookId == bookId);
        }

        public async Task<List<BorrowedBook>> GetDisplayBorrowersByBookId(int bookId)
        {
            return await GetAsQueryAble().Where(bb => bb.BookId == bookId).Include(bb => bb.Borrower).Include(bb => bb.Book).OrderByDescending(bb => bb.BorrowedDate).ToListAsync();
        }

        public async Task<bool> isBorrowed(int bookId, int borrowerId)
        {
            return await GetAsQueryAble().AnyAsync(bb => bb.BookId == bookId
            && bb.BorrowerId == borrowerId);
        }

        public async Task<List<BorrowedBook>> GetDisplayBorrowedBooks()
        {
            return await GetAsQueryAble().Include(bb=>bb.Borrower).Include(bb=>bb.Book).OrderByDescending(bb => bb.BorrowedDate).ToListAsync();
        }
    }
}
