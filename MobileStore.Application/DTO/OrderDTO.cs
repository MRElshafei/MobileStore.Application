using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.DTO
{
    public  class OrderDTO
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public DateTime TimeStamp { get; set; }

        public long UserId { get; set; }

        public long ItemId { get; set; }

        public int Quantity { get; set; }


        public bool IsPaid { get; set; }

        public bool OnCart { get; set; }
    }
}
