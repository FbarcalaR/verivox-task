using VerivoxTask.Domain.ElectricityTariff;
namespace VerivoxTask.Domain.Tests.ElectricityTariff;

public class PackagedElectricityTariffTests {
    [Test]
    [TestCase(3500, 800)]
    [TestCase(4500, 950)]
    public void WhenPackagedTariffIsCalculate_ThenResultIsOk(double consumption, double expectedResult) {
        // Arrange
        var basicTariff = new PackagedElectricityTariff(
            name: "test",
            includedKwh: 4000,
            baseCost: 800,
            additionalKwhCost: 0.3
            );

        // Act
        var result = basicTariff.CalculateCost(consumption);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}