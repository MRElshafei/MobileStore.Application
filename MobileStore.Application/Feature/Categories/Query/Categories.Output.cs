
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Categories.Query
{
    public class CategoriesHandlerOutput
    {
        public List<CategoryDTO> Categories = new List<CategoryDTO>();

    }

    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }

}
