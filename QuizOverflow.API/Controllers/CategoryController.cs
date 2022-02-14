using Microsoft.AspNetCore.Mvc;
using QuizOverflow.Data.Contracts;

namespace QuizOverflow.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();

            return Ok(categories);
        }
    }
}
