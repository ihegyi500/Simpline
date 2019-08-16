using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Drawing.Imaging;
using SimplinePrinter;

namespace Simpline
{
    public partial class Simpline : Form
    {
        List<BarcodeLabel> bclList = new List<BarcodeLabel>();
        bool resizeOn = false;
        int bclcounter = 0;

        public Simpline()
        {
            InitializeComponent();
        }

        private void BarcodePrinter_Load(object sender, EventArgs e)
        {
            //Vonalkódtípuslista feltöltése
            BarcodeTypeCbx.Items.Add("Free 3 of 9 Extended");
            BarcodeTypeCbx.Items.Add("Code 128");
            BarcodeTypeCbx.SelectedIndex = 0;
            //Betűtípuslista feltöltése
            using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
            {
                FontFamily[] fontFamilies = fontsCollection.Families;
                foreach (FontFamily font in fontFamilies)
                {
                    TextFontCbx.Items.Add(font.Name);
                }
            }
            TextFontCbx.SelectedIndex = 1;
            //Nyomtatólista feltöltése
            PrinterSettings settings = new PrinterSettings();
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                PrintersList.Items.Add(printer);
            }
            this.PrintersList.SelectedItem = settings.PrinterName;
            //Papírméretlista feltöltése
            foreach (PaperSize ps in settings.PaperSizes)
            {
                 PaperSizeList.Items.Add(ps.Kind.ToString());
            }
            PaperSizeList.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddFunc(BarcodeTypeCbx, BarcodeTextTbx, BarcodeSizeTbx);
        }

        private void SetBarcodeButton_Click(object sender, EventArgs e)
        {
            SetFunc(BarcodeTypeCbx, BarcodeTextTbx, BarcodeSizeTbx);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    bclList.RemoveAt(i);
                }
            }
            foreach(Control c in panel1.Controls)
            {
                if(c.BackColor == Color.LightGray)
                {
                    panel1.Controls.Remove(c);
                }
            }
        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {
            if (ActiveControl.BackColor == Color.LightGray)
            {
                resizeOn = false;
                ActiveControl.BackColor = Color.Empty;
            }
            else
            {
                resizeOn = true;
                ActiveControl.BackColor = Color.LightGray;
            }
            foreach(BarcodeLabel b in bclList)
            {
                b.setResize(resizeOn);
            }
        }

        private void CopyPasteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    bclcounter++;
                    BarcodeLabel barcodeLabel = new BarcodeLabel();
                    barcodeLabel.Name = "Bcl" + bclcounter;
                    bclList.Add(barcodeLabel);
                    bclList[bclList.Count-1].setBarcode(bclList[i].getBarcodeString(), bclList[i].getBarcodeType(), bclList[i].getBarcodeSize());
                    barcodeLabel.Size = bclList[i].Size;
                    if (bclList[i].BorderStyle == BorderStyle.FixedSingle)
                        barcodeLabel.BorderStyle = BorderStyle.FixedSingle;
                    panel1.Controls.Add(barcodeLabel);
                }
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            GraphicMaker gm = new GraphicMaker();
            gm.Printing(bclList, PrintersList, PaperSizeList);
        }

        private void SavePictureButton_Click(object sender, EventArgs e)
        {
            GraphicMaker gm = new GraphicMaker();
            FileMaker fmk = new FileMaker(resizeOn);
            fmk.SaveTxt(bclList);
        }

        private void AddTextButton_Click(object sender, EventArgs e)
        {
            AddFunc(TextFontCbx, TextTbx, TextSizeTbx);
        }

        private void SetTextButton_Click(object sender, EventArgs e)
        {
            SetFunc(TextFontCbx, TextTbx, TextSizeTbx);
        }

        private void RectChbx_CheckStateChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    if (RectChbx.CheckState == CheckState.Checked)
                        bclList[i].BorderStyle = BorderStyle.FixedSingle;
                    else
                        bclList[i].BorderStyle = BorderStyle.None;
                }
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            GraphicMaker gm = new GraphicMaker();
            FileMaker fmk = new FileMaker(resizeOn);
            fmk.ExportPng(gm.GetBitmap());
        }

        private void LoadPictureButton_Click(object sender, EventArgs e)
        {
            FileMaker fmk = new FileMaker(resizeOn);
            fmk.LoadTxt(panel1, bclList);
        }

        private void PrintPropLabel_Click(object sender, EventArgs e)
        {
            GraphicMaker gm = new GraphicMaker();
            gm.PrintDialog();
        }

        private void RectButton_Click(object sender, EventArgs e)
        {
            BarcodeLabel bcl = new BarcodeLabel();
            bcl.setBarcodeString("");
            bcl.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(bcl);
            bclList.Add(bcl);
        }

        private void AddFunc(ComboBox FontType, TextBox value, TextBox size)
        {
            bclcounter++;
            BarcodeLabel barcodeLabel = new BarcodeLabel();
            if (FontType.SelectedItem.ToString() == "Free 3 of 9 Extended")
                barcodeLabel.setBarcode("*" + value.Text + "*", FontType.Text, Convert.ToInt32(size.Text));
            else
                barcodeLabel.setBarcode(value.Text, FontType.Text, Convert.ToInt32(size.Text));
            barcodeLabel.Name = "Bcl" + bclcounter;
            panel1.Controls.Add(barcodeLabel);
            bclList.Add(barcodeLabel);
        }

        private void SetFunc(ComboBox FontType, TextBox value, TextBox size)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    if (FontType.SelectedItem.ToString() == "Free 3 of 9 Extended")
                        bclList[i].setBarcode("*" + value.Text + "*", FontType.Text, Convert.ToInt32(size.Text));
                    else
                        bclList[i].setBarcode(value.Text, FontType.Text, Convert.ToInt32(size.Text));
                }
            }

        }

        private void PrintersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrinterSettings settings = new PrinterSettings();
            settings.PrinterName = this.PrintersList.SelectedItem.ToString();
            //Papírméretlista feltöltése
            PaperSizeList.Items.Clear();
            foreach (PaperSize ps in settings.PaperSizes)
            {
                PaperSizeList.Items.Add(ps.Kind.ToString());
            }
        }

        private void PaperSizeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrinterSettings settings = new PrinterSettings();
            settings.PrinterName = PrintersList.SelectedItem.ToString();
            foreach (PaperSize ps in settings.PaperSizes)
            {
                if(ps.Kind.ToString() == PaperSizeList.SelectedItem.ToString())
                {
                    panel1.Height = ps.Height;
                    panel1.Width = ps.Width;
                }
            }
        }

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            panel2.Left = panel1.Right + 25;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            X.Text = e.X.ToString();
            Y.Text = e.Y.ToString();
        }
    }
}
