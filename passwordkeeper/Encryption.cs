using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace passwordkeeper
{
    public class Encryption  : IDisposable
    {    
        private AesCryptoServiceProvider AES;
        private string information;
        public Encryption()
        {
            AES = new AesCryptoServiceProvider();
            AES.BlockSize = 128;
            AES.KeySize = 256;
            AES.IV = ASCIIEncoding.ASCII.GetBytes("9DZI4cbcJnkpppg9"); // figure out a better method
            AES.Key = ASCIIEncoding.ASCII.GetBytes("3h8wksgjeuYkqktZps1tS3VHACvtksFP"); // figure out a better method
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
        public string Decrypt_data(string path)
        {
            try
            {
                FileStream FSInput = new FileStream(path, FileMode.Open, FileAccess.Read);
                ICryptoTransform AES_decrypt = AES.CreateDecryptor();
                CryptoStream cryptostream = new CryptoStream(FSInput, AES_decrypt, CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptostream);
                information = reader.ReadToEnd();
                reader.Close();
            }
            catch(Exception e)
            {
                information = e.Message;
            }
            return information;
        }

        public void Dispose()
        {
            AES = null;
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
