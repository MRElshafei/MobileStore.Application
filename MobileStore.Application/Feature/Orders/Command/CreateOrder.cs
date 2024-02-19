using MediatR;

using Microsoft.Extensions.Logging;
using MobileStore.Application.Feature.Items.Command;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Orders.Command
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderHandlerInput, CreateOrderHandlerOutput>
    {

        private readonly ILogger<CreateOrderHandler> _logger;
        private readonly IOrderRepository _reposatory;

        public CreateOrderHandler(ILogger<CreateOrderHandler> logger, IOrderRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<CreateOrderHandlerOutput> Handle(CreateOrderHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateOrder business logic");
            CreateOrderHandlerOutput output = new CreateOrderHandlerOutput();
            var Message = _reposatory.CreateOrder(request.newOrderDTO);
            output.message = Message;
            return output;
        }
    }
}
