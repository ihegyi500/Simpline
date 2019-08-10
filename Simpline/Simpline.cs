using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using SimplinePrinter;
using System.Drawing.Text;
using System.IO;
using System.Drawing.Imaging;

namespace Simpline
{
    public partial class Simpline : Form
    {
        private Point MouseDownLocation;
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
            //Nyomtatólista feltöltése
            PrinterSettings settings = new PrinterSettings();
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                PrintersList.Items.Add(printer.ToString());
            }
            this.PrintersList.SelectedItem = settings.PrinterName;
        }

        private void bcl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void bcl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && resizeOn)
            {
                ActiveControl.Height = ActiveControl.Top + e.Y;
                ActiveControl.Width = ActiveControl.Left + e.X;

            }
            else if (e.Button == MouseButtons.Left)
            {
                ActiveControl.Left = e.X + ActiveControl.Left - MouseDownLocation.X;
                ActiveControl.Top = e.Y + ActiveControl.Top - MouseDownLocation.Y;
            }
        }

        private void bcl_MouseClick(object sender, MouseEventArgs e)
        {
            if(ActiveControl.BackColor == Color.LightGray)
                ActiveControl.BackColor = Color.Empty;
            else
                ActiveControl.BackColor = Color.LightGray;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bclcounter++;
            BarcodeLabel barcodeLabel = new BarcodeLabel();
            if(BarcodeTypeCbx.SelectedItem.ToString() == "Free 3 of 9 Extended")
                barcodeLabel.setBarcode("*" + BarcodeTextTbx.Text+ "*", BarcodeTypeCbx.Text, Convert.ToInt32(BarcodeSizeTbx.Text));
            else
                barcodeLabel.setBarcode(BarcodeTextTbx.Text, BarcodeTypeCbx.Text, Convert.ToInt32(BarcodeSizeTbx.Text));
            barcodeLabel.Name = "Bcl" + bclcounter;
            panel1.Controls.Add(barcodeLabel);
            bclList.Add(barcodeLabel);
            barcodeLabel.MouseDown += bcl_MouseDown;
            barcodeLabel.MouseMove += bcl_MouseMove;
            barcodeLabel.MouseClick += bcl_MouseClick;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    panel1.Controls.Remove(bclList[i]);
                    bclList.RemoveAt(i);
                }
            }
        }

        private void SetBarcodeButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    if (BarcodeTypeCbx.SelectedItem.ToString() == "Free 3 of 9 Extended")
                        bclList[i].setBarcode("*" + BarcodeTextTbx.Text + "*", BarcodeTypeCbx.Text, Convert.ToInt32(BarcodeSizeTbx.Text));
                    else
                        bclList[i].setBarcode(BarcodeTextTbx.Text, BarcodeTypeCbx.Text, Convert.ToInt32(BarcodeSizeTbx.Text));
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
                    barcodeLabel.MouseDown += bcl_MouseDown;
                    barcodeLabel.MouseMove += bcl_MouseMove;
                    barcodeLabel.MouseClick += bcl_MouseClick;
                    bclList[bclList.Count-1].setBarcode(bclList[i].getBarcodeString(), bclList[i].getBarcodeType(), bclList[i].getBarcodeSize());
                    barcodeLabel.Size = bclList[i].Size;
                    panel1.Controls.Add(barcodeLabel);
                }
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            GraphicMaker gm = new GraphicMaker(bclList, PrintersList);
            gm.Printing();
        }

        private void SavePictureButton_Click(object sender, EventArgs e)
        {
            GraphicMaker gm = new GraphicMaker(bclList, PrintersList);
            FileMaker fmk = new FileMaker();
            fmk.SaveTxt(bclList);
        }

        private void SetTextButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    if (TextFontCbx.SelectedItem.ToString() == "Free 3 of 9 Extended")
                        bclList[i].setBarcode("*" + TextTbx.Text + "*", TextFontCbx.Text, Convert.ToInt32(TextSizeTbx.Text));
                    else
                        bclList[i].setBarcode(TextTbx.Text, TextFontCbx.Text, Convert.ToInt32(TextSizeTbx.Text));
                }
            }
        }

        private void AddTextButton_Click(object sender, EventArgs e)
        {
            bclcounter++;
            BarcodeLabel barcodeLabel = new BarcodeLabel();
            if (TextFontCbx.SelectedItem.ToString() == "Free 3 of 9 Extended")
                barcodeLabel.setBarcode("*" + TextTbx.Text + "*", TextFontCbx.Text, Convert.ToInt32(TextSizeTbx.Text));
            else
                barcodeLabel.setBarcode(TextTbx.Text, TextFontCbx.Text, Convert.ToInt32(TextSizeTbx.Text));
            barcodeLabel.Name = "Bcl" + bclcounter;
            panel1.Controls.Add(barcodeLabel);
            bclList.Add(barcodeLabel);
            barcodeLabel.MouseDown += bcl_MouseDown;
            barcodeLabel.MouseMove += bcl_MouseMove;
            barcodeLabel.MouseClick += bcl_MouseClick;
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
            GraphicMaker gm = new GraphicMaker(bclList, PrintersList);
            FileMaker fmk = new FileMaker();
            fmk.ExportPng(gm.GetBitmap());
        }
    }
}
