using DotNetCoreTemplate.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTemplate.Attribute
{
    public class ModelAValidtionAttribute : ValidationAttribute
    {
        //public ITestService TestService { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (ITestService)validationContext
                         .GetService(typeof(ITestService));

            if (service.GetABC().Any(x => x == (string)value) == false)
            {
                return new ValidationResult("Accept string \"A\", \"B\", \"C\" only.");
            }

            return ValidationResult.Success;
        }
    }
}
