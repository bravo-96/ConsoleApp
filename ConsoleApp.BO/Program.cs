using ConsoleApp.Services.Services;
using ConsoleApp.Services.Services.Implements;
using System;
//using Newtonsoft.Json;

namespace ConsoleApp.BO
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("Hello World!");

            #region ejemploMarian

            //ColorDTO pais = new()
            //{
            //    Id = 0,
            //    Nombre = "Blanco"
            //};

            //using( var client = new HttpClient() )
            //{
            //    client.BaseAddress = new Uri("https://localhost:44372/api/");

            //    //HTTP POST
            //    var postTask = client.PostAsJsonAsync<ColorDTO>("Colores/insert", pais);
            //    postTask.Wait();

            //    var result = postTask.Result;
            //    if( result.IsSuccessStatusCode )
            //    {
            //        Console.WriteLine("Te felicito, viva peron");
            //    }
            //}


            //IEnumerable<ColorDTO> colores;

            //using( var client = new HttpClient() )
            //{
            //    client.BaseAddress = new Uri("https://localhost:44372/api/");
            //    //HTTP GET
            //    //int id = 1;
            //    var responseTask = client.GetAsync($"Colores/GetAll");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if( result.IsSuccessStatusCode )
            //    {
            //        var readTask = result.Content.ReadAsStringAsync();
            //        readTask.Wait();

            //        var options = new JsonSerializerOptions
            //        {
            //            PropertyNameCaseInsensitive = true
            //        };

            //        colores = JsonSerializer.Deserialize<IEnumerable<ColorDTO>>(readTask.Result, options);

            //        foreach( var item in colores )
            //        {
            //            Console.WriteLine(item.Nombre);
            //        }
            //    }
            //}

            #endregion



            DTOService<PaisDTO> paisService = new();

            var res = paisService.GetById("pais", 3).Result;

            Console.WriteLine(res.Nombre);
        }
    }
}