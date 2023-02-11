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
    public static class ApiCaller
    {
        public static async Task<IEnumerable<UserModel>> LoadUsers()
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
    }
}
