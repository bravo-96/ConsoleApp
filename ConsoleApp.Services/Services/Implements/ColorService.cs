using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsoleApp.Services.Services.Implements
{
    public class ColorService
    {
        private readonly string apiAddress = "https://localhost:44372/api/";

        public void Delete( int id )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.DeleteAsync($"Colores/Delete?id={id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if( result.IsSuccessStatusCode )
                {
                    Console.WriteLine("Se elimino correctamente");
                }
                else
                {
                    Console.WriteLine("Ocurrio un error en la conexion");
                }
            }
        }

        public IEnumerable<ColorDTO> GetAll()
        {
            IEnumerable<ColorDTO> colores;

            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.GetAsync($"Colores/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if( result.IsSuccessStatusCode )
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    colores = JsonSerializer.Deserialize<IEnumerable<ColorDTO>>(readTask.Result, options);

                    return colores;
                }
                else
                {
                    return null;
                }
            }
        }

        public ColorDTO GetById( int id )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.GetAsync($"Colores/GetById/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if( result.IsSuccessStatusCode )
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    ColorDTO color = JsonSerializer.Deserialize<ColorDTO>(readTask.Result, options);

                    return color;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<ColorDTO> Insert( ColorDTO model )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);

                var postTask = client.PostAsJsonAsync("Colores/Insert", model);
                postTask.Wait();

                var result = postTask.Result;
                if( result.IsSuccessStatusCode )
                {
                    return GetAll();
                }
                else
                {
                    return null;
                }
            }
        }

        public ColorDTO Update( ColorDTO model )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);

                var postTask = client.PutAsJsonAsync("Colores/Update", model);
                postTask.Wait();

                var result = postTask.Result;
                if( result.IsSuccessStatusCode )
                {
                    return GetById(model.Id);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
