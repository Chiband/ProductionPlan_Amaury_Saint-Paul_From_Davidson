using MediatR;

namespace Application.Use_Cases.ProductionPlan
{
    internal sealed class ProductionPlanHandler : IRequestHandler<CreateProductionPlanCommand, IReadOnlyCollection<ProductionPlanResponse>>
    {
        public Task<IReadOnlyCollection<ProductionPlanResponse>> Handle(
            CreateProductionPlanCommand request, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
