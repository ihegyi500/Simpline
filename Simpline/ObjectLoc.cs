using System;
using System.Windows.Forms;
using SimplinePrinter;
using System.Drawing;
using ZXing;

namespace Simpline
{
    public partial class ObjectLoc : Form
    {
        SimplineObject bcl;
        BarcodeReader bcr = new BarcodeReader();
        BarcodeWriter bcw = new BarcodeWriter();
        Bitmap bitmap;
        public ObjectLoc(SimplineObject b)
        {
            InitializeComponent();
            textBox1.Text = b.getX().ToString();
            textBox2.Text = b.getY().ToString();
            textBox3.Text = b.getPanHeight().ToString();
            textBox4.Text = b.getPanWidth().ToString();
            textBox5.Text = b.getSimplineObjectString();
            if (b.getCodeType() != "")
            {
                bitmap = new Bitmap(b.BackgroundImage);
                textBox5.Text = bcr.Decode(bitmap).Text;
                textBox6.Text = b.getCodeType();
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
            }
            else if (b.getSimplineObjectString() != "")
            {
                textBox5.Text = b.getSimplineObjectString();
                textBox6.Text = b.getSimplineObjectType();
            }
            else if (b.getPicture() != "")
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
            bcw.Options.PureBarcode = true;
            bcw.Options.Height = bcl.getPanHeight();
            bcw.Options.Width = bcl.getPanWidth();
            if (textBox6.Text == "39 Code" || textBox6.Text == "128 Code" || textBox6.Text == "QR Code")
            {
                bcl.BackgroundImage = null;
                switch (textBox6.Text)
                {
                    case "39 Code":
                        {
                            bcw.Format = BarcodeFormat.CODE_39;
                            bcl.BackgroundImage = bcw.Write(textBox5.Text.ToUpper());
                            break;
                        }
                    case "128 Code":
                        {
                            bcw.Format = BarcodeFormat.CODE_128;
                            bcl.BackgroundImage = bcw.Write(textBox5.Text);
                            break;
                        }
                    case "QR Code":
                        {
                            bcw.Format = BarcodeFormat.QR_CODE;
                            bcl.BackgroundImage = bcw.Write(textBox5.Text);
                            break;
                        }
                }
                bcl.setCodeType(textBox6.Text);
            }
            //bcldict[bcldict.ElementAt(i).Key] = FontType.Text;
            else if(bcl.BackgroundImage == null)
                bcl.setSimplineObject(textBox5.Text, textBox6.Text, bcl.getSimplineObjectSize());
            this.Close();
        }
    }
}
