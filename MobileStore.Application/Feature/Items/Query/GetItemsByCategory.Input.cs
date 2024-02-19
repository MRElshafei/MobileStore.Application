using MediatR;

namespace MobileStore.Application.Feature.Items.Query
{
    public class GetItemsByCategoryHandlerInput : IRequest<GetItemsByCategoryHandlerOutput>
    {
        public int CategoryId { get; set; }

    }
}
