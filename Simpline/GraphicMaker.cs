using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Nyomtatas
{
    class GraphicMaker
    {
        Graphics g;
        List<BarcodeLabel> bclL = new List<BarcodeLabel>();
        ComboBox PrintersList;
        Bitmap bmp = new Bitmap(595, 842);

        public GraphicMaker(List<BarcodeLabel> bclList, ComboBox box)
        {
            bclL = bclList;
            PrintersList = box;
        }

        public void Printing()
        {
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.PrinterSettings.PrinterName =
            PrintersList.SelectedItem.ToString();
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
            GraphicSetter();
            /*int ps = 4;
            g = e.Graphics;
            Pen pen;
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);
            foreach(BarcodeLabel l in bclL)
            {
                if (l.BorderStyle == BorderStyle.FixedSingle)
                    pen = new Pen(Color.Black);
                else
                    pen = new Pen(Color.Transparent);
                Rectangle rec = new Rectangle(l.getX()*ps, l.getY()*ps, l.Width*ps, l.Height*ps);
                g.DrawRectangle(pen, rec);
                font = new Font(l.getBarcodeType(), l.getBarcodeSize()*ps);
                g.DrawString(l.getBarcodeString(), font, brush, l.getLabX()*ps, l.getLabY()*ps);
            }*/
        }

        /*public Graphics getGraphic()
        {
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.PrintPage += new PrintPageEventHandler(PrintPageMethod);
            return g;
        }*/

        private void GraphicSetter()
        {
            int ps = 4;
            Pen pen;
            Font font = new Font("Arial", 12);
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
            GraphicSetter();
            return bmp;
        }
    }
}
