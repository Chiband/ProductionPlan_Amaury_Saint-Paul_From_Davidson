using Application.Use_Cases.ProductionPlan;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductionPlanHost.Endpoints
{
    public sealed class ProductionPlanEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/production-plan",               
                async (CreateProductionPlanCommand command,[FromServices] ISender sender, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(command, cancellationToken);

                return Results.Ok(result);                  
            });
        }
    }
}
