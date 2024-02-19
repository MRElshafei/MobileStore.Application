using MediatR;

namespace MobileStore.Application.Feature.Items.Query
{
    public class SearchByItemNameHandlerInput : IRequest<SearchByItemNameHandlerOutput>
    {
        public string ItemName { get; set; }
    }
}
