using MediatR;

namespace MobileStore.Application.Feature.Orders.Command
{
    public class CreateOrderHandlerInput : IRequest<CreateOrderHandlerOutput>
    {
        public NewOrderDTO newOrderDTO { get; set; }
    }
    public class NewOrderDTO
    {

        public long ItemId { get; set; }

        public int Quantity { get; set; }
         
    }

}
