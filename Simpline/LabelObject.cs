using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simpline
{
    public partial class LabelObject : SimplineObject
    {
        public LabelObject(string font, string value, string size) : base()
        {
            InitializeComponent();
            setNewLab(font, value, size);
            Lab.Left = (this.Width - Lab.Width) / 2;
            Lab.Top = (this.Height - Lab.Height) / 2;
        }
        public string getLabValue() { return Lab.Text; }
        public string getLabFont() { return Lab.Font.Name; }
        public float getLabSize() { return Lab.Font.Size; }
        public void setNewLab(string font, string value, string size)
        {
            setLabFont(font);
            setLabValue(value);
            setLabSize(size);
        }
        public void setLabValue(string value) { Lab.Text = value; }
        public void setLabFont(string font)
        {
            try
            {
                Lab.Font = new Font(font, Lab.Font.Size);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Hibás betűtípus: " + e, "Hibaüzenet", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void setLabSize(string size) {
            try
            {
                Lab.Font = new Font(Lab.Font.Name,Convert.ToInt32(size));
            }
            catch (FormatException e)
            {
                MessageBox.Show("Hibás betűméret: " + e, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void setLabX(int X) { Lab.Left = X; }
        public void setLabY(int Y) { Lab.Top = Y; }
        public int getLabX() { return Lab.Left; }
        public int getLabY() { return Lab.Top; }
        private void Lab_DoubleClick(object sender, EventArgs e)
        {
            ObjectSettings ol = new ObjectSettings(this);
            ol.Show();
        }
        protected override void SimplineObject_SizeChanged(object sender, EventArgs e)
        {
            Lab.Left = (this.Width - Lab.Width) / 2;
            Lab.Top = (this.Height - Lab.Height) / 2;
            if (this.Width < Lab.Width || this.Height < Lab.Height)
            {
                this.Width = Lab.Width;
                this.Height = Lab.Height;
            }
        }
        private void Lab_MouseMove(object sender, MouseEventArgs e)
        {
            base.SimplineObject_MouseMove(sender, e);
        }
        private void Lab_MouseClick(object sender, MouseEventArgs e)
        {
            base.SimplineObject_MouseClick(sender, e);
        }
    }
}
