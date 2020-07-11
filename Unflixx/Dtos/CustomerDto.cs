using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Unflixx.Models;

namespace Unflixx.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required] 
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember] temporarily it commented as IHttp wil throw an exception as it is directly casting to Customer class
        public DateTime? Birthdate { get; set; }
    }
}