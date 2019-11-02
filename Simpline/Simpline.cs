using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Text;
using ZXing;

namespace Simpline
{
    public partial class Simpline : Form
    {
        List<SimplineObject> SOList = new List<SimplineObject>();
        bool resizeOn = false;
        PrintHandler ph;
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
                //FontFamily[] fontFamilies = fontsCollection.Families;
                foreach (FontFamily font in /*fontFamilies*/ fontsCollection.Families)
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
        }
        //Vonalkód beállítása
        private void SetBarcodeButton_Click(object sender, EventArgs e)
        {
            SetFunc(BarcodeTypeCbx, BarcodeTextTbx, "");
        }
        //Kijelölt objektumok törlése
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < SOList.Count; i++)
            {
                if (SOList[i].BackColor == Color.LightGray)
                {
                    panel1.Controls.RemoveAt(i);
                    SOList.Remove(SOList[i]);
                    i--;
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
            foreach(SimplineObject SO in SOList)
            {
                SO.setResize(resizeOn);
            }
        }
        //Kijelölt objektumok klónozása
        private void CopyPasteButton_Click(object sender, EventArgs e)
        {
            foreach (SimplineObject SO in SOList)
            {
                if (SO.BackColor == Color.LightGray)
                {
                    SimplineObject SOclone = new SimplineObject();
                    SOclone.BackgroundImage = SO.BackgroundImage;
                    SOclone.Height = SO.Height;
                    SOclone.Width = SO.Width;
                    panel1.Controls.Add(SOclone);
                    SOList.Add(SOclone);
                    if (SO is PictureObject)
                        ((PictureObject)SOclone).setPicture(((PictureObject)SO).getPicture());
                    else if (SO is BarcodeObject)
                        ((BarcodeObject)SOclone).setCodeType(((BarcodeObject)SO).getCodeType());
                    else if(SO is LabelObject)
                    {
                        ((LabelObject)SOclone).setNewLab(
                            ((LabelObject)SO).getLabFont(), ((LabelObject)SO).getLabValue(), ((LabelObject)SO).getLabSize().ToString());
                    }
                }
            }
        }
        //Nyomtatás
        private void PrintButton_Click(object sender, EventArgs e)
        {
            ph = new PrintHandler(SOList,PrintersList, (short)Convert.ToInt32(CopiesTbx.Text));
            ph.Printing();
        }
        //Fájl mentése
        private void SavePictureButton_Click(object sender, EventArgs e)
        {
            FileHandler fmk = new FileHandler(panel1, FileName, SOList);
            fmk.SaveTxt();
        }
        //Szöveges objektum hozzáadása
        private void AddTextButton_Click(object sender, EventArgs e)
        {
            AddFunc(TextFontCbx, TextTbx, TextSizeTbx.Text);
        }
        //Szöveges objektum szerkesztése
        private void SetTextButton_Click(object sender, EventArgs e)
        {
            SetFunc(TextFontCbx, TextTbx, TextSizeTbx.Text);
        }
        //Kép betöltése
        private void OpenPicButton_Click(object sender, EventArgs e)
        {
            FileHandler.AddPicture(SOList, panel1);
        }
        //Fájl megnyitása
        private void LoadPictureButton_Click(object sender, EventArgs e)
        {
            FileHandler fmk = new FileHandler(panel1, FileName, SOList);
            fmk.LoadTxt();
        }
        //Új keret hozzáadása
        private void RectButton_Click(object sender, EventArgs e)
        {
            SimplineObject FO = new FrameObject();
            panel1.Controls.Add(FO);
            SOList.Add(FO);
            FO.SendToBack();
        }
        //Általános metódus objektum hozzáadásához
        private void AddFunc(ComboBox FontType, TextBox value, string size)
        {
            SimplineObject SO;
            if(FontType.Text == "39 Code" || FontType.Text == "128 Code" || FontType.Text == "QR Code")
                SO = new BarcodeObject(FontType.Text, value.Text);
            else
                SO = new LabelObject(FontType.Text, value.Text, size);
            panel1.Controls.Add(SO);
            SOList.Add(SO);
        }
        //Általános metódus objektum szerkesztéséhez
        private void SetFunc(ComboBox FontType, TextBox value, string size)
        {
            foreach (SimplineObject SO in SOList)
            {
                if (SO.BackColor == Color.LightGray)
                {
                    if (FontType.Text == "39 Code" || FontType.Text == "128 Code" || FontType.Text == "QR Code")
                        ((BarcodeObject)SO).setNewCode(FontType.Text, value.Text);
                    else
                        ((LabelObject)SO).setNewLab(FontType.Text, value.Text, size);
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
            ph = new PrintHandler(SOList, PrintersList, (short)Convert.ToInt32(CopiesTbx.Text));
            ph.preview();
        }
        //Objektum előrehozása
        private void BringFrontButton_Click(object sender, EventArgs e)
        {
            foreach (SimplineObject SO in SOList)
            {
                if (SO.BackColor == Color.LightGray)
                    SO.BringToFront();
            }
        }
        //Objektum hátraküldése
        private void SendBackButton_Click(object sender, EventArgs e)
        {
            foreach (SimplineObject SO in SOList)
            {
                if (SO.BackColor == Color.LightGray)
                    SO.SendToBack();
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
