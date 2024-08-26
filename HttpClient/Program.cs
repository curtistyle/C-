HttpClient _httpClient = new HttpClient();

await Main();

async Task Main()
{
    try
    {
        using HttpResponseMessage response = 
            await _httpClient.GetAsync("https://rickandmortyapi.com/api/character/21");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseBody);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caght!");
        Console.WriteLine("Message : {0}", e.Message);   
    }
}