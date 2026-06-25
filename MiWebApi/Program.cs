using System.Text.Json;
using Dolares;

HttpClient clienteHttp = new ();

const string urlApi = "https://dolarapi.com/v1/dolares";
const string archivoSalida = "dolar.json";


HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);
respuesta.EnsureSuccessStatusCode();

string jsonCrudo = await respuesta.Content.ReadAsStringAsync();

List<Dolar>? listaDolar = new ();

listaDolar = JsonSerializer.Deserialize<List<Dolar>>(jsonCrudo);

if(listaDolar != null)
{
    foreach (var dolar in listaDolar)
    {
        Console.WriteLine($"Tipo de Moneda: {dolar.moneda}. Casa: {dolar.casa}. Nombre: {dolar.nombre}. Compra: ${dolar.compra}. Venta: ${dolar.venta}. Fecha de Actualizacion: {dolar.fechaActualizacion}");
    }
    string jsonString = JsonSerializer.Serialize(listaDolar);
    
    File.WriteAllText(archivoSalida, jsonString);
} else
{
    Console.WriteLine("No se pudo recuperar la lista de Usuarios");
}