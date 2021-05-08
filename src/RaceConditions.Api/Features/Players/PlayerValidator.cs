using FluentValidation;

namespace RaceConditions.Api.Features
{
    public class PlayerValidator : AbstractValidator<PlayerDto> {
        public PlayerValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
