using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using VerivoxTask.Application.ElectricityTariff.Interfaces;
using VerivoxTask.Domain.ElectricityTariff;
using VerivoxTask.ExternalTariffProvider.ExternalTariffProvider.Mappers;
using VerivoxTask.ExternalTariffProvider.ExternalTariffProvider.Models;
namespace VerivoxTask.ExternalTariffProvider.ExternalTariffProvider;

public class ExternalElectricityTariffProvider : IExternalElectricityTariffProvider {
    public async Task<IEnumerable<IElectricityTariff>> GetElectricityTariffs() {
        var tariffList = await FetchTariffsFromExternalApi();

        if (tariffList == null)
            return new List<IElectricityTariff>();

        return tariffList.Select(ElectricityTariffFactory.CreateNewElectricityTariff);
    }

    private async Task<IEnumerable<ExternalApiTariff>?> FetchTariffsFromExternalApi() {
        var currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        var fileName = $"{currentPath}/ExternalTariffProvider/Mocks/FakeResponse.json";
        await using var openStream = File.OpenRead(fileName);
        return await JsonSerializer.DeserializeAsync<IEnumerable<ExternalApiTariff>>(openStream)!;
    }
}