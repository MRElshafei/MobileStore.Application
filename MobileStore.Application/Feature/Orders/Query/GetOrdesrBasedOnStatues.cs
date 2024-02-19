using MediatR;

using Microsoft.Extensions.Logging;
using MobileStore.Application.DTO;
using MobileStore.Application.Feature.Orders.Command;
using MobileStore.Application.Interfaces;

namespace MobileStore.Application.Feature.Orders.Query
{
    public class GetOrdesrBasedOnStatuesHandler : IRequestHandler<GetOrdesrBasedOnStatuesHandlerInput, GetOrdesrBasedOnStatuesHandlerOutput>
    {

        private readonly ILogger<GetOrdesrBasedOnStatuesHandler> _logger;
        private readonly IOrderRepository _reposatory;

        public GetOrdesrBasedOnStatuesHandler(ILogger<GetOrdesrBasedOnStatuesHandler> logger, IOrderRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;
        }
        public async Task<GetOrdesrBasedOnStatuesHandlerOutput> Handle(GetOrdesrBasedOnStatuesHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetOrdesrBasedOnStatues business logic");
            GetOrdesrBasedOnStatuesHandlerOutput output = new GetOrdesrBasedOnStatuesHandlerOutput();
            var Orders = _reposatory.GetOrdesrBasedOnStatues(request.Statues);
            output.orders = Orders
            .Select(o => new OrderDTO
            {
              Code = o.Code,
              ID = o.ID,
              IsPaid = o.IsPaid,
              ItemId = o.ItemId,
              OnCart = o.OnCart,
              Quantity = o.Quantity,
              TimeStamp = o.TimeStamp,
              UserId = o.UserId
            }).ToList();
            return output;

        }
    }
}
