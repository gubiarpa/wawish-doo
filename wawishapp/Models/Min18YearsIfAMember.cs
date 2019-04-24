using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wawishapp.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if ((new byte?[] { MembershipType.Unknown, MembershipType.PayAsYouGo }).Contains(customer.MembershipTypeId))
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthday is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Custeomer should be at least 18 years old to go on a membership.");
        }
    }
}