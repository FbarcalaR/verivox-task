using VerivoxTask.Application.ElectricityTariff.Interfaces;
using VerivoxTask.Application.ElectricityTariff.Models;
namespace VerivoxTask.Application.ElectricityTariff;

public class CalculateTariffUseCase : ICalculateTariffUseCase {
    private readonly IExternalElectricityTariffProvider _tariffProvider;

    public CalculateTariffUseCase(IExternalElectricityTariffProvider tariffProvider) {
        _tariffProvider = tariffProvider;
    }

    public async Task<IEnumerable<CalculatedTariff>> CalculateTariff(double kwhConsumption) {
        var tariffs = await _tariffProvider.GetElectricityTariffs();

        return tariffs
               .Select(tariff => new CalculatedTariff(tariff.Name, tariff.CalculateCost(kwhConsumption)))
               .ToList();
    }
}