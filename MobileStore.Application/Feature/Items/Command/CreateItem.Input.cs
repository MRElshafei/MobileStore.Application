using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MobileStore.Application.Feature.Items.Command
{
    public class CreateItemHandlerInput : IRequest<CreateItemHandlerOutput>
    {
        public NewItemDTO item { get; set; }

    }
    public class NewItemDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public int Price { get; set; }
    }
}
