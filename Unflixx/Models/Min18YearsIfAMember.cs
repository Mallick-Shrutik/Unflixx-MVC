using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unflixx.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown ||customer.MembershipTypeId == MembershipType.PayAsYouGo) //if(customer.MembershipTypeId == 0 ||customer.MembershipTypeId == 1) 0,1 are magic numbers and are genereally avoided so that other developers can understand our code
            {
                return ValidationResult.Success;
            }

            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be 18 years or older");
        }
    }
}