using Application.Features.Categories.Command;
using Application.Features.Categories.Query;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Application.Feature.Categories.Command;

namespace MobileStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Category/Categories
        [HttpGet("Categories")]
        public async Task<ActionResult<List<CategoriesHandlerOutput>>> GetAllAsync()
        {
            var CategoriesHandlerInput = new CategoriesHandlerInput();

            var Categories = await _mediator.Send(CategoriesHandlerInput);

            return Ok(Categories.Categories);
        }

        // GET:  api/Category/Category
        [HttpGet("Category")]
        public async Task<ActionResult<CategoryHandlerOutput>> GetAsync([FromQuery] long id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid category ID.");
                }

                var categoryHandlerInput = new CategoryHandlerInput
                {
                    categoryId = id
                };

                var category = await _mediator.Send(categoryHandlerInput);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category.categoryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Category/Category
        [HttpPost("Category")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> CreateCategoryAsync([FromBody] NewCategoryDTO newCategoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessage = string.Join(", ", ModelState.Where(x => x.Value.Errors.Any())
                                                                    .Select(x => x.Key));
                    return BadRequest($"The following fields are required: {errorMessage}");
                }

                var createCategoryHandlerInput = new CreateCategoryHandlerInput
                {
                    newCategory = newCategoryDTO
                };

                var message = await _mediator.Send(createCategoryHandlerInput);

                if (message == null)
                {
                    return NotFound();
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Put:api/Category/Category
        [HttpPut("Category")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> UpdateCategoryAsync([FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessage = string.Join(", ", ModelState.Where(x => x.Value.Errors.Any())
                                                                    .Select(x => x.Key));
                    return BadRequest($"The following fields are required: {errorMessage}");
                }

                var updateCategoryHandlerInput = new UpdateCategoryHandlerInput
                {
                    updateCategory = updateCategoryDTO
                };

                var message = await _mediator.Send(updateCategoryHandlerInput);

                if (message == null)
                {
                    return NotFound();
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete:api/Category/Category
        [HttpDelete("Category")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> DeleteCategoryAsync([FromQuery] int id)
        {
            try
            {
              


                var deleteCategoryHandlerInput = new DeleteCategoryHandlerInput
                {
                    CategoryId = id
                };

                var message = await _mediator.Send(deleteCategoryHandlerInput);

                if (message == null)
                {
                    return NotFound();
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
