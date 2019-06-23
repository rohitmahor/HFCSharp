using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(255)]
        public String Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}