using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ProductApp.Application.Utils
{
    public class AesEncryption
    {
        public static string AsciiToHex(string asciiString)
        {
            // Windows-1254(Turkish) Code Page-----------------------------------------
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //-------------------------------------------------------------------------

            byte[] bytes = Encoding.GetEncoding(1254).GetBytes(asciiString);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        private static string DataToString(byte[] bytes)
        {
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }
        public static string DecryptToAscii(string data, string key)
        {
            return HexToAscii(DecryptToHex(data, key));
        }
        public static string DecryptToHex(string data, string key)
        {
            string ivStr = "00000000000000000000000000000000";

            RijndaelManaged AES = new RijndaelManaged();

            byte[] ivArr = HexStringToByteArray(ivStr);
            byte[] keyArr = HexStringToByteArray(key);
            byte[] encryptedBytes = HexStringToByteArray(data);


            //set the mode, padding and block size
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;
            AES.KeySize = key.Length * 4;
            AES.BlockSize = 128;
            AES.Key = keyArr;
            AES.IV = ivArr;

            ICryptoTransform decrypto = AES.CreateDecryptor(AES.Key, AES.IV);

            byte[] decryptedData = decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            string ClearData = DataToString(decryptedData);
            AES.Dispose();
            return ClearData;
        }
        public static string Encrypt(string data, string key)
        {
            string ivStr = "00000000000000000000000000000000";

            AesManaged AES = new AesManaged();

            byte[] ivArr = HexStringToByteArray(ivStr);
            byte[] keyArr = HexStringToByteArray(key);
            byte[] plainBytes = HexStringToByteArray(data); ;//Convert.FromBase64String(inputBytes);

            //set the mode, padding and block size
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;
            AES.KeySize = key.Length * 4;
            AES.BlockSize = 128;
            AES.Key = keyArr;
            AES.IV = ivArr;

            ICryptoTransform encrypto = AES.CreateEncryptor(AES.Key, AES.IV);
            byte[] encryptedBytes = encrypto.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            AES.Dispose();
            return ByteArrayToHexString(encryptedBytes);
        }
        public static string EncryptFromAscii(string data, string key)
        {
            return DecryptToHex(AsciiToHex(data), key);
        }
        private static string FormatTurkishCharacter(char Inchar)
        {
            string hex = "";
            char bi = 'Ý';
            char bu = 'Ü';
            char bs = 'Þ';
            char bg = 'Ð';
            char bo = 'Ö';
            char bc = 'Ç';
            char su = 'ü';
            char ss = 'þ';
            char sg = 'ð';
            char so = 'ö';
            char sc = 'ç';
            char sI = 'ý';

            if (Inchar == bu) hex = "DC";
            else if (Inchar == bi) hex = "DD";
            else if (Inchar == bs) hex = "DE";
            else if (Inchar == bg) hex = "D0";
            else if (Inchar == bo) hex = "D6";
            else if (Inchar == bc) hex = "c7";
            else if (Inchar == su) hex = "FC";
            else if (Inchar == ss) hex = "FE";
            else if (Inchar == sg) hex = "F0";
            else if (Inchar == so) hex = "F6";
            else if (Inchar == sc) hex = "E7";
            else if (Inchar == sI) hex = "FD";
            else
                hex = "";

            return hex;
        }
        public static string HexToAscii(string HexString)
        {
            // Windows-1254(Turkish) Code Page-----------------------------------------
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //-------------------------------------------------------------------------

            if (HexString.Length % 2 != 0)
            {
                HexString += "F";
            }
            byte[] bytes = (from x in Enumerable.Range(0, HexString.Length)
                            where x % 2 == 0
                            select Convert.ToByte(HexString.Substring(x, 2), 16)).ToArray();
            return Encoding.GetEncoding(1254).GetString(bytes);
        }
        private static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
