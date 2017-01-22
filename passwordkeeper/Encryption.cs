using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace passwordkeeper
{
    class Encryption
    {    
        private AesCryptoServiceProvider AES;
        private static string key, IV;
        private string information;
        public Encryption()
        {
        }
        private void set_encryptor()
        {
            
          
            key = "3h8wksgjeuYkqktZps1tS3VHACvtksFP";
            IV = "9DZI4cbcJnkpppg9";
            AES = new AesCryptoServiceProvider();
            AES.BlockSize = 128;
            AES.KeySize = 256;
            AES.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            AES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;
        }
        /// <summary>
        /// turns a string into an encrypted file.
        /// </summary>
        public bool Encrypt_data(string Unencrypt_text, string path)
        {
            try
            {
                set_encryptor();
                FileStream FsEncrypt = new FileStream(path, FileMode.Create, FileAccess.Write);
                ICryptoTransform AES_Encrypt = AES.CreateEncryptor();
                CryptoStream Ocstream = new CryptoStream(FsEncrypt, AES_Encrypt, CryptoStreamMode.Write);
                byte[] stringtobytes = Encoding.ASCII.GetBytes(Unencrypt_text.ToCharArray());
                Ocstream.Write(stringtobytes, 0, stringtobytes.Length);
                Ocstream.Close();
                FsEncrypt.Close();
                return true;

            }
            catch
            {
                Console.WriteLine("tbc");
            }
            return false;
        }
        /// <summary>
        /// Decrypts one file and saves the information within the object.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Decrypt_data(string path)
        {
            set_encryptor();
            FileStream FSInput = new FileStream(path, FileMode.Open, FileAccess.Read);
            ICryptoTransform AES_decrypt = AES.CreateDecryptor();
            CryptoStream cryptostream = new CryptoStream(FSInput, AES_decrypt, CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptostream);
            information = reader.ReadToEnd();
            reader.Close();
            return true;
        }
    }
}
//name = Encoding.ASCII.GetBytes(text.ToCharArray());

/* List < byte > bytes= new List<byte>();
 memory = new MemoryStream(name);
 reader = new StreamReader(memory);
 while(!reader.EndOfStream)
 {
     bytes.Add(Convert.ToByte(reader.Read()));
 }
 string whatsmyname = "";
 whatsmyname += Encoding.ASCII.GetString(bytes.ToArray());*/
