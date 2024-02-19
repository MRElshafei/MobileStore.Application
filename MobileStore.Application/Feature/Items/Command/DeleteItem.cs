using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.Feature.Categories.Command;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Items.Command
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemHandlerInput, DeleteItemHandlerOutput>
    {
        private readonly ILogger<DeleteItemHandler> _logger;
        private readonly IItemRepository _reposatory;

        public DeleteItemHandler(ILogger<DeleteItemHandler> logger, IItemRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<DeleteItemHandlerOutput> Handle(DeleteItemHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling DeleteItem business logic");
            DeleteItemHandlerOutput output = new DeleteItemHandlerOutput();
            var message = _reposatory.DeleteItem(request.ItemId);
            output.Message = message;

            return output;
        }
    }
}
