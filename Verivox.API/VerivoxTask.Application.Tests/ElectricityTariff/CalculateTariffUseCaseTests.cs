using FakeItEasy;
using VerivoxTask.Application.ElectricityTariff;
using VerivoxTask.Application.ElectricityTariff.Interfaces;
using VerivoxTask.Domain.ElectricityTariff;

namespace VerivoxTask.Application.Tests.ElectricityTariff;

public class CalculateTariffUseCaseTests {
    private IExternalElectricityTariffProvider _tariffProvider;

    [SetUp]
    public void SetUp()
    {
        _tariffProvider = A.Fake<IExternalElectricityTariffProvider>();
    }

    [Test]
    public async Task WhenTariffIsRequestedAndCalculated_ThenTariffListIsReturned() {
        // Arrange
        var amountOfTariffs = 5;
        var electricityTariffs = A.CollectionOfFake<IElectricityTariff>(amountOfTariffs);
        A.CallTo(() => _tariffProvider.GetElectricityTariffs())
         .Returns(electricityTariffs);
        var kwhConsumption = A.Dummy<double>();

        var calculateTariffUseCase = new CalculateTariffUseCase(_tariffProvider);

        // Act
        var result = (await calculateTariffUseCase.CalculateTariff(kwhConsumption)).ToArray();

        // Assert
        A.CallTo(() => _tariffProvider.GetElectricityTariffs()).MustHaveHappened();
        Assert.That(result, Has.Length.EqualTo(amountOfTariffs));
    }

    [Test]
    public async Task WhenTariffIsRequestedAndCalculated_ThenTariffNameExists() {
        // Arrange
        var electricityTariff = new BasicElectricityTariff("testName", 0, 0);
        A.CallTo(() => _tariffProvider.GetElectricityTariffs())
         .Returns(new List<IElectricityTariff> { electricityTariff });
        var kwhConsumption = A.Dummy<double>();

        var calculateTariffUseCase = new CalculateTariffUseCase(_tariffProvider);

        // Act
        var result = (await calculateTariffUseCase.CalculateTariff(kwhConsumption)).ToArray();

        // Assert
        A.CallTo(() => _tariffProvider.GetElectricityTariffs()).MustHaveHappened();
        Assert.That(electricityTariff.Name, Is.EqualTo(result[0].Name));
    }

    [Test]
    public async Task WhenTariffIsRequestedAndCalculated_ThenAnnualCostExists() {
        // Arrange
        var electricityTariff = new BasicElectricityTariff("", 1, 1);
        A.CallTo(() => _tariffProvider.GetElectricityTariffs())
         .Returns(new List<IElectricityTariff> { electricityTariff });
        var kwhConsumption = A.Dummy<double>();

        var calculateTariffUseCase = new CalculateTariffUseCase(_tariffProvider);

        // Act
        var result = (await calculateTariffUseCase.CalculateTariff(kwhConsumption)).ToArray();

        // Assert
        A.CallTo(() => _tariffProvider.GetElectricityTariffs()).MustHaveHappened();
        Assert.That(result[0].AnnualCost, Is.GreaterThan(0));
    }
}