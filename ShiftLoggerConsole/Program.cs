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
            UserModel CurrentUser = new();
            UserModel u = new UserModel() { Username = "string", Password = "string" };
            UserHelper.Login(u);

        }
    }
}