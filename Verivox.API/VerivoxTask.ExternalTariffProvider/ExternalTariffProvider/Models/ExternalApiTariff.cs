using System.Text.Json.Serialization;
using VerivoxTask.ExternalTariffProvider.ExternalTariffProvider.Enums;
namespace VerivoxTask.ExternalTariffProvider.ExternalTariffProvider.Models;

public class ExternalApiTariff {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public TariffType Type { get; set; }

    [JsonPropertyName("baseCost")]
    public double BaseCost { get; set; }

    [JsonPropertyName("additionalKwhCost")]
    public double AdditionalKwhCost { get; set; }

    [JsonPropertyName("includedKwh")]
    public double IncludedKwh { get; set; }
}