using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Application.Enums;

namespace MobileStore.Application.Feature.Orders.Query
{
    public class GetOrdesrBasedOnStatuesHandlerInput : IRequest<GetOrdesrBasedOnStatuesHandlerOutput>
    {
        public int Statues { get; set; }
    }
}
