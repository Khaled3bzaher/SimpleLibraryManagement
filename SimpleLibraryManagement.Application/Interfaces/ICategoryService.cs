using SimpleLibraryManagement.Application.DTOs.Category;
using SimpleLibraryManagement.Application.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<bool>> CreateCategoryAsync(CategoryDto categoryModel);

        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<ApiResponse<CategoryDto>> GetCategoryAsync(int categoryId);
        Task<ApiResponse<bool>> EditCategoryAsync(int categoryId, CategoryDto categoryModel);
        Task<ApiResponse<bool>> DeleteCategoryAsync(int categoryId);

    }
}
