using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftLogger.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ShiftLoggerConsole
{
    public static class UserHelper
    {
        public static async Task Create(UserModel entity)
        {
        
                HttpContent body = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                var response = ApiHelper.ApiClient.PostAsync("api/User", body).Result;
                if (!response.IsSuccessStatusCode)
                {
                 throw new Exception(response.ReasonPhrase);
                }

        }

        public static void Delete(int id)
        {
            var respose = ApiHelper.ApiClient.DeleteAsync($"api/User/{id}").Result;
            if (!respose.IsSuccessStatusCode)
            {
                throw new Exception(respose.ReasonPhrase);
            }
        }

        public static async Task<IEnumerable<UserModel>> GetAll()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("api/User"))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<IEnumerable<UserModel>>();
                    return data;
                }
                else throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<UserModel> GetById(int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("api/User"))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<IEnumerable<UserModel>>();
                    return data.First(x => x.UserModelId == id);
                }
                else throw new Exception(response.ReasonPhrase);
            }
        }

        public static void Update(int id,UserModel user)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = ApiHelper.ApiClient.PutAsync($"api/User/{id}",body).Result;
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);

        }
    }
}
