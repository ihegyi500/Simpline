using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SimplinePrinter
{
    class FileMaker
    {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        public void ExportPng(Bitmap bmp)
        {
            saveFileDialog1.Filter = "PNG Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                bmp.Save(fs, ImageFormat.Png);
                fs.Close();
            }
            saveFileDialog1.Dispose();

        }

        public void SaveTxt(List<BarcodeLabel> bcl)
        {
            saveFileDialog1.Filter = "Txt file|*.txt";
            saveFileDialog1.Title = "Save a Txt file";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                using (StreamWriter file = File.CreateText(saveFileDialog1.FileName))
                {
                    foreach(BarcodeLabel b in bcl)
                    {
                        file.Write(b.getX() + ", " + b.getY() + Environment.NewLine
                                    + b.getLabX() + ", " + b.getLabY() + Environment.NewLine
                                    + b.getBarcodeString() + Environment.NewLine
                                    + b.getBarcodeSize() + Environment.NewLine
                                    + b.getBarcodeType()
                                    + Environment.NewLine + Environment.NewLine);
                    }
                }
            }
            saveFileDialog1.Dispose();
        }

        public void LoadTxt(Panel p, List<BarcodeLabel> bcl)
        {
            p.Controls.Clear();
            bcl.Clear();
        }
    }
}
