using MediatR;

namespace Application.Features.Categories.Query
{
    public class CategoryHandlerInput :  IRequest<CategoryHandlerOutput>
    {
        public long categoryId { get; set; }     
    }
}
