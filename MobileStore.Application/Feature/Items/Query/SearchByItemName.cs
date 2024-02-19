using MediatR;

using Microsoft.Extensions.Logging;
using MobileStore.Application.DTO;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Items.Query
{
    public class SearchByItemNameHandler : IRequestHandler<SearchByItemNameHandlerInput, SearchByItemNameHandlerOutput>
    {

        private readonly ILogger<SearchByItemNameHandler> _logger;
        private readonly IItemRepository _reposatory;

        public SearchByItemNameHandler(ILogger<SearchByItemNameHandler> logger, IItemRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<SearchByItemNameHandlerOutput> Handle(SearchByItemNameHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling SearchByItemName business logic");
            SearchByItemNameHandlerOutput output = new SearchByItemNameHandlerOutput();
            var Items = _reposatory.SearchByItemName(request.ItemName);
            output.items = Items
            .Select(o => new ItemDTO
            {
                CategoryId = o.CategoryId,
                Description = o.Description,
                ID = o.ID,
                Name = o.Name,
                Quantity = o.Quantity,
                Price = o.Price

            }).ToList();
            return output;
        }
    }
}
