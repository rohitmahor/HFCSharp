﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        [Display (Name = "Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}
