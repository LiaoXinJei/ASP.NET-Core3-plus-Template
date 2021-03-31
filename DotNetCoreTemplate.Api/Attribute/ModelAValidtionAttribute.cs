using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTemplate.Api.ApiAttribute
{
    public class ModelAValidtionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var service = (ITestService)validationContext
            //             .GetService(typeof(ITestService));

            //if (service.GetABC().Any(x => x == (string)value) == false)
            //{
            //    return new ValidationResult("Accept string \"A\", \"B\", \"C\" only.");
            //}

            return ValidationResult.Success;
        }
    }
}
