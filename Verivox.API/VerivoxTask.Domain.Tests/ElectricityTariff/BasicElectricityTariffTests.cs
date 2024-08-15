using VerivoxTask.Domain.ElectricityTariff;
namespace VerivoxTask.Domain.Tests.ElectricityTariff;

public class BasicElectricityTariffTests {
    [Test]
    [TestCase(3500, 830)]
    [TestCase(4500, 1050)]
    public void WhenBasicTariffIsCalculate_ThenResultIsOk(double consumption, double expectedResult) {
        // Arrange
        var basicTariff = new BasicElectricityTariff(
            "test",
            5,
            0.22
        );

        // Act
        var result = basicTariff.CalculateCost(consumption);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}