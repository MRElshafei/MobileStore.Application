using MediatR;

using Microsoft.Extensions.Logging;
using MobileStore.Application.Feature.Items.Command;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Orders.Command
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderHandlerInput, CancelOrderHandlerOutput>
    {

        private readonly ILogger<CreateItemHandler> _logger;
        private readonly IOrderRepository _reposatory;

        public CancelOrderHandler(ILogger<CreateItemHandler> logger, IOrderRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<CancelOrderHandlerOutput> Handle(CancelOrderHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CancelOrder business logic");
            CancelOrderHandlerOutput output = new CancelOrderHandlerOutput();
            var message = _reposatory.CancelOrder(request.orderId);
            output.message = message;
            return output;
        }
    }
}
