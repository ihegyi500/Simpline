using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace Simpline
{
    public partial class Simpline : Form
    {
        List<SimplineObject> SOList = new List<SimplineObject>();
        bool resizeOn = false;
        public Simpline()
        {
            InitializeComponent();
        }
        private void BarcodePrinter_Load(object sender, EventArgs e)
        {
            //Vonalkódlista inicializálása
            BarcodeTypeCbx.SelectedIndex = 0;
            //Betűtípuslista feltöltése
            using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
            {
                foreach (FontFamily font in fontsCollection.Families)
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
            //Címkelista inicializálása
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
            for (int i = 0; i < SOList.Count; i++)
            {
                if (SOList[i].Name.Contains("*"))
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
            foreach (SimplineObject SO in SOList)
            {
                SO.setResize(resizeOn);
            }
        }
        //Kijelölt objektumok klónozása
        private void CopyPasteButton_Click(object sender, EventArgs e)
        {
            List<SimplineObject> temp = new List<SimplineObject>();
            foreach (SimplineObject SO in SOList)
            {
                temp.Add(SO);
            }
            foreach (SimplineObject SO in temp)
            {
                if (SO.Name.Contains("*"))
                {
                    SimplineObject SOclone;
                    if (SO is PictureObject)
                        SOclone = new PictureObject(((PictureObject)SO).getPicture());
                    else if (SO is BarcodeObject)
                        SOclone = new BarcodeObject(((BarcodeObject)SO).getCodeType(), ((BarcodeObject)SO).getCodeValue());
                    else if (SO is LabelObject)
                        SOclone = new LabelObject(((LabelObject)SO).getLabFont(), ((LabelObject)SO).getLabValue(), ((LabelObject)SO).getLabSize().ToString());
                    else
                        SOclone = new FrameObject();
                    SOclone.BackgroundImage = SO.BackgroundImage;
                    SOclone.Height = SO.Height;
                    SOclone.Width = SO.Width;
                    panel1.Controls.Add(SOclone);
                    SOList.Add(SOclone);
                }
            }
        }
        //Nyomtatás
        private void PrintButton_Click(object sender, EventArgs e)
        {
            try
            {
                PrintHandler ph = new PrintHandler(SOList, PrintersList, CopiesTbx.Text);
                ph.Printing();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Fájl mentése
        private void SavePictureButton_Click(object sender, EventArgs e)
        {
            FileHandler fmk = new FileHandler(panel1, SOList);
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
            FileHandler fmk = new FileHandler(panel1, SOList);
            try
            {
                fmk.LoadTxt();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Hibaüzenet",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
            try
            {
                SimplineObject SO;
                if (FontType.Text == "39 Code" || FontType.Text == "128 Code" || FontType.Text == "QR Code")
                    SO = new BarcodeObject(FontType.Text, value.Text);
                else
                    SO = new LabelObject(FontType.Text, value.Text, size);
                panel1.Controls.Add(SO);
                SOList.Add(SO);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,"Hibaüzenet",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        //Általános metódus objektum szerkesztéséhez
        private void SetFunc(ComboBox FontType, TextBox value, string size)
        {
            try
            {
                foreach (SimplineObject SO in SOList)
                {
                    if (SO.Name.Contains("*"))
                    {
                        if (FontType.Text == "39 Code" || FontType.Text == "128 Code" || FontType.Text == "QR Code")
                            ((BarcodeObject)SO).setNewCode(FontType.Text, value.Text);
                        else
                            ((LabelObject)SO).setNewLab(FontType.Text, value.Text, size);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            panel2.Left = panel1.Right + 25;
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
            PrintHandler ph = new PrintHandler(SOList, PrintersList, CopiesTbx.Text);
            ph.preview();
        }
        //Objektum előrehozása
        private void BringFrontButton_Click(object sender, EventArgs e)
        {
            foreach (SimplineObject SO in SOList)
            {
                if (SO.Name.Contains("*"))
                    SO.BringToFront();
            }
        }
        //Objektum hátraküldése
        private void SendBackButton_Click(object sender, EventArgs e)
        {
            foreach (SimplineObject SO in SOList)
            {
                if (SO.Name.Contains("*"))
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
                        break;
                    }
            }
        }
        //Billentyűfunkciók
        private void Simpline_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) { 
                DeleteButton_Click(sender, (EventArgs)e);
                e.Handled = true;
            }
        }
        //Objektumok mozgatása nyíllal
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    SOList.ForEach(SO => { if (SO.Name.Contains("*")) { SO.Top--; } });
                    return true;
                case Keys.Down:
                    SOList.ForEach(SO => { if (SO.Name.Contains("*")) { SO.Top++; } });
                    return true;
                case Keys.Left:
                    SOList.ForEach(SO => { if (SO.Name.Contains("*")) { SO.Left--; } });
                    return true;
                case Keys.Right:
                    SOList.ForEach(SO => { if (SO.Name.Contains("*")) { SO.Left++; } });
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
