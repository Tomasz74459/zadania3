using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DESBruteforce
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexCiphertext = "23c73dde8faedd91413fb5dd1d7e066d70425ed1e058d0e2f7e9e43501824a95446baf28f6ce7ffd3c544f40efb5c80f235de1321214328781a6ea0c0c4c7b74be3968ca1ffb8455";
            byte[] ciphertext = HexStringToByteArray(hexCiphertext);

            string knownPlaintext = "test";
            byte[] knownPlaintextBytes = Encoding.ASCII.GetBytes(knownPlaintext);

            Stopwatch stopwatch = Stopwatch.StartNew();
            byte[] decrypted = null;
            string keyFound = null;

            for (byte b1 = 0; b1 <= 255; b1++)
            {
                for (byte b2 = 0; b2 <= 255; b2++)
                {
                    byte[] key = new byte[] { b1, b2, 0x35, 0x35, 0x35, 0x35, 0x35, 0x35 };

                    using (DES des = DES.Create())
                    {
                        des.Key = key;
                        des.IV = new byte[8];

                        using (ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV))
                        {
                            try
                            {
                                decrypted = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                                if (decrypted.Take(knownPlaintextBytes.Length).SequenceEqual(knownPlaintextBytes))
                                {
                                    keyFound = BitConverter.ToString(key).Replace("-", "");
                                    Console.WriteLine($"Key found: {keyFound}");
                                    Console.WriteLine($"Decrypted text: {Encoding.ASCII.GetString(decrypted)}");
                                    stopwatch.Stop();
                                    Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
                                    return;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Key not found.");
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        }

        static byte[] HexStringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}