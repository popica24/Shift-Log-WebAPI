using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShiftLogger.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
namespace ShiftLoggerConsole
{
    public static class UserHelper
    {
        public static async Task Create(UserModel entity)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent body = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/User", body);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
        }

        public static async Task Delete(int id)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Client.DeleteAsync($"api/User/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<IEnumerable<UserModel>> GetAll()
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await Client.GetAsync("api/User");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<IEnumerable<UserModel>>();
                return data;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public static async Task<UserModel> GetById(int id)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await Client.GetAsync("api/User");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<IEnumerable<UserModel>>();
                return data.First(x => x.UserModelId == id);
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public static async Task Update(int id, UserModel user)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"api/User/{id}", body);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
        }
        public static async Task<UserModel> Login(UserModel user)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = Client.PostAsync("api/User/login", body).Result;
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            var x =  JsonConvert.DeserializeObject<UserModel>(response.Content.ToString());
            return null;
        }
    }
}