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
        bool resizeOn = false;

        public FileMaker(bool resOn)
        {
            resizeOn = resOn;
        }
        public void ExportPng(Bitmap bmp)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG Image|*.png", ValidateNames = true, Title = "Save an Image" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = (FileStream)sfd.OpenFile();
                    bmp.Save(fs, ImageFormat.Png);
                    fs.Close();
                }
            }
        }

        public void SaveTxt(List<BarcodeLabel> bcl)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Title = "Save a Txt file" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter file = File.CreateText(sfd.FileName))
                    {
                        foreach (BarcodeLabel b in bcl)
                        {
                            file.Write(b.getX() + "," + b.getY() + ";"
                                        + b.getLabX() + "," + b.getLabY() + ";"
                                        + b.getBarcodeString() + ";"
                                        + b.getBarcodeSize() + ";"
                                        + b.getBarcodeType() + ";"
                                        + b.getPanHeight() + ";"
                                        + b.getPanWidth());
                            if (b.BorderStyle == BorderStyle.FixedSingle)
                                file.Write(";1");
                            file.Write(Environment.NewLine);
                        }
                    }
                }
            }
        }

        public void LoadTxt(Panel p, List<BarcodeLabel> bclList)
        {
            string line;
            p.Controls.Clear();
            bclList.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Multiselect = false, Title = "Open a txt file" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parameters = line.Split(';');
                            string[] panparam = parameters[0].Split(',');
                            string[] labparam = parameters[1].Split(',');
                            BarcodeLabel bcl = new BarcodeLabel();
                            bcl.setX(Convert.ToInt32(panparam[0]));
                            bcl.setY(Convert.ToInt32(panparam[1]));
                            bcl.setLabX(Convert.ToInt32(labparam[0]));
                            bcl.setLabY(Convert.ToInt32(labparam[1]));
                            bcl.setBarcodeString(parameters[2]);
                            bcl.setBarcodeSize(Convert.ToInt32(parameters[3]));
                            bcl.setBarcodeType(parameters[4]);
                            bcl.setPanHeight(Convert.ToInt32(parameters[5]));
                            bcl.setPanWidth(Convert.ToInt32(parameters[6]));
                            if (parameters.Length == 8)
                                bcl.BorderStyle = BorderStyle.FixedSingle;
                            bclList.Add(bcl);
                            p.Controls.Add(bcl);
                        }
                    }
                }
            }
        }
    }
}
