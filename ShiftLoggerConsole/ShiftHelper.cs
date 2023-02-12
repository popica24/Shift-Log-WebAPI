using ShiftLogger.Models;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ShiftLoggerConsole
{
    public class ShiftHelper
    {
        public static async Task Create(ShiftModel user)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await Client.PostAsync("api/ShiftModels", body);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
        }

        public static async Task Delete(int id)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response =  await Client.DeleteAsync($"api/ShiftModels/{id}");
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);

        }
        public static async Task<IEnumerable<ShiftModel>> GetAll()
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await Client.GetAsync("api/ShiftModels");
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            var data = await response.Content.ReadFromJsonAsync<IEnumerable<ShiftModel>>();
            return data;
           
        }
        public static async Task<ShiftModel> GetById(int id)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await Client.GetAsync("api/ShiftModels");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<IEnumerable<ShiftModel>>();
                return data.First(x => x.ShiftModelId == id);
            }
            else throw new Exception(response.ReasonPhrase);
        }
        public static async Task<ShiftModel> GetByUserId(int id)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await Client.GetAsync("api/ShiftModels");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<IEnumerable<ShiftModel>>();
                return data.First(x => x.UserModelId == id);
            }
            else throw new Exception(response.ReasonPhrase);
        }
        public static async Task Update(int id, ShiftModel shift)
        {
            using HttpClient Client = new();
            Client.BaseAddress = new Uri("https://localhost:7069");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent body = new StringContent(JsonConvert.SerializeObject(shift), Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"api/ShiftModels/{id}", body);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
        }

    }
}
