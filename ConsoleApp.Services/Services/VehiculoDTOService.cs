using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Services.Services
{
    public class VehiculoDTOService
    {
        private readonly string apiAddress = "https://localhost:44372/api/";

        public async Task<IEnumerable<VehiculoDTO>> Delete( int id )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.DeleteAsync($"Vehiculo/Delete?id={id}");
                responseTask.Wait();

                var result = await responseTask;
                if( result.IsSuccessStatusCode )
                {
                    var lista = GetAll().Result;
                    return lista;
                }
                else
                {
                    return default;
                }
            }
        }

        public async Task<IEnumerable<VehiculoDTO>> GetAll()
        {
            IEnumerable<VehiculoDTO> lista;

            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.GetAsync($"Vehiculo/GetAll");
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

                    lista = JsonSerializer.Deserialize<IEnumerable<VehiculoDTO>>(readTask.Result, options);

                    return lista;
                }
                else
                {
                    return default;
                }
            }
        }

        public async Task<VehiculoDTO> GetById( int id )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var responseTask = client.GetAsync($"Vehiculo/GetById?id={id}");
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

                    var model = JsonSerializer.Deserialize<VehiculoDTO>(readTask.Result, options);

                    return model;
                }
                else
                {
                    return default;
                }
            }
        }

        public async Task<IEnumerable<VehiculoDTO>> Insert( VehiculoDTO model )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);

                var postTask = client.PostAsJsonAsync($"Vehiculo/Insert", model);
                postTask.Wait();

                var result = await postTask;
                if( result.IsSuccessStatusCode )
                {
                    var resultadoGetAll = GetAll().Result;
                    return resultadoGetAll;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<VehiculoDTO> Update( VehiculoDTO model )
        {
            using( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(apiAddress);
                var postTask = client.PutAsJsonAsync($"Vehiculo/Update", model);
                postTask.Wait();

                var result = await postTask;
                if( result.IsSuccessStatusCode )
                {
                    var resultadoGetById = GetById(model.Id).Result;
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
