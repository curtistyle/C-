string strValue = ConvertToType<string>(123);  // Convertir a string
int intValue = ConvertToType<int>("123");      // Convertir a int
float floatValue = ConvertToType<float>("123.45"); // Convertir a float

Console.WriteLine("Value = " + strValue + ", type: " + strValue.GetType());
Console.WriteLine("Value = " + intValue + ", type: " + intValue.GetType());
Console.WriteLine("Value = " + floatValue + ", type: " + floatValue.GetType());

T ConvertToType<T>(object value)
{
    if (value is T)
    {
        return (T)value;
    }

    if (typeof(T) == typeof(string))
    {
        return (T)(object)value.ToString();
    }
    else if (typeof(T) == typeof(int))
    {
        return (T)(object)Convert.ToInt32(value);
    }
    else if (typeof(T) == typeof(float))
    {
        return (T)(object)Convert.ToSingle(value);
    }

    throw new InvalidOperationException($"Tipo de dato {typeof(T).Name} no soportado.");
}