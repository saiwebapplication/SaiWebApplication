using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Business
{
    public static class Helper
    {
        public static string Encrypt(this string clearText)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(clearText);
            string EncryptionKey = (string)(new AppSettingsReader()).GetValue("HashKey", typeof(String));
            //---- Encrypt text.
            string encryptedValue = Convert.ToBase64String(MachineKey.Protect(plaintextBytes, EncryptionKey));
            //--- URL encode to make encrypted value URL compatible.
            encryptedValue = HttpUtility.UrlEncode(encryptedValue);
            return encryptedValue;
        }

        public static string Decrypt(this string cipherText)
        {
            var bytes = Convert.FromBase64String(cipherText);
            string EncryptionKey = (string)(new AppSettingsReader()).GetValue("HashKey", typeof(String));
            var output = MachineKey.Unprotect(bytes, EncryptionKey);
            return Encoding.UTF8.GetString(output);
        }
    }
}
