﻿using System;
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
                PrintersList.Items.Add(printer.ToString());
            }
            this.PrintersList.SelectedItem = settings.PrinterName;
            //Papírméretlista feltöltése
            PaperSizeList.DataSource = Enum.GetValues(typeof(PaperKind));
            PaperSizeList.SelectedIndex = 9;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddFunc(BarcodeTypeCbx, BarcodeTextTbx, BarcodeSizeTbx);
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
            AddFunc(TextFontCbx, TextTbx, TextSizeTbx);
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
    }
}
