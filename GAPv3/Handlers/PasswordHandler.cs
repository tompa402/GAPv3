using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GAPv3.Handlers
{
    public static class PasswordHandler
    {
        public static string EncryptPassword(string password)
        {
            string pass = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            pass = Convert.ToBase64String(encode);
            return pass;
        }

        public static string DecryptPassword(string encPassword)
        {
            string decryptedPass = string.Empty;
            UTF8Encoding encodePass = new UTF8Encoding();
            Decoder Decode = encodePass.GetDecoder();
            byte[] decodeByte = Convert.FromBase64String(encPassword);
            int charCount = Decode.GetCharCount(decodeByte, 0, decodeByte.Length);
            char[] decodedChar = new char[charCount];
            Decode.GetChars(decodeByte, 0, decodeByte.Length, decodedChar, 0);
            decryptedPass = new String(decodedChar);
            return decryptedPass;
        }
    }
}