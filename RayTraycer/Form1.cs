using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTraycer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            renderScene.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            Scene scene = new Scene();
            Bitmap image = scene.renderToImage();
            renderScene.Image = image;
        }
    }
}
