using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BusinessX.Entities;
using BusinessX.SLC;
using Newtonsoft.Json;

namespace BusinessX.ProxyService
{
    public class Proxy
    {
        string BaseAddress = "http://192.168.60.193:57694/";

        #region Peticiones POST AND GET
        // Peticiones POST
        public async Task<T> SendPost<T, PostData>(string requestURI, PostData data)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    // URI Absoluto
                    requestURI = BaseAddress + requestURI;
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var JsonData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response = await Client.PostAsync(requestURI, new StringContent(JsonData.ToString(), Encoding.UTF8, "application/json"));
                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }

        // Peticiones GET
        public async Task<T> SendGet<T>(string requesURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requesURI = BaseAddress + requesURI;

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var ResultJSON = await Client.GetStringAsync(requesURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }
        #endregion

        public async Task<Libro> CrearLibroAsync(Libro nuevoLibro)
        {
            return await SendPost<Libro, Libro>("/api/biblioteca/CrearLibro", nuevoLibro);
        }

        public Libro CrearLibro(Libro nuevoLibro)
        {
            Libro Resultado = null;
            Task.Run(async () => Resultado = await CrearLibroAsync(nuevoLibro)).Wait();
            return Resultado;
        }

        public async Task<List<Libro>> FiltrarLibroPorIDGeneroAsync(int ID)
        {
            return await SendGet<List<Libro>>($"/api/biblioteca/FiltrarLibroPorIDGenero/{ID}");
        }

        public List<Libro> FiltrarLibroPorIDGenero(int ID)
        {
            List<Libro> Result = null;
            Task.Run(async () => Result = await FiltrarLibroPorIDGeneroAsync(ID)).Wait();
            return Result;
        }

        public async Task<bool> EliminarLibroAsync(int ID)
        {
            return await SendGet<bool>($"/api/biblioteca/EliminarLibro/{ID}");
        }

        public bool EliminarLibro(int ID)
        {
            bool Resultado = false;
            Task.Run(async () => Resultado = await EliminarLibroAsync(ID)).Wait();
            return Resultado;
        }

        public async Task<List<Libro>> ObtenerTodoLibroAsync()
        {
            return await SendGet<List<Libro>>("/api/biblioteca/ObtenerTodoLibro");
        }

        public List<Libro> ObtenerTodoLibro()
        {
            List<Libro> Resultado = null;
            Task.Run(async () => Resultado = await ObtenerTodoLibroAsync()).Wait();
            return Resultado;
        }

        public async Task<Libro> ObtenerLibroPorIDAsync(int ID)
        {
            return await SendGet<Libro>($"/api/biblioteca/ObtenerLibroPorID/{ID}");
        }

        public Libro ObtenerLibroPorID(int ID)
        {
            Libro Resultado = null;
            Task.Run(async () => Resultado = await ObtenerLibroPorIDAsync(ID)).Wait();
            return Resultado;
        }

        public async Task<bool> ActualizarLibroAsync(int ID, Libro LibroToUpdate)
        {
            return await SendPost<bool, Libro>($"/api/biblioteca/ActualizarLibro/{ID}", LibroToUpdate);
        }

        public bool ActualizarLibro(int ID, Libro LibroToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result = await ActualizarLibroAsync(ID, LibroToUpdate)).Wait();
            return Result;
        }
    }
}
