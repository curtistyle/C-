// *************************
// Manejo de errores con Result Pattern
// *************************
Result<int> Divide(int numerator, int denominator)
{
    if (denominator == 0)
    {
        return Result<int>.Failure("El denominador no puede ser cero o menor");
    }
    return Result<int>.Succeless(numerator / denominator);
}
// main
var result = Divide(10, 0);
if (result.IsSucceess)
{
    Console.WriteLine(result.Value);
}
else
{
    Console.WriteLine(result.Error);
}
// fin main
public class Result<T>
{
    public T Value { get; }
    public bool IsSucceess { get; }
    public string Error { get; }

    public Result(T value, bool isSucceess, string error)
    {
        Value = value;
        IsSucceess = isSucceess;
        Error = error;
    }

    public static Result<T> Succeless(T value) => new Result<T>(value, true, null);
    public static Result<T> Failure(string error) => new Result<T>(default, false, error);
}