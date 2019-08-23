using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SimplinePrinter
{
    class GraphicMaker
    {
        Graphics g;
        //List<BarcodeLabel> bclL = new List<BarcodeLabel>();
        Dictionary<BarcodeLabel, string> bcldict = new Dictionary<BarcodeLabel, string>();
        ComboBox PrintersList;

        public void PrintDialog()
        {
            PrintDialog printDiag = new PrintDialog();
            printDiag.ShowDialog();

        }

        public void Printing(Dictionary<BarcodeLabel, string> dict, ComboBox box, int sent, int copies)
        {
            bcldict = dict;
            PrintersList = box;
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.PrinterSettings.PrinterName =
            PrintersList.SelectedItem.ToString();
            PrintDoc.PrintPage += new PrintPageEventHandler(PrintPageMethod);
            switch (sent)
            {
               case 1:
                    {
                        PrintPreviewDialog ppd = new PrintPreviewDialog();
                        ppd.Document = PrintDoc;
                        if (ppd.ShowDialog() == DialogResult.OK)
                        {
                        if(copies != 0)
                            PrintDoc.PrinterSettings.Copies = (short)copies;
                        PrintDoc.Print();
                        }
                        break;
                    }
               case 2:
                    {
                        PageSetupDialog psd = new PageSetupDialog();
                        psd.Document = PrintDoc;
                        if (psd.ShowDialog() == DialogResult.OK)
                        {
                            if (copies != 0)
                                PrintDoc.PrinterSettings.Copies = (short)copies;
                            PrintDoc.Print();
                        }
                        break;
                    }
               case 3:
                    {
                        if (copies != 0)
                            PrintDoc.PrinterSettings.Copies = (short)copies;
                        PrintDoc.Print();
                        break;
                    }
            }
        }

        private void PrintPageMethod(object sender, PrintPageEventArgs e)
        {
            g = e.Graphics;
            GraphicSetter();
        }

        private void GraphicSetter()
        {
            Pen pen;
            Font font;
            SolidBrush brush = new SolidBrush(Color.Black);
            foreach (BarcodeLabel l in bcldict.Keys)
            {
                if (l.BorderStyle == BorderStyle.FixedSingle)
                    pen = new Pen(Color.Black);
                else
                    pen = new Pen(Color.Transparent);
                Rectangle rec = new Rectangle(l.getX(), l.getY(), l.Width, l.Height);
                g.DrawRectangle(pen, rec);
                font = new Font(l.getBarcodeType(), l.getBarcodeSize());
                g.DrawString(l.getBarcodeString(), font, brush, l.getLabX(), l.getLabY());
                if (l.BackgroundImage != null)
                    g.DrawImage(l.BackgroundImage, l.getX(), l.getY(), l.Width, l.Height);
            }
        }

    }
}
