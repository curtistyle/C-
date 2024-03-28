using System.Text.Json;

var url = "https://jsonplaceholder.typicode.com/todos";

var urls = new string[10].Select((u, index) => url + "/" + (index + 1)).ToList();

var downloadTask = urls.ConvertAll(u => Download(u));

var jsons = await Task.WhenAll(downloadTask);

var posts = jsons.ToList().ConvertAll(j => ToObject(j));

posts.ForEach(p => Console.WriteLine(p.title));

async Task<string> Download(string url)
{
    using var httpClient = new HttpClient();

    return await httpClient.GetStringAsync(url);
}

Post ToObject(string content)
{
    return JsonSerializer.Deserialize<Post>(content);
}

public class Post
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}