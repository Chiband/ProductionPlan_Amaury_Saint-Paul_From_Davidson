using Application.Use_Cases.ProductionPlan.Mappings;
using Domain.Services;
using MediatR;
using SharedKernel;

namespace Application.Use_Cases.ProductionPlan
{
    internal sealed class ProductionPlanHandler(ProductionPlanCalculator productionPlanCalculator) : IRequestHandler<CreateProductionPlanCommand, Result<ProductionPlanResponse>>
    {
        public async Task<Result<ProductionPlanResponse>> Handle(
            CreateProductionPlanCommand request, 
            CancellationToken cancellationToken)
        {
            var powerplants = request.Powerplants.Select(p => p.ToDomain()).ToList();
            var fuels = request.Fuels.ToDomain();

            var result = productionPlanCalculator.Calculate(request.Load, powerplants, fuels);

            if (result.IsFailure)
            {
                return Result<ProductionPlanResponse>.Failure(result.Error);
            }

            var plantProductionResponse = result!.Value!
                .Select(plant => new ResultProductionPlanResponse(
                    plant.Name,
                    plant.Power))
                .ToList();

            var response = new ProductionPlanResponse(plantProductionResponse);

            return Result<ProductionPlanResponse>.Success(response);
        }
    }
}
