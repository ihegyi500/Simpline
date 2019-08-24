using System;
using System.Windows.Forms;
using SimplinePrinter;

namespace Simpline
{
    public partial class ObjectLoc : Form
    {
        BarcodeLabel bcl;
        public ObjectLoc(BarcodeLabel b)
        {
            InitializeComponent();
            textBox1.Text = b.getX().ToString();
            textBox2.Text = b.getY().ToString();
            textBox3.Text = b.getPanHeight().ToString();
            textBox4.Text = b.getPanWidth().ToString();
            textBox5.Text = b.getBarcodeString();
            textBox6.Text = b.getBarcodeType();
            bcl = b;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bcl.Left = Convert.ToInt32(textBox1.Text);
            bcl.Top = Convert.ToInt32(textBox2.Text);
            bcl.Height = Convert.ToInt32(textBox3.Text);
            bcl.Width = Convert.ToInt32(textBox4.Text);
            bcl.setBarcodeString(textBox5.Text);
            bcl.setBarcodeType(textBox6.Text);
            this.Close();
        }
    }
}
