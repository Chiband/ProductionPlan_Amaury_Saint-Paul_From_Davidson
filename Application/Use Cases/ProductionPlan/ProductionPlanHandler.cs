using Application.Use_Cases.ProductionPlan.Mappings;
using MediatR;

namespace Application.Use_Cases.ProductionPlan
{
    internal sealed class ProductionPlanHandler : IRequestHandler<CreateProductionPlanCommand, IReadOnlyCollection<ProductionPlanResponse>>
    {
        public Task<IReadOnlyCollection<ProductionPlanResponse>> Handle(
            CreateProductionPlanCommand request, 
            CancellationToken cancellationToken)
        {
            var powerplants = request.Powerplants.Select(p => p.ToDomain()).ToList();
            var fuels = request.Fuels.ToDomain();

            throw new NotImplementedException();
        }
    }
}
