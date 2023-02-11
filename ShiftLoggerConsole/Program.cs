using ShiftLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftLoggerConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            ApiHelper.InitializeClient();
            var users = ApiCaller.LoadUsers().GetAwaiter().GetResult();

            foreach (var x in users)
            {
                Console.WriteLine(x.Username);
            }
        }
    }
}