using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.DTO;
using MobileStore.Application.Interfaces;
using System.Net;

namespace Application.Features.Categories.Query
{
    public class CategoryHandler : IRequestHandler<CategoryHandlerInput, CategoryHandlerOutput>
    {

        private readonly ILogger<CategoriesHandler> _logger;
        private readonly ICategoryReository _reposatory;

        public CategoryHandler(ILogger<CategoriesHandler> logger, ICategoryReository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<CategoryHandlerOutput> Handle(CategoryHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling Category business logic");
            CategoryHandlerOutput output = new CategoryHandlerOutput();
            CategoryDTO categoryDTO=new CategoryDTO();
            var category = _reposatory.GetCategory(request.categoryId);

            categoryDTO.Description = category.Description;
            categoryDTO.Name = category.Name;
            categoryDTO.ID = category.ID;

            output.categoryDTO = categoryDTO;


                return output;

        }
    }
}
