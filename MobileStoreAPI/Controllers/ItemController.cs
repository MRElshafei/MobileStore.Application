using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Application.Feature.Items.Command;
using MobileStore.Application.Feature.Items.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileStoreAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Item/Items
        [HttpGet("Items")]
        public async Task<ActionResult<List<GetItemsHandlerOutput>>> GetAllItemsAsync()
        {
            try
            {
                var itemsInput = new GetItemsHandlerInput();

                var items = await _mediator.Send(itemsInput);
                if (items == null)
                {
                    return NotFound();
                }

                return Ok(items.Items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // GET: api/Item/ItemsByCategory
        [HttpGet("ItemsByCategory")]
        public async Task<ActionResult<List<GetItemsByCategoryHandlerOutput>>> GetAllItemsAsync([FromQuery] int Id )
        {
            try
            {
                var getItemsByCategoryHandlerInput = new GetItemsByCategoryHandlerInput
                {
                    CategoryId = Id
                };

                var item = await _mediator.Send(getItemsByCategoryHandlerInput);

                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item.Items);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        // GET: api/Item/SearchItems
        [HttpGet("SearchItems")]
        public async Task<ActionResult<List<SearchByItemNameHandlerOutput>>> GetAllItemsAsync([FromQuery] string Name)
        {
            try
            {
                var searchByItemNameHandlerInput = new SearchByItemNameHandlerInput
                {
                    ItemName=Name
                };

                var Items = await _mediator.Send(searchByItemNameHandlerInput);

                if (Items == null)
                {
                    return NotFound();
                }
                return Ok(Items.items);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Item/Item/id?1
        [HttpGet("Item")]
        public async Task<ActionResult<GetItemHandlerOutput>> GetItemAsync([FromQuery] long id)
        {
            try
            {
              

                var getItemHandlerInput = new GetItemHandlerInput
                {
                    ItemId = id
                };

                var item = await _mediator.Send(getItemHandlerInput);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item.item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Item/Item
        [Authorize(Roles = "Admin")]
        [HttpPost("Item")]
        public async Task<ActionResult<string>> CreateItemAsync([FromBody] NewItemDTO newItemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessage = string.Join(", ", ModelState.Where(x => x.Value.Errors.Any())
                                                                    .Select(x => x.Key));
                    return BadRequest($"The following fields are required: {errorMessage}");
                }

              

                var createItemHandlerInput = new CreateItemHandlerInput
                {
                    item = newItemDTO
                };

                var message = await _mediator.Send(createItemHandlerInput);

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

        // Put:  api/Item/Item
        [HttpPut("Item")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> UpdateItemAsync([FromBody] UpdateItemDTO updateItemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessage = string.Join(", ", ModelState.Where(x => x.Value.Errors.Any())
                                                                    .Select(x => x.Key));
                    return BadRequest($"The following fields are required: {errorMessage}");
                }

             

                var updateItemHandlerInput = new UpdateItemHandlerInput
                {
                    updateItem = updateItemDTO
                };

                var message = await _mediator.Send(updateItemHandlerInput);

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

        // Delete:  api/Item/Item/id?1
        [HttpDelete("Item")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> DeleteItemAsync([FromQuery] int id)
        {
            try
            {
              

                var deleteItemHandlerInput = new DeleteItemHandlerInput
                {
                    ItemId = id
                };

                var message = await _mediator.Send(deleteItemHandlerInput);

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
