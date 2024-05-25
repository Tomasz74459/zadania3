using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HybridEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: HybridEncryption [generate-keys|encrypt|decrypt] [inputFilePath] [outputFilePath] [optional: keyFilePath]");
                return;
            }

            string command = args[0];
            string inputFilePath = args[1];
            string outputFilePath = args[2];
            string keyFilePath = args.Length > 3 ? args[3] : null;

            try
            {
                switch (command.ToLower())
                {
                    case "generate-keys":
                        GenerateKeys(outputFilePath);
                        break;
                    case "encrypt":
                        if (keyFilePath == null)
                        {
                            Console.WriteLine("Key file path is required for encryption.");
                            return;
                        }
                        EncryptFile(inputFilePath, outputFilePath, keyFilePath);
                        break;
                    case "decrypt":
                        if (keyFilePath == null)
                        {
                            Console.WriteLine("Key file path is required for decryption.");
                            return;
                        }
                        DecryptFile(inputFilePath, outputFilePath, keyFilePath);
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void GenerateKeys(string outputFilePath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    string publicKeyPath = Path.Combine(outputFilePath, "myKeys_PublicKey.xml");
                    string privateKeyPath = Path.Combine(outputFilePath, "myKeys_PrivateKey.xml");
        
                    File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
                    File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
        
                    Console.WriteLine("Keys generated and saved to files.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while generating keys: {ex.Message}");
                }
            }
        }

        static void EncryptFile(string inputFilePath, string outputFilePath, string publicKeyFilePath)
        {
            string publicKey = File.ReadAllText(publicKeyFilePath);
            byte[] dataToEncrypt = File.ReadAllBytes(inputFilePath);

            using (var aes = new AesCryptoServiceProvider())
            {
                aes.GenerateKey();
                aes.GenerateIV();

                byte[] encryptedData;
                using (var encryptor = aes.CreateEncryptor())
                {
                    encryptedData = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
                }

                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);
                    byte[] encryptedKey = rsa.Encrypt(aes.Key, false);
                    byte[] encryptedIv = rsa.Encrypt(aes.IV, false);

                    using (var outputStream = new FileStream(outputFilePath, FileMode.Create))
                    {
                        outputStream.Write(BitConverter.GetBytes(encryptedKey.Length), 0, sizeof(int));
                        outputStream.Write(BitConverter.GetBytes(encryptedIv.Length), 0, sizeof(int));
                        outputStream.Write(encryptedKey, 0, encryptedKey.Length);
                        outputStream.Write(encryptedIv, 0, encryptedIv.Length);
                        outputStream.Write(encryptedData, 0, encryptedData.Length);
                    }
                }
            }
            Console.WriteLine("File encrypted and saved to output file.");
        }

        static void DecryptFile(string inputFilePath, string outputFilePath, string privateKeyFilePath)
        {
            string privateKey = File.ReadAllText(privateKeyFilePath);
            byte[] encryptedFileData = File.ReadAllBytes(inputFilePath);

            using (var inputStream = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] lengthBuffer = new byte[sizeof(int)];
                inputStream.Read(lengthBuffer, 0, sizeof(int));
                int keyLength = BitConverter.ToInt32(lengthBuffer, 0);

                inputStream.Read(lengthBuffer, 0, sizeof(int));
                int ivLength = BitConverter.ToInt32(lengthBuffer, 0);

                byte[] encryptedKey = new byte[keyLength];
                inputStream.Read(encryptedKey, 0, keyLength);

                byte[] encryptedIv = new byte[ivLength];
                inputStream.Read(encryptedIv, 0, ivLength);

                byte[] encryptedData = new byte[encryptedFileData.Length - sizeof(int) * 2 - keyLength - ivLength];
                inputStream.Read(encryptedData, 0, encryptedData.Length);

                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    byte[] key = rsa.Decrypt(encryptedKey, false);
                    byte[] iv = rsa.Decrypt(encryptedIv, false);

                    using (var aes = new AesCryptoServiceProvider())
                    {
                        aes.Key = key;
                        aes.IV = iv;

                        byte[] decryptedData;
                        using (var decryptor = aes.CreateDecryptor())
                        {
                            decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                        }

                        File.WriteAllBytes(outputFilePath, decryptedData);
                    }
                }
            }
            Console.WriteLine("File decrypted and saved to output file.");
        }
    }
}