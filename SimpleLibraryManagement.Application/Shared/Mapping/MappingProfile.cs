using AutoMapper;
using SimpleLibraryManagement.Application.DTOs.Author;
using SimpleLibraryManagement.Application.DTOs.Book;
using SimpleLibraryManagement.Application.DTOs.BorrowedBook;
using SimpleLibraryManagement.Application.DTOs.Borrower;
using SimpleLibraryManagement.Application.DTOs.Category;
using SimpleLibraryManagement.Domain.Models;

namespace SimpleLibraryManagement.Application.Shared.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Borrower, BorrowerDto>();
            CreateMap<BorrowerDto, Borrower>();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, DisplayBookDto>()
               .ForMember(s => s.AutherName, opt => opt.MapFrom(src => src.Author.Name))
               .ForMember(s => s.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                ;

            CreateMap<BorrowedBookDto, BorrowedBook>();
            CreateMap<BorrowedBook, BorrowedBookDto>();
            CreateMap<BorrowedBook, DisplayBorrowedBook>()
               .ForMember(s => s.BorrowerName, opt => opt.MapFrom(src => src.Borrower.Name))
               .ForMember(s => s.BookName, opt => opt.MapFrom(src => src.Book.Name))

                ;
        }
    }
}
