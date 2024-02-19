
using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }

}
