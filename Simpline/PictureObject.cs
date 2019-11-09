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
            setPicture(filePath);
            this.Height = b.Height;
            this.Width = b.Width;
        }
        public string getPicture(){ return pictureFilePath; }
        public void setPicture(string str)
        {
            try
            {
                b = new Bitmap(str);
                this.BackgroundImage = b;
                pictureFilePath = str;
            }
            catch(FileNotFoundException e)
            {
                MessageBox.Show("Hiba a képfájl megnyitása során: " + e.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
