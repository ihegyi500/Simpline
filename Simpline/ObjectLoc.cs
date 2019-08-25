using System;
using System.Windows.Forms;
using SimplinePrinter;
using System.Drawing;
using ZXing;
using System.Collections.Generic;
using System.Drawing.Text;

namespace Simpline
{
    public partial class ObjectLoc : Form
    {
        BarcodeLabel bcl;
        BarcodeReader bcr = new BarcodeReader();
        BarcodeWriter bcw = new BarcodeWriter();
        Bitmap bitmap;
        public ObjectLoc(BarcodeLabel b)
        {
            InitializeComponent();
            textBox1.Text = b.getX().ToString();
            textBox2.Text = b.getY().ToString();
            textBox3.Text = b.getPanHeight().ToString();
            textBox4.Text = b.getPanWidth().ToString();
            textBox5.Text = b.getBarcodeLabelString();
            if (b.getCodeType() != null)
            {
                bitmap = new Bitmap(b.BackgroundImage);
                textBox5.Text = bcr.Decode(bitmap).Text;
                textBox6.Text = b.getCodeType();
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
            }
            else if (b.getBarcodeLabelString() != "")
            {
                textBox5.Text = b.getBarcodeLabelString();
                textBox6.Text = b.getBarcodeLabelType();
            }
            else if (b.getPicture() != null)
            {
                textBox6.Text = b.getPicture();
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
            }
            bcl = b;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<string> fonts = new List<string>();
            InstalledFontCollection ifc = new InstalledFontCollection();
            foreach (FontFamily ff in ifc.Families)
            {
                fonts.Add(ff.Name);
            }
            bcw.Options.PureBarcode = true;
            bcl.Left = Convert.ToInt32(textBox1.Text);
            bcl.Top = Convert.ToInt32(textBox2.Text);
            bcl.Height = Convert.ToInt32(textBox3.Text);
            bcl.Width = Convert.ToInt32(textBox4.Text);
            if (textBox6.Text != "" && textBox6.Text != "Free 3 of 9 Extended" ||
                textBox6.Text != "Code 128" || textBox6.Text != "QR Code")
            {
                if(fonts.Contains(textBox6.Text) == true)
                {
                    bcl.setBarcodeLabelType(textBox6.Text);
                    bcl.setBarcodeLabelString(textBox5.Text);
                }
            }
            this.Close();
        }
    }
}
