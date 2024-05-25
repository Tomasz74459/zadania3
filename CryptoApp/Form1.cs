using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CryptoApp
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorithm;
        private byte[] key;
        private byte[] iv;

        public Form1()
        {
            InitializeComponent();
            comboBoxAlgorithm.Items.AddRange(new string[] { "AES", "DES", "TripleDES" });
            comboBoxAlgorithm.SelectedIndex = 0;
        }

        private void buttonGenerateKeys_Click(object sender, EventArgs e)
        {
            switch (comboBoxAlgorithm.SelectedItem.ToString())
            {
                case "AES":
                    algorithm = Aes.Create();
                    break;
                case "DES":
                    algorithm = DES.Create();
                    break;
                case "TripleDES":
                    algorithm = TripleDES.Create();
                    break;
            }

            algorithm.GenerateKey();
            algorithm.GenerateIV();
            key = algorithm.Key;
            iv = algorithm.IV;

            labelKey.Text = $"Key: {BitConverter.ToString(key).Replace("-", "")}";
            labelIV.Text = $"IV: {BitConverter.ToString(iv).Replace("-", "")}";
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            var plaintext = Encoding.UTF8.GetBytes(textBoxPlainText.Text);
            byte[] encrypted;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (var encryptor = algorithm.CreateEncryptor(key, iv))
            {
                encrypted = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
            }

            stopwatch.Stop();
            labelEncryptTime.Text = $"Encrypt Time: {stopwatch.ElapsedMilliseconds} ms";
            textBoxEncryptedAscii.Text = Encoding.UTF8.GetString(encrypted);
            textBoxEncryptedHex.Text = BitConverter.ToString(encrypted).Replace("-", "");
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            var encryptedText = textBoxEncryptedAscii.Text;
            var encryptedBytes = Encoding.UTF8.GetBytes(encryptedText);
            byte[] decrypted;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (var decryptor = algorithm.CreateDecryptor(key, iv))
            {
                decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            }

            stopwatch.Stop();
            labelDecryptTime.Text = $"Decrypt Time: {stopwatch.ElapsedMilliseconds} ms";
            textBoxDecryptedAscii.Text = Encoding.UTF8.GetString(decrypted);
            textBoxDecryptedHex.Text = BitConverter.ToString(decrypted).Replace("-", "");
        }
    }
}