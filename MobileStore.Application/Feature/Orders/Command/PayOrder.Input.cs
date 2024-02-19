using MediatR;

namespace MobileStore.Application.Feature.Orders.Command
{
    public class PayOrderHandlerInput :  IRequest<PayOrderHandlerOutput>
    {
        public int OrderId { get; set; }
    }
}
