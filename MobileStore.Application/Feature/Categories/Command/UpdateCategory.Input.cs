using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Categories.Command
{
    public class UpdateCategoryHandlerInput :  IRequest<UpdateCategoryHandlerOutput>
    {
        public UpdateCategoryDTO updateCategory { get; set; }
    }
    public class UpdateCategoryDTO
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
