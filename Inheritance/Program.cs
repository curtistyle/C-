// Testing class CommissionEmployee

using Inheritance;

// instantiate CommissionEmployee object
var employee = new CommissionEmployee("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

// display CommissionEmployee data
Console.WriteLine("Employee information obtained by properties and methods: \n");
Console.WriteLine($"First name is {employee.FirstName}");
Console.WriteLine($"Last name is {employee.LastName}");
Console.WriteLine($"Social security number is {employee.SocialSecurityNumber}");
Console.WriteLine($"Gross sales are {employee.GrossSales:C}");
Console.WriteLine($"Commission rate is {employee.GrossSales:F2}");
Console.WriteLine($"Earnings are {employee.Earnings()}:C");

employee.GrossSales = 5000.00M; // set gross sales
employee.CommissionRate = .1M;  // set commission rate

Console.WriteLine("\nUpdated employee information obtained by ToString:\n");
Console.WriteLine(employee);
Console.WriteLine($"earnings: {employee.Earnings():C}");

Console.ReadKey();
Console.Clear();



// Test BasePlusCommissionEmployeeTest


var employee2 = new BasePlusCommissionEmployee("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

Console.WriteLine("Employee information obtained by properties and methods: \n");
Console.WriteLine($"First name is {employee2.FirstName}");
Console.WriteLine($"Last name is {employee2.LastName}");
Console.WriteLine($"Social securuty number is {employee2.SocialSecurityNumber}");
Console.WriteLine($"Gross sales are {employee2.GrossSales:C}");
Console.WriteLine($"Commission rate is {employee2.CommissionRate}");
Console.WriteLine($"Earnings are {employee2.Earnings():C}");
Console.WriteLine($"Base salary is {employee2.BaseSalary:C}");

employee2.BaseSalary = 1000.00M; // set base salary

Console.WriteLine("\nUpdated employee information obtained by ToString:\n");
Console.WriteLine(employee2);
Console.WriteLine($"earnings: {employee2.Earnings():C}");
