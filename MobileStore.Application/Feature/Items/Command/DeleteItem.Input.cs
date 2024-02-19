using MediatR;

namespace MobileStore.Application.Feature.Items.Command
{
    public class DeleteItemHandlerInput :  IRequest<DeleteItemHandlerOutput>
    {
        public int ItemId { get; set; }

    }
}
