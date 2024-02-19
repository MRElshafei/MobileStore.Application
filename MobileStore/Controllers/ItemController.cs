using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Application.Features.Items.Query;

namespace MobileStore.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ISender _sender;

        public ItemController( ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var getAllItems = new ItemsInput(); // Use camelCase for local variable names

            var items = await _sender.Send(getAllItems);
            if (items == null)
            {
                return NotFound("No Items Yet!!");
            }

            return Ok(items.Items);
        }

    }
}
