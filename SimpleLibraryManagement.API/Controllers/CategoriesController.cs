using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryManagement.Application.DTOs.Category;
using SimpleLibraryManagement.Application.Interfaces;

namespace SimpleLibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    public class CategoriesController : ControllerBase
    {
      
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, "Model is Not Valid");

            var response = await _categoryService.CreateCategoryAsync(categoryModel);

            return StatusCode(response.StatusCode, response.Message);

        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
            => Ok(await _categoryService.GetCategoriesAsync());

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var category = await _categoryService.GetCategoryAsync(categoryId);

            return category.Success ? StatusCode(category.StatusCode, category.Data) : StatusCode(category.StatusCode, category.Message);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> EditCategory(int categoryId, [FromBody] CategoryDto categoryModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, "Model is Not Valid");

            var response = await _categoryService.EditCategoryAsync(categoryId, categoryModel);

            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var response = await _categoryService.DeleteCategoryAsync(categoryId);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
