namespace Supermarket.API.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;
    using Supermarket.Abstractions.Services;
    using Supermarket.API.Extensions;
    using Supermarket.DataTransferModels.Categories;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<ReadDto>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDto>> GetAsync(
            [FromRoute] [Required] int id,
            CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAsync(id);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] InsertDto insertDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var result = await _categoryService.SaveAsync(insertDto);

            if (!result.Success)
                return BadRequest(result.Message);


            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [Required] [FromRoute] int id,
            [FromBody] UpdateDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _categoryService.UpdateAsync(id, updateDto);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _categoryService.DeleteAsync(id);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }
    }
}