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
            foreach (var x in UserHelper.GetAll().GetAwaiter().GetResult())
            {
                Console.WriteLine(x.Username);
            }
            Console.WriteLine("before");

            UserHelper.Update(1, new UserModel() {UserModelId = 1, Username = "Schimbat acu", Password = "nou" });


            foreach (var x in UserHelper.GetAll().GetAwaiter().GetResult())
            {
                Console.WriteLine(x.Username);
            }
            Console.WriteLine("after");

        }
    }
}