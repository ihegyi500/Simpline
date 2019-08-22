using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SimplinePrinter
{
    class GraphicMaker
    {
        Graphics g;
        List<BarcodeLabel> bclL = new List<BarcodeLabel>();
        ComboBox PrintersList;
        Bitmap bmp = new Bitmap(595, 842);

        public void PrintDialog()
        {
            PrintDialog printDiag = new PrintDialog();
            printDiag.ShowDialog();

        }

        public void Printing(List<BarcodeLabel> bclList, ComboBox box, int sent, int copies)
        {
            bclL = bclList;
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
            int ps = 1;
            Pen pen;
            Font font;
            SolidBrush brush = new SolidBrush(Color.Black);
            foreach (BarcodeLabel l in bclL)
            {
                if (l.BorderStyle == BorderStyle.FixedSingle)
                    pen = new Pen(Color.Black);
                else
                    pen = new Pen(Color.Transparent);
                Rectangle rec = new Rectangle(l.getX() * ps, l.getY() * ps, l.Width * ps, l.Height * ps);
                g.DrawRectangle(pen, rec);
                font = new Font(l.getBarcodeType(), l.getBarcodeSize() * ps);
                g.DrawString(l.getBarcodeString(), font, brush, l.getLabX() * ps, l.getLabY() * ps);
            }
        }
    }
}
