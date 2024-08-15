namespace VerivoxTask.Domain.ElectricityTariff;

public interface IElectricityTariff {
    string Name { get; protected set; }
    double CalculateCost(double kwhConsumption);
}