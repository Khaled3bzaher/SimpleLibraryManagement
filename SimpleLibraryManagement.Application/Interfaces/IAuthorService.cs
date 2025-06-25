using SimpleLibraryManagement.Application.DTOs.Author;
using SimpleLibraryManagement.Application.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<ApiResponse<bool>> CreateAuthorAsync(AuthorDto authorModel);
        Task<List<AuthorDto>> GetAuthorsAsync();
        Task<ApiResponse<AuthorDto>> GetAuthorAsync(int authorId);
        Task<ApiResponse<bool>> EditAuthorAsync(int authorId, AuthorDto authorModel);
        Task<ApiResponse<bool>> DeleteAuthorAsync(int authorId);

    }
}
