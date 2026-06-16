using System.Text.Json;
using Usuarios;

HttpClient clienteHttp = new ();

const string urlApi = "https://jsonplaceholder.typicode.com/users";
const string archivoSalida = "usuarios.json";


HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);
respuesta.EnsureSuccessStatusCode();

string jsonCrudo = await respuesta.Content.ReadAsStringAsync();

List<Usuario>? listaUsuarios = new ();

listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonCrudo);

if(listaUsuarios != null)
{
    List<Usuario> primeros = listaUsuarios.Take(5).ToList();
    foreach (var usuario in primeros)
    {
        Console.WriteLine($"Nombre: {usuario.name}\nCorreo Electronico: {usuario.email}\nDomicilio: {usuario.address.street}");
    }
    string jsonString = JsonSerializer.Serialize(listaUsuarios);
    
    File.WriteAllText(archivoSalida, jsonString);
} else
{
    Console.WriteLine("No se pudo recuperar la lista de Tareas");
}