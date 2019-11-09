using System;
using System.Windows.Forms;
using ZXing;

namespace Simpline
{
    public partial class BarcodeObject : SimplineObject
    {
        string codeType, value;
        BarcodeWriter w;
        public BarcodeObject(string codeType, string value) : base()
        {
            InitializeComponent();
            w = new BarcodeWriter();
            this.codeType = codeType;
            BarcodeValidator(value);
            this.value = value;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public string getCodeType(){ return codeType; }
        public string getCodeValue() { return value; }
        public void setCodeType(string codeType)
        {
            if (codeType == "39 Code" || codeType == "128 Code" || codeType == "QR Code")
                this.codeType = codeType;
            else
                throw new System.ArgumentException("Hibás vonalkód/QR kód típus!", "codeType");
            BarcodeValidator(value);
        }
        public void setCodeValue(string value)
        {
            BarcodeValidator(value);
            this.value = value;
        }
        public void setNewCode(string codeType, string value)
        {
            if (codeType == "39 Code" || codeType == "128 Code" || codeType == "QR Code")
                this.codeType = codeType;
            else
                throw new System.ArgumentException("Hibás vonalkód/QR kód típus!", "codeType");
            BarcodeValidator(value);
            this.value = value;
        }
        private void BarcodeValidator(string value)
        {
            w.Options.PureBarcode = true;
            w.Options.Height = this.Height;
            w.Options.Width = this.Width;
            switch (this.codeType)
            {
                case "39 Code":
                    {
                        try
                        {
                            w.Format = BarcodeFormat.CODE_39;
                            BackgroundImage = w.Write(value.ToUpper());
                        }
                        catch(ArgumentException e)
                        {
                            throw new ArgumentException("Hiba a vonalkód létrehozása során:\n" + e.Message + "\nEllenőrizd a vonalkód tartalmát!");
                        }
                        break;
                    }
                case "128 Code":
                    {
                        try
                        {
                            w.Format = BarcodeFormat.CODE_128;
                            BackgroundImage = w.Write(value);
                        }
                        catch (ArgumentException e)
                        {
                            throw new ArgumentException("Hiba a vonalkód létrehozása során:\n" + e.Message + "\nEllenőrizd a vonalkód tartalmát!");
                        }
                        break;
                    }
                case "QR Code":
                    {
                        w.Format = BarcodeFormat.QR_CODE;
                        BackgroundImage = w.Write(value);
                        break;
                    }
            }
        }
    }
}
