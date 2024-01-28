// input and output date

string fullname;
int age;
char sex;
bool isWorker;

Console.Write("Enter a name: ");
fullname = Console.ReadLine();

Console.Write("Enter age: ");
age =  int.Parse(Console.ReadLine());

Console.Write("Enter sex (m/f): ");
sex = char.Parse(Console.ReadLine());

Console.Write("Enter he/she is a worker (values: 'true' or 'false'): ");
isWorker = bool.Parse(Console.ReadLine());

/*
 Character scape
    \a Matches a bell character (alarma)
    \b Matches a backspace (retroceso)
    \t Matches a tab (tabulacion)
    \r Matches a carriage return (retorno de carro)
    \v Matches a vertical tab (tabulacion vertical)
    \f Matches a from feed (avance de pagina)
    \n Matches a new line (nueva linea)
    \e Matches an escape (escape)
 */

Console.WriteLine("You registered this person \n\n");
Console.WriteLine("Name: " + fullname);
Console.WriteLine("Age: " + age);
Console.WriteLine("Sex: " + sex);
Console.WriteLine("Works?: " + isWorker);


