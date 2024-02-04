/*
 A person invests $1,000 in a savings account yielding 5% interest. Assuming that all the
interest is left on deposit, calculate and print the amount of money in the account at the
end of each year for 10 years. Use the following formula to determine the amounts:
a = p (1 + r)^n
where
p is the original amount invested (i.e., the principal)
r is the annual interest rate (e.g., use 0.05 for 5%)
n is the number of years
a is the amount on deposit at the end of the nth year.
 */


int p = 1000;
float r = 0.05F;



for (int n = 1; n <= 10; n++)
{
    decimal a = p * ((decimal) Math.Pow(1.0 + r, n));
 
    Console.WriteLine($"{n,4}{a,20:C}");
}



