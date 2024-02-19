using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.DTO;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Items.Query
{
    public class GetItemsHandler : IRequestHandler<GetItemsHandlerInput, GetItemsHandlerOutput>
    {
        private readonly ILogger<GetItemsHandler> _logger;
        private readonly IItemRepository _reposatory;

        public GetItemsHandler(ILogger<GetItemsHandler> logger, IItemRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<GetItemsHandlerOutput> Handle(GetItemsHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetItems business logic");
            GetItemsHandlerOutput output = new GetItemsHandlerOutput();
            var items = _reposatory.GetAllItems();
            output.Items = items
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
