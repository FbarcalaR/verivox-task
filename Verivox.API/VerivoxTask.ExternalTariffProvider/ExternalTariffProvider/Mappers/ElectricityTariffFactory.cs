using VerivoxTask.Domain.ElectricityTariff;
using VerivoxTask.ExternalTariffProvider.ExternalTariffProvider.Enums;
using VerivoxTask.ExternalTariffProvider.ExternalTariffProvider.Models;
namespace VerivoxTask.ExternalTariffProvider.ExternalTariffProvider.Mappers;

public static class ElectricityTariffFactory {
    public static IElectricityTariff CreateNewElectricityTariff(ExternalApiTariff externalApiTariff) {
        if (externalApiTariff.Type == TariffType.Basic) {
            return new BasicElectricityTariff(
                externalApiTariff.Name,
                externalApiTariff.BaseCost,
                externalApiTariff.AdditionalKwhCost / 100
            );
        }

        return new PackagedElectricityTariff(
            externalApiTariff.Name,
            externalApiTariff.IncludedKwh,
            externalApiTariff.BaseCost,
            externalApiTariff.AdditionalKwhCost / 100
        );
    }
}