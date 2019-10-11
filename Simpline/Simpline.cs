using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Text;
using SimplinePrinter;
using ZXing;

namespace Simpline
{
    public partial class Simpline : Form
    {
        List<SimplineObject> bclList = new List<SimplineObject>();
        bool resizeOn = false;
        int bclcounter = 0;
        GraphicMaker gm;

        public Simpline()
        {
            InitializeComponent();
        }

        private void BarcodePrinter_Load(object sender, EventArgs e)
        {
            //Vonalkódlista feltöltése
            BarcodeTypeCbx.Items.AddRange(new string[] { "39 Code", "128 Code", "QR Code" });
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
            TextFontCbx.SelectedIndex = 0;
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
            //Címkelista feltöltése
            LabelList.Items.AddRange(new string[] { "Volvo", "Renault", "Alapértelmezett" });
            LabelList.SelectedIndex = 0;

        }

        //Új vonalkódobjektum hozzáadása
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddFunc(BarcodeTypeCbx, BarcodeTextTbx, "");
            BringToFrontSendToBack();
        }

        //Vonalkód beállítása
        private void SetBarcodeButton_Click(object sender, EventArgs e)
        {
            SetFunc(BarcodeTypeCbx, BarcodeTextTbx, "");
        }

        //Kijelölt objektumok törlése
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    panel1.Controls.Remove(bclList[i]);
                    bclList.RemoveAt(i);
                    i -= 1;
                    bclcounter--;
                }
            }
        }

        //Méretező mód
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
            foreach(SimplineObject b in bclList)
            {
                b.setResize(resizeOn);
            }
        }

        //Kijelölt objektumok klónozása
        private void CopyPasteButton_Click(object sender, EventArgs e)
        {
            foreach (SimplineObject b in panel1.Controls)
            {
                if(b.BackColor == Color.LightGray)
                {
                    SimplineObject bcl = new SimplineObject();
                    bcl.BackgroundImage = b.BackgroundImage;
                    bcl.Height = b.Height;
                    bcl.Width = b.Width;
                    panel1.Controls.Add(bcl);
                    bclList.Add(bcl);
                    if (b.BackgroundImage != null && b.getCodeType() == "")
                        bcl.setPicture(b.getPicture());
                    else if (b.BackgroundImage != null)
                        bcl.setCodeType(b.getCodeType());
                    else
                    {
                        bcl.setSimplineObject(b.getSimplineObjectString(), b.getSimplineObjectType(), b.getSimplineObjectSize());
                    }
                }
            }
        }

        //Nyomtatás
        private void PrintButton_Click(object sender, EventArgs e)
        {
            gm = new GraphicMaker();
            gm.Printing(bclList, PrintersList, 3,(short)Convert.ToInt32(CopiesTbx.Text));
        }

        //Fájl mentése
        private void SavePictureButton_Click(object sender, EventArgs e)
        {
            FileMaker fmk = new FileMaker(panel1, FileName, bclList);
            fmk.SaveTxt();
        }

        //Szöveges objektum hozzáadása
        private void AddTextButton_Click(object sender, EventArgs e)
        {
            AddFunc(TextFontCbx, TextTbx, TextSizeTbx.Text);
            BringToFrontSendToBack();
        }

        //Szöveges objektum szerkesztése
        private void SetTextButton_Click(object sender, EventArgs e)
        {
            SetFunc(TextFontCbx, TextTbx, TextSizeTbx.Text);
        }

        //Kép betöltése
        private void OpenPicButton_Click(object sender, EventArgs e)
        {
            FileMaker fmk = new FileMaker(panel1, FileName, bclList);
            fmk.AddPicture();
        }

        //Fájl megnyitása
        private void LoadPictureButton_Click(object sender, EventArgs e)
        {
            FileMaker fmk = new FileMaker(panel1, FileName, bclList);
            fmk.LoadTxt();
        }

        //Nyomtatótulajdonságok
        private void PrintPropLabel_Click(object sender, EventArgs e)
        {
            gm = new GraphicMaker();
            gm.PrintDialog();
        }

        //Új keret hozzáadása
        private void RectButton_Click(object sender, EventArgs e)
        {
            SimplineObject bcl = new SimplineObject();
            bcl.setSimplineObjectString("");
            bcl.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(bcl);
            bclList.Add(bcl);
            BringToFrontSendToBack();
        }

        //Keretobjektumok automatikus hátraküldése
        private void BringToFrontSendToBack()
        {
            foreach (SimplineObject b in panel1.Controls)
            {
                if (b.getSimplineObjectString() == "" && b.BorderStyle == BorderStyle.FixedSingle && b.BackgroundImage == null)
                    b.SendToBack();
                else
                    b.BringToFront();
            }
        }

        //Általános metódus objektum hozzáadásához
        private void AddFunc(ComboBox FontType, TextBox value, string size)
        {
            bclcounter++;
            SimplineObject SimplineObject = new SimplineObject();
            BarcodeWriter w = new BarcodeWriter();
            w.Options.PureBarcode = true;
            w.Options.Height = SimplineObject.getPanHeight();
            w.Options.Width = SimplineObject.getPanWidth();
            switch (FontType.SelectedItem.ToString())
            {
                case "39 Code":
                    {
                        w.Format = BarcodeFormat.CODE_39;
                        SimplineObject.BackgroundImage = w.Write(value.Text.ToUpper());
                        break;
                    }
                case "128 Code":
                    {
                        w.Format = BarcodeFormat.CODE_128;
                        SimplineObject.BackgroundImage = w.Write(value.Text);
                        break;
                    }
                case "QR Code":
                    {
                        w.Format = BarcodeFormat.QR_CODE;
                        SimplineObject.BackgroundImage = w.Write(value.Text);
                        break;
                    }
                default:
                    {
                        SimplineObject.setSimplineObject(value.Text, FontType.Text, Convert.ToInt32(size));
                        break;
                    }
            }
            SimplineObject.Name = "Bcl" + bclcounter;
            panel1.Controls.Add(SimplineObject);
            bclList.Add(SimplineObject);
            SimplineObject.BackColor = Color.White;
            if (FontType.Text == "39 Code" ||
                FontType.Text == "128 Code" ||
                FontType.Text == "QR Code")
                SimplineObject.setCodeType(FontType.Text);
            else
                SimplineObject.setSimplineObjectType(FontType.Text);
        }

        //Általános metódus objektum szerkesztéséhez
        private void SetFunc(ComboBox FontType, TextBox value, string size)
        {
            BarcodeWriter w = new BarcodeWriter();
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    bclList[i].BackgroundImage = null;
                    w.Options.PureBarcode = true;
                    w.Options.Height = bclList[i].getPanHeight();
                    w.Options.Width = bclList[i].getPanWidth();

                    switch (FontType.SelectedItem.ToString())
                    {
                        case "39 Code":
                            {
                                w.Format = BarcodeFormat.CODE_39;
                                bclList[i].BackgroundImage = w.Write(value.Text.ToUpper());
                                break;
                            }
                        case "128 Code":
                            {
                                w.Format = BarcodeFormat.CODE_128;
                                bclList[i].BackgroundImage = w.Write(value.Text);
                                break;
                            }
                        case "QR Code":
                            {
                                w.Format = BarcodeFormat.QR_CODE;
                                bclList[i].BackgroundImage = w.Write(value.Text);
                                break;
                            }
                        default:
                            {
                                bclList[i].setSimplineObject(value.Text, FontType.Text, Convert.ToInt32(size));
                                break;
                            }
                    }
                    if (FontType.Text == "39 Code" ||
                        FontType.Text == "128 Code" ||
                        FontType.Text == "QR Code")
                        bclList[i].setCodeType(FontType.Text);
                    else
                        bclList[i].setSimplineObjectType(FontType.Text);
                    bclList[i].BackColor = Color.White;
                }
            }
        }

        //Nyomtatóváltásnál papírméretlista frissítése
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

        //Papírméret váltásnál panel méretének megváltoztatása
        private void PaperSizeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LabelList.Text == "Alapértelmezett")
            {
                PrinterSettings settings = new PrinterSettings();
                settings.PrinterName = PrintersList.SelectedItem.ToString();
                foreach (PaperSize ps in settings.PaperSizes)
                {
                    if (ps.Kind.ToString() == PaperSizeList.SelectedItem.ToString())
                    {
                        panel1.Height = ps.Height;
                        panel1.Width = ps.Width;
                    }
                }
            }
        }

        //Középső panel méretezése esetén jobboldali gombok mozgatása
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            if (panel1.Right > FileName.Right)
                panel2.Left = panel1.Right + 25;
            else
                panel2.Left = FileName.Right + 25;
        }

        //Egérpozicionálás
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            X.Text = e.X.ToString();
            Y.Text = e.Y.ToString();
        }

        //Nyomtatási előnézet
        private void PrintPreviewLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gm = new GraphicMaker();
            gm.Printing(bclList, PrintersList, 1, (short)Convert.ToInt32(CopiesTbx.Text));
        }

        //Oldalbeállítás
        private void PageSetupLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gm = new GraphicMaker();
            gm.Printing(bclList, PrintersList, 2, (short)Convert.ToInt32(CopiesTbx.Text));
        }

        //Objektum előrehozása
        private void BringFrontButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    bclList[i].BringToFront();
                }
            }
        }

        //Objektum hátraküldése
        private void SendBackButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bclList.Count; i++)
            {
                if (bclList[i].BackColor == Color.LightGray)
                {
                    bclList[i].SendToBack();
                }
            }
        }

        //Renault-os és Volvos címkéknél a panel beállítása
        private void LabelList_TextChanged(object sender, EventArgs e)
        {
            switch (LabelList.SelectedItem.ToString())
            {
                case "Volvo":
                    {
                        PaperSizeList.Enabled = false;
                        panel1.Height = 158;
                        panel1.Width = 197;
                        break;
                    }
                case "Renault":
                    {
                        PaperSizeList.Enabled = false;
                        panel1.Height = 272;
                        panel1.Width = 197;
                        break;
                    }
                default:
                    {
                        PaperSizeList.Enabled = true;
                        PaperSizeList_SelectedIndexChanged(sender, e);
                        PrinterSettings settings = new PrinterSettings();
                        settings.PrinterName = PrintersList.SelectedItem.ToString();
                        foreach (PaperSize ps in settings.PaperSizes)
                        {
                            if (ps.Kind.ToString() == PaperSizeList.SelectedItem.ToString())
                            {
                                panel1.Height = ps.Height;
                                panel1.Width = ps.Width;
                            }
                        }
                        break;
                    }
            }
        }
    }
}
