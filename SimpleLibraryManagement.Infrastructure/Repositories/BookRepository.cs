using Microsoft.EntityFrameworkCore;
using SimpleLibraryManagement.Domain.Interfaces;
using SimpleLibraryManagement.Domain.Models;
using SimpleLibraryManagement.Infrastructure.Data;

namespace SimpleLibraryManagement.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {

        public BookRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<List<Book>> GetAllAuthorBooks(int authorId)
        {
            return await GetAsQueryAble().Where(b => b.Author.Id == authorId).Include(b=>b.Author).Include(b=>b.Category).ToListAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await GetAsQueryAble().Include(b => b.Author).Include(b => b.Category).ToListAsync();
        }

        public async Task<List<Book>> GetAllCategoryBooks(int categoryId)
        {
            return await GetAsQueryAble().Where(b => b.Category.Id == categoryId).Include(b => b.Author).Include(b => b.Category).ToListAsync();
        }

        public async Task<Book?> GetBookById(int bookId)
        {
            return await GetAsQueryAble().Where(b => b.Id == bookId).Include(b => b.Author).Include(b => b.Category).FirstOrDefaultAsync();
        }
    }
}
