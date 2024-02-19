using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
