using System;
using System.Drawing;
using System.Windows.Forms;

namespace SinusoidApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Paint += Panel1_Paint;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue);
            int scale = 20;
            int offsetX = panel1.Width / 2;
            int offsetY = panel1.Height / 2;

            for (int i = 0; i < panel1.Width; i++)
            {
                float x = (i - offsetX) / (float)scale;
                float y = (float)Math.Sin(x);

                int pixelX = i;
                int pixelY = (int)(offsetY - y * scale);

                g.DrawRectangle(pen, pixelX, pixelY, 1, 1);
            }
        }
    }
}