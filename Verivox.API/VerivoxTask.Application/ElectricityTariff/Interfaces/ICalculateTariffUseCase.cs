using VerivoxTask.Application.ElectricityTariff.Models;
namespace VerivoxTask.Application.ElectricityTariff;

public interface ICalculateTariffUseCase {
    Task<IEnumerable<CalculatedTariff>> CalculateTariff(double kwhConsumption);
}