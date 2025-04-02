using System.IO;
using System.Security.Cryptography;

namespace symncrypt
{
    internal class Util
    {
        internal static void Encrypt(SymmetricAlgorithm alg, string inputFile, string outputTile)
        {
            FileStream fileStream = new(outputTile, FileMode.Create);
            CryptoStream cs = new CryptoStream(fileStream, alg.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsInput = new(inputFile, FileMode.Open);
            byte[] buffer = new byte[1024];
            int readBytes = 0;
            while ((readBytes = fsInput.Read(buffer, 0, buffer.Length)) > 0)
            {
                cs.Write(buffer, 0, readBytes);
            }
            cs.Close();
            fsInput.Close();
        }
        internal static void Decrypt(SymmetricAlgorithm alg, string inputFile, string outputTile)
        {
            FileStream fileStream = new(inputFile, FileMode.Open);
            CryptoStream cs = new CryptoStream(fileStream, alg.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOutput = new(outputTile, FileMode.Create);
            byte[] buffer = new byte[1024];
            int readBytes = 0;
            while ((readBytes = cs.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsOutput.Write(buffer, 0, readBytes);
            }
            cs.Close();
            fsOutput.Close();
        }
    }
}