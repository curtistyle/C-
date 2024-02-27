// Codigo 12.1 Polymorphism
// Asignando referencias de la clase base y de la clase 
// derivada a variables de la clase base y de la clase derivada

using Inheritance3;




// asigna referencia de clase base a variable de clase base
var commissionEmployee = new CommissionEmployee("Sue", "Jones", "222-22-2222", 10000.00M, .06M);


// asigna referencia de clase derivada a variable de clase derivada
var basePlusCommissionEmployee = new BasePlusCommissionEmployee("Bob", "Lewis", "333-33-3333", 500.00M, .04M, 300.00M);


// invoca los metodos ToString y Earnings del objeto de la clase base
// usando la variable de clase base
Console.WriteLine("Call CommissionEmployee's ToString and Earnings methods " +
                    "with base-class reference to base class objects\n");

Console.WriteLine(commissionEmployee.ToString());
Console.WriteLine($"earnings: {commissionEmployee.Earnings()}\n");

// invoca los metodos ToString y Earnings del objeto de la clase derivada
// usando la variable clase derivada
Console.WriteLine("Call BasePlusCommissionEmployee's ToString and Earnings methods " + 
                    "with derived-class reference to derived class objects\n");

Console.WriteLine(basePlusCommissionEmployee.ToString());

Console.WriteLine($"earnings: {basePlusCommissionEmployee.Earnings()}\n");

// invoca los metodos ToString y Earnings del objeto de la clase derivada
// usando la variable clase base
CommissionEmployee commissionEmployee2 = basePlusCommissionEmployee;
Console.WriteLine("Call BasePlusCommissionEmployee's ToString and Earnings " +
    "methods with base class reference to derived-class objects\n");

Console.WriteLine(commissionEmployee2.ToString());
Console.WriteLine($"earnings {commissionEmployee2.Earnings()}\n");














