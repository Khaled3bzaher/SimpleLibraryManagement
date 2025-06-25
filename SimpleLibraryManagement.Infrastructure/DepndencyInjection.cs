using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleLibraryManagement.Domain.Interfaces;
using SimpleLibraryManagement.Infrastructure.Data;
using SimpleLibraryManagement.Infrastructure.Repositories;

namespace SimpleLibraryManagement.Infrastructure
{
    public static class DepndencyInjection
    {
        public static IServiceCollection AddInfrastructureLayerInjector(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string not found.");

            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentityCore<IdentityUser>(
                opt =>
                {
                    opt.SignIn.RequireConfirmedAccount = true;
                })
                .AddRoles<IdentityRole>()
                .AddUserManager<UserManager<IdentityUser>>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<LibraryDbContext>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();

            return services;
        }
    }
}
