using FluentValidation;
using Sat.Recruitment.Core.Utils.Extensions;
using Sat.Recruitment.Core.Utils.Validations;

namespace Sat.Recruitment.Core.Utils.Validations
{
    public static class CustomValidations
    {
        public static IRuleBuilderOptions<T, string> CanStringConvertedToNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(str => str.CanStringConvertedToNumber()).WithMessage("La {PropertyName} no puede ser convertida a número.");
        }
    }
}
