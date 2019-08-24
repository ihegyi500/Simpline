﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Text;
using SimplinePrinter;
using System.Linq;
using ZXing;

namespace Simpline
{
    public partial class Simpline : Form
    {
        Dictionary<BarcodeLabel, string> bcldict = new Dictionary<BarcodeLabel, string>();
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
            BarcodeTypeCbx.Items.Add("QR Code");
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
            AddFunc(BarcodeTypeCbx, BarcodeTextTbx, "");
            SendRectToBack();
        }

        private void SetBarcodeButton_Click(object sender, EventArgs e)
        {
            SetFunc(BarcodeTypeCbx, BarcodeTextTbx, "");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bcldict.Count; i++)
            {
                if (bcldict.ElementAt(i).Key.BackColor == Color.LightGray)
                {
                    panel1.Controls.Remove(bcldict.ElementAt(i).Key);
                    bcldict.Remove(bcldict.ElementAt(i).Key);
                    i -= 1;
                    bclcounter--;
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
            foreach(BarcodeLabel b in bcldict.Keys)
            {
                b.setResize(resizeOn);
            }
        }

        private void CopyPasteButton_Click(object sender, EventArgs e)
        {
            foreach (BarcodeLabel b in panel1.Controls)
            {
                if(b.BackColor == Color.LightGray)
                {
                    BarcodeLabel bcl = new BarcodeLabel();
                    bcl.BackgroundImage = b.BackgroundImage;
                    bcl.Height = b.Height;
                    bcl.Width = b.Width;
                    panel1.Controls.Add(bcl);
                    bcldict.Add(bcl, bcldict[b]);
                }
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            GraphicMaker gm = new GraphicMaker();
            gm.Printing(bcldict, PrintersList, 3,(short)Convert.ToInt32(CopiesTbx.Text));
        }

        private void SavePictureButton_Click(object sender, EventArgs e)
        {
            FileMaker fmk = new FileMaker();
            fmk.SaveTxt(bcldict);
        }

        private void AddTextButton_Click(object sender, EventArgs e)
        {
            AddFunc(TextFontCbx, TextTbx, TextSizeTbx.Text);
            SendRectToBack();
        }

        private void SetTextButton_Click(object sender, EventArgs e)
        {
            SetFunc(TextFontCbx, TextTbx, TextSizeTbx.Text);
        }

        private void RectChbx_CheckStateChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < bcldict.Count; i++)
            {
                if (bcldict.ElementAt(i).Key.BackColor == Color.LightGray)
                {
                    if (RectChbx.CheckState == CheckState.Checked)
                        bcldict.ElementAt(i).Key.BorderStyle = BorderStyle.FixedSingle;
                    else
                        bcldict.ElementAt(i).Key.BorderStyle = BorderStyle.None;
                }
            }
        }

        private void OpenPicButton_Click(object sender, EventArgs e)
        {
            FileMaker fmk = new FileMaker();
            fmk.AddPicture(panel1, bcldict);
        }

        private void LoadPictureButton_Click(object sender, EventArgs e)
        {
            FileMaker fmk = new FileMaker();
            fmk.LoadTxt(panel1, bcldict);
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
            bcldict.Add(bcl, "");
            SendRectToBack();
        }

        private void SendRectToBack()
        {
            foreach (BarcodeLabel b in panel1.Controls)
            {
                if (b.getBarcodeString() == "" && b.BorderStyle == BorderStyle.FixedSingle && b.BackgroundImage == null)
                    b.SendToBack();
                else
                    b.BringToFront();
            }
        }

        private void AddFunc(ComboBox FontType, TextBox value, string size)
        {
            bclcounter++;
            BarcodeLabel barcodeLabel = new BarcodeLabel();
            BarcodeWriter w = new BarcodeWriter();
            w.Options.PureBarcode = true;
            w.Options.Height = barcodeLabel.getPanHeight();
            w.Options.Width = barcodeLabel.getPanWidth();

            switch (FontType.SelectedItem.ToString())
            {
                case "Free 3 of 9 Extended":
                    {
                        w.Format = BarcodeFormat.CODE_39;
                        barcodeLabel.BackgroundImage = w.Write(value.Text.ToUpper());
                        break;
                    }
                case "Code 128":
                    {
                        w.Format = BarcodeFormat.CODE_128;
                        barcodeLabel.BackgroundImage = w.Write(value.Text);
                        break;
                    }
                case "QR Code":
                    {
                        w.Format = BarcodeFormat.QR_CODE;
                        barcodeLabel.BackgroundImage = w.Write(value.Text);
                        break;
                    }
                default:
                    {
                        barcodeLabel.setBarcode(value.Text, FontType.Text, Convert.ToInt32(size));
                        break;
                    }
            }
            barcodeLabel.Name = "Bcl" + bclcounter;
            panel1.Controls.Add(barcodeLabel);
            bcldict.Add(barcodeLabel, FontType.Text);
        }

        private void SetFunc(ComboBox FontType, TextBox value, string size)
        {
            BarcodeWriter w = new BarcodeWriter();
            for (int i = 0; i < bcldict.Count; i++)
            {
                if (bcldict.ElementAt(i).Key.BackColor == Color.LightGray)
                {
                    bcldict.ElementAt(i).Key.BackgroundImage = null;
                    w.Options.PureBarcode = true;
                    w.Options.Height = bcldict.ElementAt(i).Key.getPanHeight();
                    w.Options.Width = bcldict.ElementAt(i).Key.getPanWidth();

                    switch (FontType.SelectedItem.ToString())
                    {
                        case "Free 3 of 9 Extended":
                            {
                                w.Format = BarcodeFormat.CODE_39;
                                bcldict.ElementAt(i).Key.BackgroundImage = w.Write(value.Text.ToUpper());
                                break;
                            }
                        case "Code 128":
                            {
                                w.Format = BarcodeFormat.CODE_128;
                                bcldict.ElementAt(i).Key.BackgroundImage = w.Write(value.Text);
                                break;
                            }
                        case "QR Code":
                            {
                                w.Format = BarcodeFormat.QR_CODE;
                                bcldict.ElementAt(i).Key.BackgroundImage = w.Write(value.Text);
                                break;
                            }
                        default:
                            {
                                bcldict.ElementAt(i).Key.setBarcode(value.Text, FontType.Text, Convert.ToInt32(size));
                                break;
                            }
                    }
                    bcldict[bcldict.ElementAt(i).Key] = FontType.Text;
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
            PaperSizeList.SelectedIndex = 0;
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

        private void PrintPreviewLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GraphicMaker gm = new GraphicMaker();
            gm.Printing(bcldict, PrintersList, 1, (short)Convert.ToInt32(CopiesTbx.Text));
        }

        private void PageSetupLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GraphicMaker gm = new GraphicMaker();
            gm.Printing(bcldict, PrintersList, 2, (short)Convert.ToInt32(CopiesTbx.Text));
        }
    }
}
