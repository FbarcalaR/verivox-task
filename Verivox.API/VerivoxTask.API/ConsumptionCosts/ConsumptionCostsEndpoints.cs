using Carter;
using VerivoxTask.Application.ElectricityTariff;
using VerivoxTask.ConsumptionCosts.Models;
namespace VerivoxTask.ConsumptionCosts;

public class ConsumptionCostsEndpoints : ICarterModule {
    private readonly ICalculateTariffUseCase _calculateTariffUseCase;

    public void AddRoutes(IEndpointRouteBuilder app) {
        var electricityTariffsRoute = app
                                      .MapGroup("api/consumption-costs")
                                      .WithOpenApi();

        electricityTariffsRoute
            .MapGet("/", GetConsumptionCost);
    }

    public ConsumptionCostsEndpoints(ICalculateTariffUseCase calculateTariffUseCase) {
        _calculateTariffUseCase = calculateTariffUseCase;
    }

    private async Task<IResult> GetConsumptionCost(int kwhConsumption) {
        return Results.Ok(await _calculateTariffUseCase.CalculateTariff(kwhConsumption));
    }
}