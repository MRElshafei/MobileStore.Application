using MediatR;

using Microsoft.Extensions.Logging;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Orders.Command
{
    public class PayOrderHandler : IRequestHandler<PayOrderHandlerInput, PayOrderHandlerOutput>
    {

        private readonly ILogger<PayOrderHandler> _logger;
        private readonly IOrderRepository _reposatory;

        public PayOrderHandler(ILogger<PayOrderHandler> logger, IOrderRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<PayOrderHandlerOutput> Handle(PayOrderHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling PayOrder business logic");
            PayOrderHandlerOutput output = new PayOrderHandlerOutput();
            var message=_reposatory.PayOrder(request.OrderId);
            output.Message = message;
            return output;
        }
    }
}
