using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.CrossCuttingConcerns.FluentValidation
{
    public class ValidatorTool
    {
        public static void ModelValidate(IValidator validator, object model)
        {
            var result = validator.Validate(model);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
