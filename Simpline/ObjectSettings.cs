using System;
using System.Windows.Forms;
using System.Drawing;

namespace Simpline
{
    public partial class ObjectSettings : Form
    {
        SimplineObject SO;
        public ObjectSettings(SimplineObject SO)
        {
            InitializeComponent();
            this.SO = SO;
            textBox1.Text = SO.getX().ToString();
            textBox2.Text = SO.getY().ToString();
            textBox3.Text = SO.Height.ToString();
            textBox4.Text = SO.Width.ToString();
            if(SO is PictureObject)
            {
                textBox6.Text = ((PictureObject)SO).getPicture();
                textBox5.ReadOnly = true;
                textBox7.ReadOnly = true;
            }
            else if(SO is BarcodeObject)
            {
                textBox5.Text = ((BarcodeObject)SO).getCodeValue();
                textBox6.Text = ((BarcodeObject)SO).getCodeType();
                textBox7.ReadOnly = true;
            }
            else if (SO is LabelObject)
            {
                textBox5.Text = ((LabelObject)SO).getLabValue();
                textBox6.Text = ((LabelObject)SO).getLabFont();
                textBox7.Text = ((LabelObject)SO).getLabSize().ToString();
            }
            else
            {
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SO.setX(Convert.ToInt32(textBox1.Text));
                SO.setY(Convert.ToInt32(textBox2.Text));
                if (SO is BarcodeObject)
                {
                    ((BarcodeObject)SO).setNewCode(textBox6.Text, textBox5.Text);
                }
                else if (SO is LabelObject)
                    ((LabelObject)SO).setNewLab(textBox6.Text, textBox5.Text, textBox7.Text);
                else if(SO is PictureObject)
                    ((PictureObject)SO).setPicture(textBox6.Text);
                SO.Height = Convert.ToInt32(textBox3.Text);
                SO.Width = Convert.ToInt32(textBox4.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hiba a beállított paraméterekben: " + ex, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
