using System;
using System.Windows.Forms;

namespace Simpline
{
    public partial class ObjectLoc : Form
    {
        Control ctrl;
        public ObjectLoc(Control c)
        {
            InitializeComponent();
            textBox1.Text = c.Location.X.ToString();
            textBox2.Text = c.Location.Y.ToString();
            textBox3.Text = c.Height.ToString();
            textBox4.Text = c.Width.ToString();
            ctrl = c;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ctrl.Left = Convert.ToInt32(textBox1.Text);
            ctrl.Top = Convert.ToInt32(textBox2.Text);
            ctrl.Height = Convert.ToInt32(textBox3.Text);
            ctrl.Width = Convert.ToInt32(textBox4.Text);
            this.Close();
        }
    }
}
