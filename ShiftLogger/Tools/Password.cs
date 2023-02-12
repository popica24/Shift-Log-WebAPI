using System.Text;
using System.Security.Cryptography;
namespace ShiftLoggerAPI.Tools
{
    public class Password
    {
        public static string Encrypt(string password)
        {
            var standard = SHA256.Create();
            var bytesArray = Encoding.Default.GetBytes(password);
            var encryptedPass = standard.ComputeHash(bytesArray);
            return Convert.ToBase64String(encryptedPass);
        }
    }
}
