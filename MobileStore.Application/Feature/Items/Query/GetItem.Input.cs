using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MobileStore.Application.Feature.Items.Query
{
    public class GetItemHandlerInput : IRequest<GetItemHandlerOutput>
    {
        public long ItemId { get; set; }

    }
}
