using ConsoleApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Services.Services.Implements
{
    public class DTOService<T> where T : IDTOInterface
    {
        private readonly string apiAddress = "https://localhost:44372/api/";

        public async Task<IEnumerable<T>> Delete( string controller, int id )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.DeleteAsync($"{controller}/Delete?id={id}");
                responseTask.Wait();

                var result = await responseTask;
                if( result.IsSuccessStatusCode )
                {
                    var lista = GetAll(controller).Result;
                    return lista;
                }
                else
                {
                    return default;
                }
            }
        }

        public async Task<IEnumerable<T>> GetAll( string controller )
        {
            IEnumerable<T> lista;

            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.GetAsync($"{controller}/GetAll");
                responseTask.Wait();

                var result = await responseTask;
                if( result.IsSuccessStatusCode )
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    lista = JsonSerializer.Deserialize<IEnumerable<T>>(readTask.Result, options);

                    return lista;
                }
                else
                {
                    return default;
                }
            }
        }

        public async Task<T> GetById( string controller, int id )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.GetAsync($"{controller}/GetById?id={id}");
                responseTask.Wait();

                var result = await responseTask;
                if( result.IsSuccessStatusCode )
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var model = JsonSerializer.Deserialize<T>(readTask.Result, options);

                    return model;
                }
                else
                {
                    return default;
                }
            }
        }

        public async Task<IEnumerable<T>> Insert( string controller, T model )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var postTask = client.PostAsJsonAsync($"{controller}/Insert", model);
                postTask.Wait();

                var result = await postTask;
                if( result.IsSuccessStatusCode )
                {
                    var resultadoGetAll = GetAll(controller).Result;
                    return resultadoGetAll;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<T> Update( string controller, T model )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var postTask = client.PutAsJsonAsync($"{controller}/Update", model);
                postTask.Wait();

                var result = await postTask;
                if( result.IsSuccessStatusCode )
                {
                    var resultadoGetById = GetById(controller, model.Id).Result;
                    return resultadoGetById;
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
