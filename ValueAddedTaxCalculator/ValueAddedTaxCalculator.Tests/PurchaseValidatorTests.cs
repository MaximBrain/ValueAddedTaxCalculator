using ValueAddedTaxCalculator.Extensions;
using ValueAddedTaxCalculator.Models;
using ValueAddedTaxCalculator.Services;

namespace ValueAddedTaxCalculator.Tests;

[TestFixture]
public class PurchaseValidatorTests
{
    private PurchaseValidator _validator = null!;

    [SetUp]
    public void SetUp()
    {
        _validator = new PurchaseValidator();
    }

    [Test]
    public void Should_Throw_Exception_When_Input_Is_Null()
    {
        Assert.Throws<BadInputException>(() => _validator.Validate(null), "Input is null.");
    }

    [Test]
    public void Should_Throw_Exception_When_All_Amounts_Are_Null_Or_Zero()
    {
        var input = new PurchaseInput
        {
            NetAmount = 0,
            GrossAmount = 0,
            VatAmount = 0
        };
        Assert.Throws<BadInputException>(() => _validator.Validate(input),
            "At least one of the input amounts (Net, Gross, VAT) must be provided.");
    }

    [Test]
    public void Should_Throw_Exception_When_Amounts_Are_Negative()
    {
        var input = new PurchaseInput
        {
            NetAmount = -50,
            GrossAmount = 0,
            VatAmount = 0
        };
        Assert.Throws<BadInputException>(() => _validator.Validate(input), "Negative values are invalid.");
    }

    [Test]
    public void Should_Throw_Exception_When_Multiple_Amounts_Are_Provided()
    {
        var input = new PurchaseInput
        {
            NetAmount = 50,
            GrossAmount = 60,
            VatAmount = 0
        };
        Assert.Throws<BadInputException>(() => _validator.Validate(input),
            "Only one of the input amounts (Net, Gross, VAT) should be provided.");
    }

    [Test]
    public void Should_Throw_Exception_When_VAT_Rate_Is_Invalid()
    {
        var input = new PurchaseInput
        {
            NetAmount = 50,
            VatRate = -1
        };
        Assert.Throws<BadInputException>(() => _validator.Validate(input), "Invalid VAT rate provided.");
    }
}