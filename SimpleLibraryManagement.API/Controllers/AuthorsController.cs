
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryManagement.Application.DTOs.Author;
using SimpleLibraryManagement.Application.Interfaces;

namespace SimpleLibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    public class AuthorsController : ControllerBase
    {
       
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        
        
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto authorModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, "Model is Not Valid");

            var response = await _authorService.CreateAuthorAsync(authorModel);

            return StatusCode(response.StatusCode, response.Message);

        }
        [HttpGet]
        public async Task<IActionResult> GetAuthors() 
            => Ok(await _authorService.GetAuthorsAsync());

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthor(int authorId)
        {
            var author = await _authorService.GetAuthorAsync(authorId);

            return author.Success ? StatusCode(author.StatusCode, author.Data) : StatusCode(author.StatusCode, author.Message);

        }

        [HttpPut("{authorId}")]
        public async Task<IActionResult> EditAuthor(int authorId, [FromBody] AuthorDto authorModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, "Model is Not Valid");

            var response = await _authorService.EditAuthorAsync(authorId,authorModel);

            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            var response = await _authorService.DeleteAuthorAsync(authorId);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
