using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoV.Models
{
    public class crypting
    {

        public string encrypt(string text)
        {
            string encrypted = string.Empty;
            Byte[] encrypt = new UnicodeEncoding().GetBytes(text);
            encrypted = Convert.ToBase64String(encrypt);
            return encrypted;
        }

        public string decrypt(string text)
        {
            string decrypted = string.Empty;
            Byte[] decrypt = Convert.FromBase64String(text);
            decrypted = new UnicodeEncoding().GetString(decrypt);
            return decrypted;
        }


    }
}