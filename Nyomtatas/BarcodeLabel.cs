using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nyomtatas
{
    public partial class BarcodeLabel : UserControl
    {
        public BarcodeLabel()
        {
            InitializeComponent();
        }

        public void setBarcode(string str, string s, int i)
        {
            label1.Font = new Font(s, i);
            label1.Text = str;
        }

        public string getBarcodeString()
        {
            return this.label1.Text;
        }

        public int getBarcodeSize()
        {
            return Convert.ToInt32(this.label1.Font.Size);
        }

        public string getBarcodeType()
        {
            return this.label1.Font.Name;
        }

        public int getX()
        {
            return Convert.ToInt32(this.Location.X);
        }
        public int getY()
        {
            return Convert.ToInt32(this.Location.Y);
        }

        public int getLabX()
        {
            return Convert.ToInt32(label1.Location.X) + Convert.ToInt32(this.Location.X);
        }
        public int getLabY()
        {
            return Convert.ToInt32(label1.Location.Y) + Convert.ToInt32(this.Location.Y);
        }

        //Középen tartja a vonalkódot a panel méretezése után is
        private void BarcodeLabel_SizeChanged(object sender, EventArgs e)
        {
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = (this.Height - label1.Height) / 2;
            if(this.Width < label1.Width || this.Height < label1.Height)
            {
                this.Width = label1.Width + Convert.ToInt32(label1.Font.Size);
                this.Height = label1.Height + Convert.ToInt32(label1.Font.Size);
            }
        }
        //Betöltéskor középre rakja a vonalkódot
        private void BarcodeLabel_Load(object sender, EventArgs e)
        {
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = (this.Height - label1.Height) / 2;
        }
    }
}
