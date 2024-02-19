using Application.Features.Categories.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.DTO;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Categories.Command
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryHandlerInput, CreateCategoryHandlerOutput>
    {
        private readonly ILogger<CreateCategoryHandler> _logger;
        private readonly ICategoryReository _reposatory;

        public CreateCategoryHandler(ILogger<CreateCategoryHandler> logger, ICategoryReository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<CreateCategoryHandlerOutput> Handle(CreateCategoryHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateCategory business logic");
            CreateCategoryHandlerOutput output = new CreateCategoryHandlerOutput();
            var message = _reposatory.CreateCategory(request.newCategory);
            output.Message = message;
            return output;
        }
    }
}
