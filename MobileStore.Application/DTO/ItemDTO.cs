using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.DTO
{
    public class ItemDTO
    {
        public long? ID  { get; set; }

        public string Name { get; set; }
        public decimal? Price { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }
    }
}
