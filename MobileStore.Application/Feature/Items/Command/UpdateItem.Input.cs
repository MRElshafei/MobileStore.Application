using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MobileStore.Application.Feature.Items.Command
{
    public class UpdateItemHandlerInput :  IRequest<UpdateItemHandlerOutput>
    {
        public UpdateItemDTO updateItem { get; set; }
    }
    public class UpdateItemDTO
    {
        [Required(ErrorMessage = "ItemId is required.")]
        public long ItemId { get; set; }
        public string? Name { get; set; }
        public IFormFile? Imagefile { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

    }
}
