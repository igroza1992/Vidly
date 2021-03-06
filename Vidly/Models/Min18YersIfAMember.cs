﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YersIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if(customer.MembershipTypeId==MembershipType.Unknow||customer.MembershipTypeId== MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if(customer.Birthday==null)
                return new ValidationResult("Birthday is required");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 yers old to register");
        }
    }
}