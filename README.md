# Purchase Calculator Service

The Purchase Calculator Service is a software micro-service component designed to calculate purchase details based on provided input.

## Features

This service has the following features:

- It can calculate the Gross Amount, Net Amount, and VAT (Value Added Tax) Amount based on given input values.
- The calculations can be based on either the Net Amount, Gross Amount, or VAT Amount, depending on the information available.

## Structure of Service

The service is mainly composed of a single class `PurchaseCalculator` which has a method `Calculate(PurchaseInput input)`. The `PurchaseInput` is a record that can contain:

- Net Amount: The original price excluding the VAT.
- Gross Amount: The total amount, which is the sum of the Net Amount and the VAT.
- VAT Amount: The Value Added Tax amount.
- VAT Rate: The percent rate of the VAT.

The `PurchaseCalculator` based on the input received, calculates and returns a `PurchaseOutput` record which contains the Net Amount, Gross Amount, and the VAT Amount.

## Use Case

Here's how you can use the service:

csharp PurchaseCalculator calculator = new PurchaseCalculator(); PurchaseInput input = new PurchaseInput { NetAmount = 100, VatRate = 20 }; PurchaseOutput result = calculator.Calculate(input); Console.WriteLine($"Net: {result.NetAmount}, Gross: {result.GrossAmount}, VAT:{result.VatAmount}");

## Testing

The service is covered by NUnit tests to make sure that the service is working as expected and calculates all the amounts correctly.

## Contact Details

Should you have any issues or need any further information, feel free to create an issue in this [repository](https://github.com/YourRepoHere/PurchaseCalculatorService/issues) and we will be glad to assist you promptly.

Thanks for using the Purchase Calculator Service!
