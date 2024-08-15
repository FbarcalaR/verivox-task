using VerivoxTask.Domain.ElectricityTariff;
namespace VerivoxTask.Application.ElectricityTariff.Interfaces;

public interface IExternalElectricityTariffProvider {
    public Task<IEnumerable<IElectricityTariff>> GetElectricityTariffs();
}