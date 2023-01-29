﻿namespace Supermarket.API.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Net.Mime;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;
    using Supermarket.Abstractions.Services;
    using Supermarket.API.Extensions;
    using Supermarket.DataTransferModels.Categories;

    [ApiController]
    [Route(ApiRoutes.Categories.BaseRoute)]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(Name = nameof(GetCategories))]
        [ProducesResponseType(typeof(ReadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryService.ListAsync().ConfigureAwait(false);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Categories.GetById, Name = nameof(GetCategory))]
        [ProducesResponseType(typeof(ReadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReadDto>> GetCategory(
            [FromRoute][Required][Range(1, int.MaxValue)] int id,
            CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAsync(id, cancellationToken).ConfigureAwait(false);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response);
        }

        [HttpPost(Name = nameof(InsertCategory))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<IActionResult> InsertCategory(
            [FromBody][Required] InsertDto insertDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _categoryService.SaveAsync(insertDto, cancellationToken).ConfigureAwait(false);

            if (!response.Success)
                return BadRequest(response.Message);

            return CreatedAtRoute(nameof(GetCategory), new { id = response.Data }, response.Data);
        }

        [HttpPut(ApiRoutes.Categories.Update, Name = nameof(UpdateCategory))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<IActionResult> UpdateCategory(
            [FromRoute][Required][Range(1, int.MaxValue)] int id,
            [FromBody][Required] UpdateDto updateDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _categoryService.UpdateAsync(id, updateDto, cancellationToken).ConfigureAwait(false);

            if (!response.Success)
                return BadRequest(response.Message);

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Categories.Delete, Name = nameof(DeleteCategory))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(
            [FromRoute][Required][Range(1, int.MaxValue)] int id,
            CancellationToken cancellationToken)
        {
            var response = await _categoryService.DeleteAsync(id, cancellationToken).ConfigureAwait(false);

            if (!response.Success)
                return BadRequest(response.Message);

            return NoContent();
        }
    }
}