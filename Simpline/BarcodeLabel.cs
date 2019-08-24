using System;
using System.Drawing;
using System.Windows.Forms;
using Simpline;

namespace SimplinePrinter
{
    public partial class BarcodeLabel : UserControl
    {
        private Point MouseDownLocation;
        bool resizeOn = false;

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

        public void setBarcodeString(string String)
        {
            label1.Text = String;
        }


        public int getBarcodeSize()
        {
            return Convert.ToInt32(this.label1.Font.Size);
        }

        public void setBarcodeSize(int Size)
        {
            label1.Font = new Font(label1.Font.FontFamily,Size,label1.Font.Style);
        }

        public string getBarcodeType()
        {
            return this.label1.Font.Name;
        }

        public void setBarcodeType(string String)
        {
            label1.Font = new Font(String, label1.Font.Size);
        }

        public int getX()
        {
            return Convert.ToInt32(this.Location.X);
        }

        public void setX(int X)
        {
            this.Left = X;
        }

        public int getY()
        {
            return Convert.ToInt32(this.Location.Y);
        }

        public void setY(int Y)
        {
            this.Top = Y;
        }

        public int getLabX()
        {
            return Convert.ToInt32(label1.Location.X) + Convert.ToInt32(this.Location.X);
        }

        public void setLabX(int X)
        {
            label1.Left = X;
        }

        public int getLabY()
        {
            return Convert.ToInt32(label1.Location.Y) + Convert.ToInt32(this.Location.Y);
        }

        public void setLabY(int Y)
        {
            label1.Top = Y;
        }

        public int getPanHeight()
        {
            return this.Height;
        }

        public void setPanHeight(int height)
        {
            this.Height = height;
        }
        public int getPanWidth()
        {
            return this.Width;
        }

        public void setPanWidth(int width)
        {
            this.Width = width;
        }


        //Középen tartja a vonalkódot a panel méretezése után is
        private void BarcodeLabel_SizeChanged(object sender, EventArgs e)
        {
            if (this.BackgroundImage != null)
                this.BackgroundImageLayout = ImageLayout.Stretch;
            else
            {
                label1.Left = (this.Width - label1.Width) / 2;
                label1.Top = (this.Height - label1.Height) / 2;
                if (this.Width < label1.Width || this.Height < label1.Height)
                {
                    this.Width = label1.Width + Convert.ToInt32(label1.Font.Size);
                    this.Height = label1.Height + Convert.ToInt32(label1.Font.Size);
                }
            }
        }
        //Betöltéskor középre rakja a vonalkódot
        private void BarcodeLabel_Load(object sender, EventArgs e)
        {
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = (this.Height - label1.Height) / 2;
        }

        public void bcl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        public void bcl_MouseMove(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Left && resizeOn)
            {
                this.Height = this.Top + e.Y;
                this.Width = this.Left + e.X;

            }
            else if (e.Button == MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        public void bcl_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.BackColor == Color.LightGray)
            {
                this.BackColor = Color.Empty;
                if (this.BackgroundImage != null || this.label1.Text != "")
                    this.BorderStyle = BorderStyle.None;
            }
            else
            {
                this.BackColor = Color.LightGray;
                if (this.BackgroundImage != null || this.label1.Text != "")
                    this.BorderStyle = BorderStyle.FixedSingle;
            }
        }
         public void setResize(bool resOn)
        {
            resizeOn = resOn;
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            ObjectLoc ol = new ObjectLoc(this);
            ol.Show();
        }

        private void BarcodeLabel_DoubleClick(object sender, EventArgs e)
        {
            ObjectLoc ol = new ObjectLoc(this);
            ol.Show();
        }
    }
}
