namespace VerivoxTask.Domain.ElectricityTariff;

public class PackagedElectricityTariff : IElectricityTariff {
    public string Name { get; set; }
    private double IncludedKwh { get; set; }
    private double BaseCost { get; set; }
    private double AdditionalKwhCost { get; set; }

    public PackagedElectricityTariff(
        string name,
        double includedKwh,
        double baseCost,
        double additionalKwhCost
    ) {
        Name = name;
        IncludedKwh = includedKwh;
        BaseCost = baseCost;
        AdditionalKwhCost = additionalKwhCost;
    }

    public double CalculateCost(double kwhConsumption) {
        if (kwhConsumption <= IncludedKwh) return BaseCost;

        var kwhOverLimit = kwhConsumption - IncludedKwh;
        var additionalConsumptionCosts = kwhOverLimit * AdditionalKwhCost;
        return BaseCost + additionalConsumptionCosts;
    }
}