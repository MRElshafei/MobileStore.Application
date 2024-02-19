using Application.Features.Categories.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.Interfaces;
using System.Net;

namespace Application.Features.Categories.Command
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryHandlerInput, UpdateCategoryHandlerOutput>
    {

        private readonly ILogger<CategoriesHandler> _logger;
        private readonly ICategoryReository _reposatory;

        public UpdateCategoryHandler(ILogger<CategoriesHandler> logger, ICategoryReository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }

        public async Task<UpdateCategoryHandlerOutput> Handle(UpdateCategoryHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling UpdateCategory business logic");
            UpdateCategoryHandlerOutput output = new UpdateCategoryHandlerOutput();
            var message=_reposatory.UpdateCategory(request.updateCategory);
            output.Message = message;
            return output;
        }
    }
}
