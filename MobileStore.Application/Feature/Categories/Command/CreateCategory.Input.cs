using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MobileStore.Application.Feature.Categories.Command
{
    public class CreateCategoryHandlerInput : IRequest<CreateCategoryHandlerOutput>
    {
        public NewCategoryDTO newCategory { get; set; }
    }
    public class NewCategoryDTO
    {

            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }

            public string? Description { get; set; }
        
    }
}
