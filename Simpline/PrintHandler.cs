using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Simpline
{
    class PrintHandler
    {
        List<SimplineObject> SOList = new List<SimplineObject>();
        ComboBox PrintersList;
        PrintDocument PrintDoc;
        int copies = 0;
        public void preview()
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = PrintDoc;
            if (ppd.ShowDialog() == DialogResult.OK)
                Printing();
        }
        public PrintHandler(List<SimplineObject> SOList, ComboBox box, int copies)
        {
            try
            {
                this.SOList = SOList;
                PrintersList = box;
                this.copies = copies;
                PrintDoc = new PrintDocument();
                PrintDoc.PrinterSettings.PrinterName =
                PrintersList.SelectedItem.ToString();
                PrintDoc.PrintPage += new PrintPageEventHandler(PrintPageMethod);
            }
            catch (FormatException e)
            {
                throw new FormatException(e.Message);
            }
        }
        public void Printing()
        {
            try
            {
                if (copies > 1)
                    PrintDoc.PrinterSettings.Copies = (short)copies;
                PrintDoc.Print();
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException(e.Message);
            }
        }

        private void PrintPageMethod(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Font font;
            SolidBrush brush = new SolidBrush(Color.Black);
            foreach (SimplineObject SO in SOList)
            {
                if(SO.BorderStyle == BorderStyle.None)
                    pen = new Pen(Color.Transparent);
                Rectangle rec = new Rectangle(SO.getX(), SO.getY(), SO.Width, SO.Height);
                g.DrawRectangle(pen, rec);
                if (SO is LabelObject)
                {
                    font = new Font(((LabelObject)SO).getLabFont(), ((LabelObject)SO).getLabSize());
                    g.DrawString(((LabelObject)SO).getLabValue(),font,brush, SO.getX() + ((LabelObject)SO).getLabX(), SO.getY() + ((LabelObject)SO).getLabY());
                }
                else if (SO is PictureObject || SO is BarcodeObject)
                    g.DrawImage(SO.BackgroundImage, SO.getX(), SO.getY(), SO.Width, SO.Height);
            }
        }
    }
}
