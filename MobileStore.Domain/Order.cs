using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        public string Code { get; set; }

        public DateTime TimeStamp { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Item")]
        public long ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }


        public bool IsPaid { get; set; }

        public bool OnCart { get; set; }
    }
}
