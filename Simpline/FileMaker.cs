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
                            file.Write("A " + b.getX() + "," + b.getY() + Environment.NewLine
                                        + "B " + b.getLabX() + "," + b.getLabY() + Environment.NewLine
                                        + "C " + b.getBarcodeString() + Environment.NewLine
                                        + "D " + b.getBarcodeSize() + Environment.NewLine
                                        + "E " + b.getBarcodeType()
                                        + Environment.NewLine + Environment.NewLine);
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
                            BarcodeLabel bcl = new BarcodeLabel();
                            bclList.Add(bcl);
                            p.Controls.Add(bcl);
                            if (line == "");
                            else
                            {
                                switch (line[0])
                                {
                                    case 'A':
                                        {
                                            string[] words = line.Split(',');
                                            words[0] = words[0].Remove(0, 2);
                                            bcl.setX(Convert.ToInt32(words[0]));
                                            bcl.setY(Convert.ToInt32(words[1]));
                                            break;
                                        }
                                    case 'B':
                                        {
                                            string[] words = line.Split(',');
                                            words[0] = words[0].Remove(0, 2);
                                            bcl.setLabX(Convert.ToInt32(words[0]));
                                            bcl.setLabY(Convert.ToInt32(words[1]));
                                            break;
                                        }
                                    case 'C':
                                        {
                                            string[] words = line.Split(',');
                                            words[0] = words[0].Remove(0, 2);
                                            bcl.setBarcodeString(words[0]);
                                            break;
                                        }
                                    case 'D':
                                        {
                                            string[] words = line.Split(',');
                                            words[0] = words[0].Remove(0, 2);
                                            bcl.setBarcodeSize(Convert.ToInt32(words[0]));
                                            break;
                                        }
                                    case 'E':
                                        {
                                            string[] words = line.Split(',');
                                            words[0] = words[0].Remove(0, 2);
                                            bcl.setBarcodeType(words[0]);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
