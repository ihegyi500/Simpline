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
            bcl.Left = Convert.ToInt32(textBox1.Text);
            bcl.Top = Convert.ToInt32(textBox2.Text);
            bcl.Height = Convert.ToInt32(textBox3.Text);
            bcl.Width = Convert.ToInt32(textBox4.Text);
            BarcodeWriter w = new BarcodeWriter();
            w.Options.PureBarcode = true;
            w.Options.Height = bcl.getPanHeight();
            w.Options.Width = bcl.getPanWidth();
            if (textBox6.Text == "Free 3 of 9 Extended" || textBox6.Text == "Code 128" || textBox6.Text == "QR Code")
            {
                bcl.BackgroundImage = null;
                switch (textBox6.Text)
                {
                    case "Free 3 of 9 Extended":
                        {
                            w.Format = BarcodeFormat.CODE_39;
                            bcl.BackgroundImage = w.Write(textBox5.Text.ToUpper());
                            break;
                        }
                    case "Code 128":
                        {
                            w.Format = BarcodeFormat.CODE_128;
                            bcl.BackgroundImage = w.Write(textBox5.Text);
                            break;
                        }
                    case "QR Code":
                        {
                            w.Format = BarcodeFormat.QR_CODE;
                            bcl.BackgroundImage = w.Write(textBox5.Text);
                            break;
                        }
                }
                bcl.setCodeType(textBox6.Text);
            }
            //bcldict[bcldict.ElementAt(i).Key] = FontType.Text;
            else if(bcl.BackgroundImage == null)
                bcl.setBarcodeLabel(textBox5.Text, textBox6.Text, bcl.getBarcodeLabelSize());
            this.Close();
        }
    }
}
