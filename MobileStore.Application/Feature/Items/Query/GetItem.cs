using Application.Features.Categories.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.DTO;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Items.Query
{
    public class GetItemHandler : IRequestHandler<GetItemHandlerInput, GetItemHandlerOutput>
    {
        private readonly ILogger<GetItemHandler> _logger;
        private readonly IItemRepository _reposatory;

        public GetItemHandler(ILogger<GetItemHandler> logger, IItemRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<GetItemHandlerOutput> Handle(GetItemHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetItem business logic");
            GetItemHandlerOutput output = new GetItemHandlerOutput();
            ItemDTO itemDTO=new ItemDTO();
            var item = _reposatory.GetItem(request.ItemId);
            itemDTO.Name = item.Name;
            itemDTO.Description = item.Description;
            itemDTO.Quantity = item.Quantity;
            itemDTO.Price = item.Price;
            itemDTO.CategoryId = item.CategoryId;
            itemDTO.ID = item.ID;

            output.item = itemDTO;
            return output;
        }
    }
}
