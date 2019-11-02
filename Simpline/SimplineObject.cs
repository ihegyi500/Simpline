using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simpline
{
    public partial class SimplineObject : UserControl
    {
        protected Point MouseDownLocation;
        protected bool resizeOn = false;
        public SimplineObject()
        {
            InitializeComponent();

        }
        public int getX() { return Convert.ToInt32(this.Location.X); }
        public int getY() { return Convert.ToInt32(this.Location.Y); }
        public void setX(int X) { this.Left = X; }
        public void setY(int Y) { this.Top = Y; }
        protected virtual void SimplineObject_SizeChanged(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        //Egérpozíció elmentése
        protected void SimplineObject_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        //Objektum méretezése/mozgatása
        protected void SimplineObject_MouseMove(object sender, MouseEventArgs e)
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
        //Objektum kijelölése
        protected virtual void SimplineObject_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Name.Contains("*"))
            {
                this.BorderStyle = BorderStyle.None;
                this. Name = this.Name.Replace("*", "");
            }
            else
            {
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Name = this.Name = this.Name + "*";
            }
        }
        public void setResize(bool resOn)
        {
            resizeOn = resOn;
        }
        private void SimplineObject_DoubleClick(object sender, EventArgs e)
        {
            ObjectLoc ol = new ObjectLoc(this);
            ol.Show();
        }
    }
}
