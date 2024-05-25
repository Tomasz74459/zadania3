namespace CryptoApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.textBoxPlainText = new System.Windows.Forms.TextBox();
            this.textBoxEncryptedAscii = new System.Windows.Forms.TextBox();
            this.textBoxEncryptedHex = new System.Windows.Forms.TextBox();
            this.textBoxDecryptedAscii = new System.Windows.Forms.TextBox();
            this.textBoxDecryptedHex = new System.Windows.Forms.TextBox();
            this.buttonGenerateKeys = new System.Windows.Forms.Button();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelIV = new System.Windows.Forms.Label();
            this.labelEncryptTime = new System.Windows.Forms.Label();
            this.labelDecryptTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(12, 12);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(260, 21);
            this.comboBoxAlgorithm.TabIndex = 0;
            // 
            // textBoxPlainText
            // 
            this.textBoxPlainText.Location = new System.Drawing.Point(12, 39);
            this.textBoxPlainText.Multiline = true;
            this.textBoxPlainText.Name = "textBoxPlainText";
            this.textBoxPlainText.Size = new System.Drawing.Size(260, 60);
            this.textBoxPlainText.TabIndex = 1;
            // 
            // textBoxEncryptedAscii
            // 
            this.textBoxEncryptedAscii.Location = new System.Drawing.Point(12, 105);
            this.textBoxEncryptedAscii.Multiline = true;
            this.textBoxEncryptedAscii.Name = "textBoxEncryptedAscii";
            this.textBoxEncryptedAscii.Size = new System.Drawing.Size(260, 60);
            this.textBoxEncryptedAscii.TabIndex = 2;
            // 
            // textBoxEncryptedHex
            // 
            this.textBoxEncryptedHex.Location = new System.Drawing.Point(12, 171);
            this.textBoxEncryptedHex.Multiline = true;
            this.textBoxEncryptedHex.Name = "textBoxEncryptedHex";
            this.textBoxEncryptedHex.Size = new System.Drawing.Size(260, 60);
            this.textBoxEncryptedHex.TabIndex = 3;
            // 
            // textBoxDecryptedAscii
            // 
            this.textBoxDecryptedAscii.Location = new System.Drawing.Point(12, 237);
            this.textBoxDecryptedAscii.Multiline = true;
            this.textBoxDecryptedAscii.Name = "textBoxDecryptedAscii";
            this.textBoxDecryptedAscii.Size = new System.Drawing.Size(260, 60);
            this.textBoxDecryptedAscii.TabIndex = 4;
            // 
            // textBoxDecryptedHex
            // 
            this.textBoxDecryptedHex.Location = new System.Drawing.Point(12, 303);
            this.textBoxDecryptedHex.Multiline = true;
            this.textBoxDecryptedHex.Name = "textBoxDecryptedHex";
            this.textBoxDecryptedHex.Size = new System.Drawing.Size(260, 60);
            this.textBoxDecryptedHex.TabIndex = 5;
            // 
            // buttonGenerateKeys
            // 
            this.buttonGenerateKeys.Location = new System.Drawing.Point(12, 369);
            this.buttonGenerateKeys.Name = "buttonGenerateKeys";
            this.buttonGenerateKeys.Size = new System.Drawing.Size(260, 23);
            this.buttonGenerateKeys.TabIndex = 6;
            this.buttonGenerateKeys.Text = "Generate Keys";
            this.buttonGenerateKeys.UseVisualStyleBackColor = true;
            this.buttonGenerateKeys.Click += new System.EventHandler(this.buttonGenerateKeys_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(12, 398);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(260, 23);
            this.buttonEncrypt.TabIndex = 7;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(12, 427);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(260, 23);
            this.buttonDecrypt.TabIndex = 8;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(12, 453);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(25, 13);
            this.labelKey.TabIndex = 9;
            this.labelKey.Text = "Key";
            // 
            // labelIV
            // 
            this.labelIV.AutoSize = true;
            this.labelIV.Location = new System.Drawing.Point(12, 466);
            this.labelIV.Name = "labelIV";
            this.labelIV.Size = new System.Drawing.Size(17, 13);
            this.labelIV.TabIndex = 10;
            this.labelIV.Text = "IV";
            // 
            // labelEncryptTime
            // 
            this.labelEncryptTime.AutoSize = true;
            this.labelEncryptTime.Location = new System.Drawing.Point(12, 479);
            this.labelEncryptTime.Name = "labelEncryptTime";
            this.labelEncryptTime.Size = new System.Drawing.Size(70, 13);
            this.labelEncryptTime.TabIndex = 11;
            this.labelEncryptTime.Text = "Encrypt Time";
            // 
            // labelDecryptTime
            // 
            this.labelDecryptTime.AutoSize = true;
            this.labelDecryptTime.Location = new System.Drawing.Point(12, 492);
            this.labelDecryptTime.Name = "labelDecryptTime";
            this.labelDecryptTime.Size = new System.Drawing.Size(71, 13);
            this.labelDecryptTime.TabIndex = 12;
            this.labelDecryptTime.Text = "Decrypt Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 511);
            this.Controls.Add(this.labelDecryptTime);
            this.Controls.Add(this.labelEncryptTime);
            this.Controls.Add(this.labelIV);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.buttonGenerateKeys);
            this.Controls.Add(this.textBoxDecryptedHex);
            this.Controls.Add(this.textBoxDecryptedAscii);
            this.Controls.Add(this.textBoxEncryptedHex);
            this.Controls.Add(this.textBoxEncryptedAscii);
            this.Controls.Add(this.textBoxPlainText);
            this.Controls.Add(this.comboBoxAlgorithm);
            this.Name = "Form1";
            this.Text = "CryptoApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.TextBox textBoxPlainText;
        private System.Windows.Forms.TextBox textBoxEncryptedAscii;
        private System.Windows.Forms.TextBox textBoxEncryptedHex;
        private System.Windows.Forms.TextBox textBoxDecryptedAscii;
        private System.Windows.Forms.TextBox textBoxDecryptedHex;
        private System.Windows.Forms.Button buttonGenerateKeys;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelIV;
        private System.Windows.Forms.Label labelEncryptTime;
        private System.Windows.Forms.Label labelDecryptTime;
    }
}