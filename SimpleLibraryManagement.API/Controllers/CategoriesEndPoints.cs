using Carter;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryManagement.Application.DTOs.Category;
using SimpleLibraryManagement.Application.Interfaces;

namespace SimpleLibraryManagement.API.Controllers
{
    public class CategoriesEndPoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/MinimalCategoriesAPI")
                .RequireAuthorization("AdminPolicy")
                .WithTags("MinimalCategoriesAPI");

            group.MapGet("", async (ICategoryService categoryService) =>
            {
                return TypedResults.Ok(await categoryService.GetCategoriesAsync());
            });

            group.MapGet("{categoryId}", GetCategory);
            group.MapPut("{categoryId}", EditCategory);
            group.MapDelete("{categoryId}", DeleteCategory);
            group.MapPost("", CreateCategory);

        }
        public async Task<IResult> GetCategory(int categoryId, ICategoryService categoryService)
        {
            var category = await categoryService.GetCategoryAsync(categoryId);

            return category.Success ?
                TypedResults.Ok(category.Data) :
                TypedResults.NotFound(category.Message);
        }
        public async Task<IResult> CreateCategory([FromBody] CategoryDto categoryModel, ICategoryService categoryService)
        {
            var response = await categoryService.CreateCategoryAsync(categoryModel);
            return TypedResults.Json(response.Message,statusCode: response.StatusCode);
        }

        public async Task<IResult> EditCategory(int categoryId, [FromBody] CategoryDto categoryModel, ICategoryService categoryService)
        {
           
            var response = await categoryService.EditCategoryAsync(categoryId, categoryModel);

            return TypedResults.Json(response.Message,statusCode: response.StatusCode);
        }

        public async Task<IResult> DeleteCategory(int categoryId, ICategoryService categoryService)
        {
            var response = await categoryService.DeleteCategoryAsync(categoryId);

            return TypedResults.Json(response.Message, statusCode:response.StatusCode);
        }

    }
}
