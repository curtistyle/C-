using System.Collections.Generic;
using UsingInterface;
// cod 12.14 - Test interface IPayable with disparate classes

var payableObjects = new List<IPayable>()
{
    new Invoice("01234", "seat", 2, 375.00M),
    new Invoice("56789", "tire", 4, 79.95M),
    new SalariedEmployee("John", "Smith", "111-11-1111", 800.00M),
    new SalariedEmployee("Lisa", "Barnes", "888-88-8888", 1200.00M)
};

Console.WriteLine("Invoices and Employee processed polymorphically:\n");

// generically process each element in payableObjects
foreach (var payable in payableObjects)
{
    // output payable and its appropiate payment amount
    Console.WriteLine($"{payable}");
    Console.WriteLine($"payment due: {payable.GetPaymentAmount():C}\n");
}


