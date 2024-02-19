using MediatR;
using Microsoft.Extensions.Logging;
using MobileStore.Application.Feature.Items.Query;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Items.Command
{
    public class CreateItemHandler : IRequestHandler<CreateItemHandlerInput, CreateItemHandlerOutput>
    {
        private readonly ILogger<CreateItemHandler> _logger;
        private readonly IItemRepository _reposatory;

        public CreateItemHandler(ILogger<CreateItemHandler> logger, IItemRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<CreateItemHandlerOutput> Handle(CreateItemHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateItem business logic");
            CreateItemHandlerOutput output = new CreateItemHandlerOutput();
            var message = _reposatory.CreateItem(request.item);
            output.Message = message;
            return output;
        }
    }
}
