using Application.Features.Categories.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Application.Features.Items.Query;

namespace MobileStore.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var GetAllCategories = new CategoriesHandlerInput();
            var Categories = _mediator.Send(GetAllCategories);
            if (Categories == null)
            {
                return NotFound("No Categories Yet!!");
            }
            return Ok(Categories.Result);
        }
    }
}
