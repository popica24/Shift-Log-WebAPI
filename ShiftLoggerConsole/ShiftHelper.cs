using ShiftLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ShiftLoggerConsole
{
    public class ShiftHelper
    {
        public async Task Create(UserModel user)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = ApiHelper.ApiClient.PostAsync("api/Shift", body).Result;
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
        }
    }
}
