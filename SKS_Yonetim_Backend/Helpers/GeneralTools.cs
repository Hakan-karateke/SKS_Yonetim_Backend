using System.Security.Cryptography;
using System.Text;

namespace SKS_Yonetim_Backend.Helpers
{
    public class GeneralTools
    {
        public static string ComputeSha1Password(string password)
        {
            try
            {
                byte[] temp = SHA1.HashData(Encoding.UTF8.GetBytes(password));

                StringBuilder passwordSh1 = new StringBuilder();
                for (int i = 0; i < temp.Length; i++)
                {
                    passwordSh1.Append(temp[i].ToString("x2"));
                }

                return passwordSh1.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Helpers bolumunde hata",ex);
            }
        }
        public static string GenerateRandomPassword()
        {
            int length = 5;

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static string CaptchaAnswer()
        {
            const string chars = "abcdefghıjklmnöprstuvyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var captchaCode = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());

            return captchaCode;
        }

        
    }
}