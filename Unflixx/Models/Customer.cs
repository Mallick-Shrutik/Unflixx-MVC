using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unflixx.Models
{
    public class Customer
    {
        public int Id { get; set; } 

        //(Part 1 of form validation)
        [Required] //Overriding default conventions by setting is not nullable (also called as DataAnnotation)
        [StringLength(255)]
        public string Name { get; set; }

        //If we want to customize the error message 
        //[Required(ErrorMessage = "Please enter Customer Name")]

        public bool IsSubscribedToNewsletter { get; set; }

        
        public MembershipType MembershipType { get; set; } //this is called as navigation property and used to load objects and related objects (here navigation between customer and Membership type)

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //foreign key(to only load aparticular related object and not all related objects)

        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        
    }
}