using PuppeteerSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;

/*
class Program
{
	static async Task Main(string[] args)
	{
		// URL del protocolo de depuración remota
		string url = "http://localhost:9222/json";

		// Crear un HttpClient para hacer la solicitud
		using (HttpClient client = new HttpClient())
		{
			// Obtener la lista de pestañas abiertas en Chrome
			string response = await client.GetStringAsync(url);
			Console.WriteLine(response);

			Console.ReadLine();
			// Aquí puedes filtrar la pestaña de YouTube Music (dependiendo del URL) y hacer más operaciones
		}
	}
}
*/

class Program
{
	static async Task Main(string[] args)
	{
		// Descargar y lanzar Chrome
		await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
		var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false });

		// Abrir una nueva pestaña y navegar a YouTube Music
		var page = await browser.NewPageAsync();
		await page.GoToAsync("https://music.youtube.com/");

		// Esperar unos segundos para que la página cargue completamente
		await page.WaitForTimeoutAsync(5000);

		// Obtener el título de la canción actual
		try
		{
			var songTitleElement = await page.QuerySelectorAsync("yt-formatted-string.title");
			var artistElement = await page.QuerySelectorAsync("yt-formatted-string.byline");

			// Obtener el texto de los elementos
			string songTitle = await songTitleElement.EvaluateFunctionAsync<string>("el => el.innerText");
			string artist = await artistElement.EvaluateFunctionAsync<string>("el => el.innerText");

			// Mostrar la información de la canción
			Console.WriteLine($"Canción actual: {songTitle} - {artist}");
		}
		catch (Exception ex)
		{
			Console.WriteLine("No se pudo obtener la información de la canción: " + ex.Message);
		}

		// Cerrar el navegador
		await browser.CloseAsync();
	}
}