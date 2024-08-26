using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

// ver archivo HttpClient

Run();

void Run()
{
    string url = "https://jsonplaceholder.typicode.com/posts";
    
    // post : Persona
    Persona oPersona = new Persona() { Nombre = "Curtis", Edad = 22};
    Solicitud<Persona> oSolicitud = new Solicitud<Persona>(oPersona);
    string resultado = oSolicitud.Solicitar(url);
    // post : Carro
    Carro oCarro = new Carro() { Marca = "Fiat", Modelo = "600"};
    Solicitud<Carro> oSolicitud2 = new Solicitud<Carro>(oCarro);
    string resultado2 = oSolicitud2.Solicitar(url);

}

class Solicitud<T>
{
    T _data;

    // ctor
    public Solicitud(T data)
    {
        this._data = data;
    }

    public string Solicitar(string url)
    {
        string result = "";

        WebRequest oRequest = WebRequest.Create(url);
        oRequest.Method = "post";
        oRequest.ContentType = "application/json;charset=UTF-8";

        using(var oSW = new StreamWriter(oRequest.GetRequestStream()))
        {
            string json = JsonSerializer.Serialize(oSW);

            oSW.Write(json);
            oSW.Flush();
            oSW.Close();
        }
    
        WebResponse webResponse = oRequest.GetResponse();
        using (var oSR = new StreamReader(webResponse.GetResponseStream()))
        {
            result = oSR.ReadToEnd().Trim();
        }

        return result;
    }


}

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

class Carro
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
}

