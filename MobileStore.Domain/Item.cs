
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class Item
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal? Price { get; set; }


        public string? Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int Quantity { get; set; }

    }

}
