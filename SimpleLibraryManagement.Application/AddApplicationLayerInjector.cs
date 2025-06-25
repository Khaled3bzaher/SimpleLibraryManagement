using Microsoft.Extensions.DependencyInjection;
using SimpleLibraryManagement.Application.Interfaces;
using SimpleLibraryManagement.Application.Services;
using SimpleLibraryManagement.Application.Shared.Mapping;

namespace SimpleLibraryManagement.Application
{
    public static class DepndencyInjection
    {
        public static IServiceCollection AddApplicationLayerInjector(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();
            services.AddScoped<IBorrowerService, BorrowerService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
