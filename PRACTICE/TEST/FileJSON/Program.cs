using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using FileJSON.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string path = @"D:\Progarmacion\C-\PRACTICE\TEST\FileJSON\words.json";

        var text = await File.ReadAllTextAsync(path);

        Root? root = JsonSerializer.Deserialize<Root>(text, new JsonSerializerOptions
        {
            IncludeFields = true
        });


/*        var filterWord =
            root?.words.english.Where((value, index) => value.value == "because")
            .Select((value) => value.key)
            .ToList();

        foreach (var item in filterWord)
        {
            Console.WriteLine(item);
        }*/

        root.words.spanish[1].value = "asdasdas";

        Console.WriteLine(root.words.spanish[1].value);

        

        var stream = new MemoryStream();

        await JsonSerializer.SerializeAsync(stream, root);
        stream.Position = 0;
        using var reader = new StreamReader(stream);
        var json = await reader.ReadToEndAsync();

        File.WriteAllText(path, json);
        
    }
}

static class Extension
{
    static void Displat<T>(this IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }
    }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
