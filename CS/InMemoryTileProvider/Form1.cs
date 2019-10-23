using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InMemoryTileProvider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageTileDataProvider tileDataProvider = new ImageTileDataProvider();
            tileDataProvider.TileSource = new SimpleTileGenerator();
            this.imageLayer1.DataProvider = tileDataProvider;
        }

        public class SimpleTileGenerator : IImageTileSource
        {
            readonly Font font = new Font("Arial", 10);
            Random rnd = new Random();
            public bool CanDisposeSourceImage => true;
            public string Name => nameof(SimpleTileGenerator);

            public Image GetImage(int x, int y, int level, Size size)
            {
                Bitmap bitmap = new Bitmap(size.Width, size.Height);
                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    gr.Clear(Color.FromArgb(128, rnd.Next(255),
                            rnd.Next(255), rnd.Next(255)));
                    gr.DrawString(string.Format("{0} {1} {2}", x, y, level),
                            font, Brushes.Black, new PointF(5, 5));
                }
                return bitmap;
            }
        }
    }
}
