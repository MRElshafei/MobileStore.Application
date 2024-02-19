using MediatR;

using Microsoft.Extensions.Logging;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Items.Command
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemHandlerInput, UpdateItemHandlerOutput>
    {
        private readonly ILogger<UpdateItemHandler> _logger;
        private readonly IItemRepository _reposatory;

        public UpdateItemHandler(ILogger<UpdateItemHandler> logger, IItemRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<UpdateItemHandlerOutput> Handle(UpdateItemHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling UpdateItem business logic");
            UpdateItemHandlerOutput output = new UpdateItemHandlerOutput();
            var message = _reposatory.UpdateItem(request.updateItem);
            output.Message = message;
            return output;
        }
    }
}
