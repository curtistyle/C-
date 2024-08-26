using System.Collections;

try
{
    Salaries salaries = new Salaries();
    
    ArrayList _salaryList = salaries.getSalaryList();

    float salary = (float)_salaryList[1];

    salary = salary + (salary * 0.02f);

    Console.WriteLine(salary); 
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.ReadKey();

class Salaries
{
    ArrayList _salaryList = new ArrayList();


    public Salaries()
    {
        _salaryList.Add(60000.34f);
        _salaryList.Add(40000.51f);
        _salaryList.Add(50000.22f);
    }

    public ArrayList getSalaryList()
    {
        return _salaryList;
    }
}