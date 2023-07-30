using System.Text;
using System.Security.Cryptography;


namespace LDHBlog_JWT.Utility.MD5_
{
    public static class MD5Helpher
    {
        public static string MD5Encrypt32(string pwd)
        {
            string password = "";
            
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            for (int i = 0; i < bytes.Length; i++)
            {
                password += bytes[i].ToString("X");
            }
            return password;
        }
    }
}
