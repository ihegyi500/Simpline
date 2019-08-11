using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

namespace SimplinePrinter
{
    class GraphicMaker
    {
        Graphics g;
        List<BarcodeLabel> bclL = new List<BarcodeLabel>();
        ComboBox PrintersList, PaperSizeList;
        Bitmap bmp = new Bitmap(595, 842);
        PaperSize papers = new PaperSize();

        public void PrintDialog()
        {
            PrintDialog printDiag = new PrintDialog();
            printDiag.ShowDialog();

        }

        public void Printing(List<BarcodeLabel> bclList, ComboBox box, ComboBox box2)
        {
            bclL = bclList;
            PrintersList = box;
            PaperSizeList = box2;

            PaperKind p = (PaperKind)PaperSizeList.SelectedIndex;
            PrinterSettings ps = new PrinterSettings();
            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize papers = paperSizes.First<PaperSize>(size => size.Kind == p);
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.PrinterSettings.PrinterName =
            PrintersList.SelectedItem.ToString();
            PrintDoc.DefaultPageSettings.PaperSize = papers;

            PrintDoc.PrintPage += new PrintPageEventHandler(PrintPageMethod);
            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            printPrvDlg.Document = PrintDoc;
            if(printPrvDlg.ShowDialog() == DialogResult.OK)
            {
                PrintDoc.Print();
            }
        }

        private void PrintPageMethod(object sender, PrintPageEventArgs e)
        {
            g = e.Graphics;
            GraphicSetter(/*4*/);
        }

        private void GraphicSetter(/*int ps*/)
        {
            int ps = 4;
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

        public Bitmap GetBitmap()
        {
            g = Graphics.FromImage(bmp);
            GraphicSetter(/*2*/);
            return bmp;
        }
    }
}
