using Microsoft.Extensions.DependencyInjection;
using VerivoxTask.Application.ElectricityTariff.Interfaces;
using VerivoxTask.ExternalTariffProvider.ExternalTariffProvider;

namespace VerivoxTask.ExternalTariffProvider;

public static class ExternalTariffProviderBuilder {
    public static void AddExternalTariffProvider(this IServiceCollection services) {
        services.AddSingleton<IExternalElectricityTariffProvider, ExternalElectricityTariffProvider>();
    }
}