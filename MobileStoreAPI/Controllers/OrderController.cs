using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Application.Feature.Items.Command;
using MobileStore.Application.Feature.Items.Query;
using MobileStore.Application.Feature.Orders.Command;
using MobileStore.Application.Feature.Orders.Query;

namespace MobileStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Order/Orders
        [HttpGet("Orders")]
        public async Task<ActionResult<List<GetOrdesrBasedOnStatuesHandlerOutput>>> GetAllOrdersAsync([FromQuery] int id)
        {
            try
            {
                var getOrdesrBasedOnStatuesHandlerInput = new GetOrdesrBasedOnStatuesHandlerInput
                {
                    Statues = id
                };

                var orders = await _mediator.Send(getOrdesrBasedOnStatuesHandlerInput);
                if (orders == null)
                {
                    return NotFound();
                }

                return Ok(orders.orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Order/Order
        [HttpPost("Order")]
        public async Task<ActionResult<string>> CreateOrderAsync([FromBody] NewOrderDTO newOrderDTOInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessage = string.Join(", ", ModelState.Where(x => x.Value.Errors.Any())
                                                                    .Select(x => x.Key));
                    return BadRequest($"The following fields are required: {errorMessage}");
                }



                var createOrderHandlerInput = new CreateOrderHandlerInput
                {
                    newOrderDTO = newOrderDTOInput
                };

                var message = await _mediator.Send(createOrderHandlerInput);

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

        [Authorize(Roles = "Admin")]
        // Delete: api/Order/Order/id?1
        [HttpDelete("Order")]
        public async Task<ActionResult<string>> CancelOrderAsync([FromQuery] int id)
        {
            try
            {


                var cancelOrderHandlerInput = new CancelOrderHandlerInput
                {
                    orderId = id,
                };

                var message = await _mediator.Send(cancelOrderHandlerInput);

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

        // Post: api/Order/PayOrder/id?1
        [HttpPost("PayOrder")]
        public async Task<ActionResult<string>> PayOrderAsync([FromQuery] int id)
        {
            try
            {
                var payOrderHandlerInput = new PayOrderHandlerInput
                {
                    OrderId=id
                };
                var message = await _mediator.Send(payOrderHandlerInput);

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
