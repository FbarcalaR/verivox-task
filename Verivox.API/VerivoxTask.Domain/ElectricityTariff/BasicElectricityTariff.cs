namespace VerivoxTask.Domain.ElectricityTariff;

public class BasicElectricityTariff : IElectricityTariff {
    public string Name { get; set; }
    private readonly double BaseAnnualCost;
    private readonly double AdditionalKwhCost;

    public BasicElectricityTariff(string name, double baseCost, double additionalKwhCost) {
        Name = name;
        AdditionalKwhCost = additionalKwhCost;
        BaseAnnualCost = baseCost * 12;
    }


    public double CalculateCost(double kwhConsumption) {
        var consumptionCosts = AdditionalKwhCost * kwhConsumption;
        return BaseAnnualCost + consumptionCosts;
    }
}