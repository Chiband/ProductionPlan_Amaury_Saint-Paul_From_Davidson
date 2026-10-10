using FluentValidation;

namespace Application.Use_Cases.ProductionPlan
{
    public sealed class CreateProductionPlanCommandValidator : AbstractValidator<CreateProductionPlanCommand>
    {
        public CreateProductionPlanCommandValidator()
        {
            RuleFor(x => x.Load)
            .Must(double.IsFinite)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Load must be a finite, non-negative value.");

            RuleFor(x => x.Powerplants)
                .NotNull()
                .NotEmpty()
                .WithMessage("At least one powerplant is required.");

            RuleForEach(x => x.Powerplants)
                .ChildRules(powerplant =>
                {
                    powerplant.RuleFor(p => p.Name)
                        .NotEmpty()
                        .WithMessage("Powerplant name is required.");

                    powerplant.RuleFor(p => p.Efficiency)
                        .Must(double.IsFinite)
                        .InclusiveBetween(0, 1)
                        .WithMessage(
                            "Efficiency must be a finite value between 0 and 1.");

                    powerplant.RuleFor(p => p.Pmin)
                        .Must(double.IsFinite)
                        .GreaterThanOrEqualTo(0)
                        .WithMessage(
                            "Pmin must be a finite, non-negative value.");

                    powerplant.RuleFor(p => p.Pmax)
                        .Must(double.IsFinite)
                        .GreaterThanOrEqualTo(0)
                        .WithMessage(
                            "Pmax must be a finite, non-negative value.");

                    powerplant.RuleFor(p => p)
                        .Must(p => p.Pmin <= p.Pmax)
                        .WithMessage(
                            "Pmin must be less than or equal to Pmax.");
                });

            RuleFor(x => x.Fuels)
                .NotNull()
                .WithMessage("Fuel data is required.");
            
            RuleFor(x => x.Fuels.Gas)
                .Must(double.IsFinite)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Gas price must be a finite, non-negative value.");

            RuleFor(x => x.Fuels.Kerosine)
                .Must(double.IsFinite)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kerosine price must be a finite, non-negative value.");

            RuleFor(x => x.Fuels.Co2)
                .Must(double.IsFinite)
                .GreaterThanOrEqualTo(0)
                .WithMessage("CO2 price must be a finite, non-negative value.");

            RuleFor(x => x.Fuels.Wind)
                .Must(double.IsFinite)
                .InclusiveBetween(0, 100)
                .WithMessage("Wind must be a finite percentage between 0 and 100.");
        }
    }
}