using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Simpline
{
    public partial class PictureObject : SimplineObject
    {
        private string pictureFilePath = "";
        Bitmap b;
        public PictureObject(string filePath) : base()
        {
            InitializeComponent();
            pictureFilePath = filePath;
            b = new Bitmap(pictureFilePath);
            this.BackgroundImage = b;
            this.Height = b.Height;
            this.Width = b.Width;
        }
        public string getPicture(){ return pictureFilePath; }
        public void setPicture(string str)
        {
            pictureFilePath = str;
            try
            {
                b = new Bitmap(pictureFilePath);
                this.BackgroundImage = b;
            }
            catch(FileNotFoundException e)
            {
                MessageBox.Show("Hiba a képfájl megnyitása során: " + e, "Hiányzó vagy hibás fájl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
