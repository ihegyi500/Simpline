using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Simpline
{
    public partial class BarcodeObject : SimplineObject
    {
        string codeType, value;
        BarcodeWriter w = new BarcodeWriter();
        public BarcodeObject(string codeType, string value) : base()
        {
            InitializeComponent();
            this.codeType = codeType;
            this.value = value;
            w.Options.PureBarcode = true;
            w.Options.Height = this.Height;
            w.Options.Width = this.Width;
            BarcodeValidator();
        }
        public string getCodeType(){ return codeType; }
        public string getCodeValue() { return value; }
        public void setCodeType(string codeType)
        {
            this.codeType = codeType;
            BarcodeValidator();
        }
        public void setCodeValue(string value)
        {
            this.value = value;
            BarcodeValidator();
        }
        public void setNewCode(string codeType, string value)
        {
            this.codeType = codeType;
            this.value = value;
            BarcodeValidator();
        }
        private void BarcodeValidator()
        {
            switch (this.codeType)
            {
                case "39 Code":
                    {
                        w.Format = BarcodeFormat.CODE_39;
                        BackgroundImage = w.Write("*" + this.value.ToUpper() + "*");
                        break;
                    }
                case "128 Code":
                    {
                        w.Format = BarcodeFormat.CODE_128;
                        BackgroundImage = w.Write(this.value);
                        break;
                    }
                case "QR Code":
                    {
                        w.Format = BarcodeFormat.QR_CODE;
                        BackgroundImage = w.Write(this.value);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Hiba! Érvénytelen vonalkód/QR-kód típus!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
    }
}
