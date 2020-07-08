using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectConstructiveFractals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region memebers

        IConstructiveFractal _fractal = null;
        Bitmap _bitmap = null;

        #endregion

        #region private

        void RenderFractal(Graphics g)
        {
            const int cShift = 16;
            PointF start = new PointF(cShift, pictureBox1.Height / 2 + cShift);
            PointF end = new PointF(pictureBox1.Width - cShift, pictureBox1.Height / 2 + cShift);
            int N = 5;
            IEnumerable<PointF> points = _fractal.Build(N, start, end);

            g.DrawLines(Pens.Black, points.ToArray());
        }

        void Render()
        {
            if (_bitmap == null)
                return;

            Graphics g = Graphics.FromImage(_bitmap);
            g.Clear(Color.White);

            // отрисвока фрактала
            RenderFractal(g);

            pictureBox1.Image = _bitmap;
        }

        Bitmap CreateBackground(int width, int height)
        {
            return (width > 0 || height > 0) ? new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb) : null;
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            _bitmap = CreateBackground(pictureBox1.Width, pictureBox1.Height);
            _fractal = new KochDirectFractal();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            _bitmap = CreateBackground(pictureBox1.Width, pictureBox1.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

