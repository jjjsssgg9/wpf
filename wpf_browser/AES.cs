using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPF_0815
{
    class AESEncrypt
    {
        private SHA256Managed sha256Managed = new SHA256Managed();
        private RijndaelManaged aes = new RijndaelManaged();

        public AESEncrypt()
        {
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
        }

        //AES_256 암호화
        public byte[] AESEncrypt256(byte[] encryptData, String password)
        {
            var salt = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(password.Length.ToString()));//솔트 생성

            var PBKDF2Key = new Rfc2898DeriveBytes(password, salt, 65535, HashAlgorithmName.SHA256);
            var secretKey = PBKDF2Key.GetBytes(aes.KeySize / 8);//key(bit)를 byte 사이즈로바꾼다. -> state 단위로 만드는듯 
            var iv = PBKDF2Key.GetBytes(aes.BlockSize / 8);//연산을 위해 state단위로.


            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(secretKey, iv), CryptoStreamMode.Write))//인코딩
                {
                    cs.Write(encryptData, 0, encryptData.Length);
                }
                xBuff = ms.ToArray();
            }
            return xBuff;
        }

        //AES_256 = 암호화와 동일.
        public byte[] AESDecrypt256(byte[] decryptData, String password)
        {
            var salt = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(password.Length.ToString()));

            //PBKDF2(Password-Based Key Derivation Function)
            //반복은 65535번
            var PBKDF2Key = new Rfc2898DeriveBytes(password, salt, 65535, HashAlgorithmName.SHA256);
            var secretKey = PBKDF2Key.GetBytes(aes.KeySize / 8);
            var iv = PBKDF2Key.GetBytes(aes.BlockSize / 8);

            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(secretKey, iv), CryptoStreamMode.Write))
                {
                    cs.Write(decryptData, 0, decryptData.Length);
                }
                xBuff = ms.ToArray();
            }
            return xBuff;
        }

    }
 
}