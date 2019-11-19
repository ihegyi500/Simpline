using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Simpline
{
    public partial class Simpline : Form
    {
        List<SimplineObject> SOList = new List<SimplineObject>();
        PrintHandler ph;
        public Simpline()
        {
            InitializeComponent();
        }
        private void BarcodePrinter_Load(object sender, EventArgs e)
        {
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
        //Nyomtatás
        private void PrintButton_Click(object sender, EventArgs e)
        {
            try
            {
                ph = new PrintHandler(SOList, PrintersList, (short)Convert.ToInt32(CopiesTbx.Text));
                ph.Printing();
            }
            catch (Exception ex)
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
        //Fájl megnyitása
        private void LoadPictureButton_Click(object sender, EventArgs e)
        {
            FileHandler fmk = new FileHandler(panel1, SOList);
            try
            {
                fmk.LoadTxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Nyomtatóváltásnál papírméretlista frissítése
        private void PrintersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrinterSettings settings = new PrinterSettings();
            settings.PrinterName = PrintersList.SelectedItem.ToString();
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
        //Objektumok mozgatása nyíllal
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    SOList.ForEach(SO => { if (SO.Name.Contains("*")) { SO.Top--; }
                    });
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
