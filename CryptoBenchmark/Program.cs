using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptoBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testujemy różne algorytmy
            TestAlgorithm("AES (CSP) 128 bit", new AesCryptoServiceProvider { KeySize = 128 });
            TestAlgorithm("AES (CSP) 256 bit", new AesCryptoServiceProvider { KeySize = 256 });
            TestAlgorithm("AES Managed 128 bit", new AesManaged { KeySize = 128 });
            TestAlgorithm("AES Managed 256 bit", new AesManaged { KeySize = 256 });
            TestAlgorithm("Rijndael Managed 128 bit", new RijndaelManaged { KeySize = 128 });
            TestAlgorithm("Rijndael Managed 256 bit", new RijndaelManaged { KeySize = 256 });
            TestAlgorithm("DES 56 bit", DES.Create());
            TestAlgorithm("3DES 168 bit", TripleDES.Create());
        }

        static void TestAlgorithm(string name, SymmetricAlgorithm algorithm)
        {
            algorithm.GenerateKey();
            algorithm.GenerateIV();

            var plaintext = Encoding.UTF8.GetBytes("This is a test message to be encrypted and decrypted.");
            byte[] encrypted;
            byte[] decrypted;

            // Pomiar czasu szyfrowania
            var encryptWatch = Stopwatch.StartNew();
            using (var encryptor = algorithm.CreateEncryptor())
            {
                encrypted = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
            }
            encryptWatch.Stop();

            // Pomiar czasu deszyfrowania
            var decryptWatch = Stopwatch.StartNew();
            using (var decryptor = algorithm.CreateDecryptor())
            {
                decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
            }
            decryptWatch.Stop();

            // Wyświetlanie wyników
            Console.WriteLine($"{name}");
            Console.WriteLine($"Sekund/blok: {encryptWatch.Elapsed.TotalSeconds:F6} (szyfrowanie), {decryptWatch.Elapsed.TotalSeconds:F6} (deszyfrowanie)");
            Console.WriteLine($"Bajtów/sekundę (RAM): {plaintext.Length / encryptWatch.Elapsed.TotalSeconds:F2} (szyfrowanie), {encrypted.Length / decryptWatch.Elapsed.TotalSeconds:F2} (deszyfrowanie)");
            Console.WriteLine();

            // Test z dyskiem twardym
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, plaintext);

            // Odczyt z dysku i szyfrowanie
            var hddEncryptWatch = Stopwatch.StartNew();
            var fileBytes = File.ReadAllBytes(tempFilePath);
            using (var encryptor = algorithm.CreateEncryptor())
            {
                encrypted = encryptor.TransformFinalBlock(fileBytes, 0, fileBytes.Length);
            }
            hddEncryptWatch.Stop();

            // Zapis zaszyfrowanych danych na dysk
            File.WriteAllBytes(tempFilePath, encrypted);

            // Odczyt z dysku i deszyfrowanie
            var hddDecryptWatch = Stopwatch.StartNew();
            fileBytes = File.ReadAllBytes(tempFilePath);
            using (var decryptor = algorithm.CreateDecryptor())
            {
                decrypted = decryptor.TransformFinalBlock(fileBytes, 0, fileBytes.Length);
            }
            hddDecryptWatch.Stop();

            // Wyświetlanie wyników
            Console.WriteLine($"{name} (HDD)");
            Console.WriteLine($"Sekund/blok: {hddEncryptWatch.Elapsed.TotalSeconds:F6} (szyfrowanie), {hddDecryptWatch.Elapsed.TotalSeconds:F6} (deszyfrowanie)");
            Console.WriteLine($"Bajtów/sekundę (HDD): {fileBytes.Length / hddEncryptWatch.Elapsed.TotalSeconds:F2} (szyfrowanie), {fileBytes.Length / hddDecryptWatch.Elapsed.TotalSeconds:F2} (deszyfrowanie)");
            Console.WriteLine();

            // Czyszczenie pliku tymczasowego
            File.Delete(tempFilePath);
        }
    }
}