// test Employee

using Composition;

var birtday = new Date(7, 14, 1949);
var hireDate = new Date(3, 12, 1988);
var employee = new Employee("Bob", "Blue", birtday, hireDate);

Console.WriteLine(employee);