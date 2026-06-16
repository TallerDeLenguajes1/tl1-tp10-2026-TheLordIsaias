using System.Text.Json;
using Tareas;

HttpClient clienteHttp = new ();

const string urlApi = "https://jsonplaceholder.typicode.com/todos";
const string archivoSalida = "tareas.json";


HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);
respuesta.EnsureSuccessStatusCode();

string jsonCrudo = await respuesta.Content.ReadAsStringAsync();

List<Tarea>? listaTareas = new ();

listaTareas = JsonSerializer.Deserialize<List<Tarea>>(jsonCrudo);

if(listaTareas != null)
{
    Console.WriteLine("----- Tareas No Completadas -----");
    foreach (var tarea in listaTareas)
    {
        if (!tarea.Completado)
        {
          Console.WriteLine($"ID Usuario: {tarea.UserID}\n-ID Tarea {tarea.IdTarea}\n-Titulo de la Tarea: {tarea.Titulo}\nCompletado: {tarea.Completado}");  
        }
        
    }
    Console.WriteLine("----- Tareas Completadas -----");
    foreach (var tarea in listaTareas)
    {
        if (tarea.Completado)
        {
          Console.WriteLine($"ID Usuario: {tarea.UserID}\n-ID Tarea {tarea.IdTarea}\n-Titulo de la Tarea: {tarea.Titulo}\nCompletado: {tarea.Completado}");  
        }
        
    }
    string jsonString = JsonSerializer.Serialize(listaTareas);
    
    File.WriteAllText(archivoSalida, jsonString);
} else
{
    Console.WriteLine("No se pudo recuperar la lista de Tareas");
}

