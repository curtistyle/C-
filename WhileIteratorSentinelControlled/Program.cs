float total = 0;
int gradeCounter = 0;

Console.Write("Enter a grade of student (-1 quit loop): ");
int grade = int.Parse(Console.ReadLine());  

while (grade != -1)
{
    gradeCounter++;
    total += grade;
    Console.Write("Enter a grade of student: ");
    grade = int.Parse(Console.ReadLine());
}

total = total / gradeCounter;

Console.WriteLine($"Average of the {gradeCounter} if {total:0.00}");




