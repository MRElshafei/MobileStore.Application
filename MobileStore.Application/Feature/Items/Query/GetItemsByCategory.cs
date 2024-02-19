using Domain;
using MediatR;

using Microsoft.Extensions.Logging;
using MobileStore.Application.DTO;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Items.Query
{
    public class GetItemsByCategoryHandler : IRequestHandler<GetItemsByCategoryHandlerInput, GetItemsByCategoryHandlerOutput>
    {
        private readonly ILogger<GetItemsByCategoryHandler> _logger;
        private readonly IItemRepository _reposatory;

        public GetItemsByCategoryHandler(ILogger<GetItemsByCategoryHandler> logger, IItemRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<GetItemsByCategoryHandlerOutput> Handle(GetItemsByCategoryHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetItemsByCategory business logic");
            GetItemsByCategoryHandlerOutput output = new GetItemsByCategoryHandlerOutput();
            var items = _reposatory.GetItemsByCategoryId(request.CategoryId);
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
