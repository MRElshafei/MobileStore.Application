using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using MobileStore.Application.Interfaces;

namespace Application.Features.Categories.Query
{
    public class CategoriesHandler : IRequestHandler<CategoriesHandlerInput, CategoriesHandlerOutput>
    {

        private readonly ILogger<CategoriesHandler> _logger;
        private readonly ICategoryReository _reposatory;

        public CategoriesHandler(ILogger<CategoriesHandler> logger, ICategoryReository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<CategoriesHandlerOutput> Handle(CategoriesHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling Categories business logic");
            CategoriesHandlerOutput output = new CategoriesHandlerOutput();
            var Categories = _reposatory.GetAllCategories();
            output.Categories = Categories
                .Select(o => new CategoryDTO
                {
                    ID = o.ID,
                    Name = o.Name,
                    Description = o.Description

                }).ToList();
            return output;
        }
    }
}
