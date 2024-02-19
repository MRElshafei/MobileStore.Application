using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MobileStore.Application.Feature.Categories.Command
{
    public class DeleteCategoryHandlerInput :  IRequest<DeleteCategoryHandlerOutput>
    {
        public int CategoryId { get; set; }

    }
}
