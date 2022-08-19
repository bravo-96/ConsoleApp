using ConsoleApp.Services.Services;
using ConsoleApp.Services.Services.Implements;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
//using Newtonsoft.Json;

namespace ConsoleApp.BO
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("Hello World!");

            #region ejemplo

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



            ColorService cs = new();
            //var colores = colorService.GetAll();

            //foreach( var item in colores )
            //{
            //    Console.WriteLine(item.Nombre);
            //}





            //Console.WriteLine("Ingrese el ID del color a actualizar:");
            //int IdColor = int.Parse(Console.ReadLine());

            //Console.WriteLine("Ingrese el nombre del color");
            //string NombreColor = Console.ReadLine();

            //ColorDTO color = new()
            //{
            //    Id = IdColor,
            //    Nombre = NombreColor
            //};

            //cs.Update(color);




            Console.WriteLine("Ingresar el id del color a eliminar:");
            int id = int.Parse(Console.ReadLine());

            cs.Delete(id);

            var colores = cs.GetAll();

            foreach( var item in colores )
            {
                Console.WriteLine(item.Nombre);
            }




            //var Colores = cs.GetAll();

            //foreach( var item in Colores )
            //{
            //    Console.WriteLine(item.Nombre);
            //}

            //Console.ReadKey();
        }
    }
}