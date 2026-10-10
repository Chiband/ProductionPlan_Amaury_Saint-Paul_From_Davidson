namespace Application.Use_Cases.ProductionPlan
{
    public record ProductionPlanResponse(IReadOnlyCollection<ResultProductionPlanResponse> Results);

    public record ResultProductionPlanResponse(string Name, double P);
}
