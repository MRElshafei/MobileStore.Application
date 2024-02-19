using Application.Features.Categories.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Categories.Command
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryHandlerInput, DeleteCategoryHandlerOutput>
    {
        private readonly ILogger<DeleteCategoryHandler> _logger;
        private readonly ICategoryReository _reposatory;

        public DeleteCategoryHandler(ILogger<DeleteCategoryHandler> logger, ICategoryReository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<DeleteCategoryHandlerOutput> Handle(DeleteCategoryHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling DeleteCategory business logic");
            DeleteCategoryHandlerOutput output = new DeleteCategoryHandlerOutput();
            var message = _reposatory.DeleteCategory(request.CategoryId);
            output.Message = message;

            return output;

        }
    }
}
