using Microsoft.Extensions.DependencyInjection;
using VerivoxTask.Application.ElectricityTariff;
namespace VerivoxTask.Application;

public static class ApplicationLayerBuilder {
    public static void AddApplicationLayer(this IServiceCollection services) {
        services.AddSingleton<ICalculateTariffUseCase, CalculateTariffUseCase>();
    }
}