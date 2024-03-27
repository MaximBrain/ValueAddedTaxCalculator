using ValueAddedTaxCalculator.Models;
using ValueAddedTaxCalculator.Services;

namespace ValueAddedTaxCalculator.Tests;

[TestFixture]
public class PurchaseCalculatorTests
{
    private PurchaseCalculator _calculator = null!;

    [SetUp]
    public void Setup()
    {
        _calculator = new PurchaseCalculator();
    }

    [Test]
    public void Calculate_WithNetAmount_ReturnsCorrectValues()
    {
        // Arrange
        var input = new PurchaseInput {NetAmount = 100, VatRate = 20};

        // Act
        var result = _calculator.Calculate(input);

        // Assert
        Assert.That(result.NetAmount, Is.EqualTo(100));
        Assert.That(result.GrossAmount, Is.EqualTo(120)); // NetAmount + 20% of NetAmount
        Assert.That(result.VatAmount, Is.EqualTo(20)); // GrossAmount - NetAmount
    }

    [Test]
    public void Calculate_WithGrossAmount_ReturnsCorrectValues()
    {
        // Arrange
        var input = new PurchaseInput {GrossAmount = 120, VatRate = 20};

        // Act
        var result = _calculator.Calculate(input);

        // Assert
        Assert.That(result.NetAmount, Is.EqualTo(100)); // GrossAmount / (1 + VAT/100)
        Assert.That(result.GrossAmount, Is.EqualTo(120));
        Assert.That(result.VatAmount, Is.EqualTo(20)); // GrossAmount - NetAmount
    }

    [Test]
    public void Calculate_WithVatAmount_ReturnsCorrectValues()
    {
        // Arrange
        var input = new PurchaseInput {VatAmount = 20, VatRate = 20};

        // Act
        var result = _calculator.Calculate(input);

        // Assert
        Assert.That(result.NetAmount, Is.EqualTo(100)); // VATAmount * 100 / VatRate
        Assert.That(result.GrossAmount, Is.EqualTo(120)); // NetAmount + VAT
        Assert.That(result.VatAmount, Is.EqualTo(20));
    }
}