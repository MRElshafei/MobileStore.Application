using MediatR;

namespace MobileStore.Application.Feature.Orders.Command
{
    public class CancelOrderHandlerInput :  IRequest<CancelOrderHandlerOutput>
    {
        public int orderId { get; set; }
    }
}
