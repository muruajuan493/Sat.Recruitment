using FluentValidation;

namespace Sat.Recruitment.Core.Entities.User.Validations
{
    public class ValidationCreateUser : AbstractValidator<UserEntity>
    {
        public ValidationCreateUser()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(User => User.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("El parámetro {PropertyName} no se encuentra o el dato es invalido. Por favor revise los datos enviados.");

            RuleFor(User => User.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("El parámetro {PropertyName} no se encuentra o el dato es invalido. Por favor revise los datos enviados.");

            RuleFor(User => User.Address)
                .NotNull()
                .NotEmpty()
                .WithMessage("El parámetro {PropertyName} no se encuentra o el dato es invalido. Por favor revise los datos enviados.");

            RuleFor(User => User.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("El parámetro {PropertyName} no se encuentra o el dato es invalido. Por favor revise los datos enviados.");

            RuleFor(User => User.UserType)
                .NotNull()
                .NotEmpty()
                .WithMessage("El parámetro {PropertyName} no se encuentra o el dato es invalido. Por favor revise los datos enviados.");

            RuleFor(User => User.Money)
                .NotNull()
                .NotEmpty()
                .WithMessage("El parámetro {PropertyName} no se encuentra o el dato es invalido. Por favor revise los datos enviados.");
        }
    }
}
