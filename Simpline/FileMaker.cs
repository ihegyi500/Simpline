using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ZXing;

namespace SimplinePrinter
{
    class FileMaker
    {
        public void AddPicture(Panel p, /*List<BarcodeLabel> bclList*/Dictionary<BarcodeLabel, string> bcldict)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog(){ ValidateNames = true, Title = "Add a picture" };
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap(open.FileName);
                    BarcodeLabel bcl = new BarcodeLabel();
                    bcl.Height = b.Height;
                    bcl.Width = b.Width;
                    bcl.BackgroundImage = b;
                    bcldict.Add(bcl, open.FileName);
                    p.Controls.Add(bcl);
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        public void SaveTxt(/*List<BarcodeLabel> bcl*/Dictionary<BarcodeLabel, string> bcldict)
        {
            BarcodeReader read = new BarcodeReader();
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Title = "Save a Txt file" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter file = File.CreateText(sfd.FileName))
                    {
                        foreach (BarcodeLabel b in bcldict.Keys)
                        {
                            file.Write(b.getX() + "," + b.getY() + ";"
                                        + b.getLabX() + "," + b.getLabY() + ";"
                                        + b.getPanHeight() + ";"
                                        + b.getPanWidth() + ";"

                                        + b.getBarcodeString() + ";"
                                        + b.getBarcodeSize() + ";"
                                        + b.getBarcodeType() + ";"
                                        + bcldict[b]);
                            if (b.BorderStyle == BorderStyle.FixedSingle)
                                file.Write(";1");
                            file.Write(Environment.NewLine);
                        }
                    }
                }
            }
        }

        public void LoadTxt(Panel p, Dictionary<BarcodeLabel, string> bcldict)
        {
            string line;
            p.Controls.Clear();
            bcldict.Clear();
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
                            BarcodeWriter w = new BarcodeWriter();
                            w.Options.PureBarcode = true;
                            bcl.setX(Convert.ToInt32(panparam[0]));
                            bcl.setY(Convert.ToInt32(panparam[1]));
                            bcl.setLabX(Convert.ToInt32(labparam[0]));
                            bcl.setLabY(Convert.ToInt32(labparam[1]));
                            bcl.setBarcodeString(parameters[2]);
                            bcl.setBarcodeSize(Convert.ToInt32(parameters[3]));
                            bcl.setBarcodeType(parameters[4]);
                            bcl.setPanHeight(Convert.ToInt32(parameters[5]));
                            bcl.setPanWidth(Convert.ToInt32(parameters[6]));
                            w.Options.Height = bcl.getPanHeight();
                            w.Options.Width = bcl.getPanWidth();
                            switch (parameters[7])
                            {
                                case "Free 3 of 9 Extended":
                                    {

                                        break;
                                    }
                                case "Code 128":
                                    {

                                        break;
                                    }
                                case "QR Code":
                                    {

                                        break;
                                    }
                            }
                            if (parameters.Length == 8)
                                bcl.BorderStyle = BorderStyle.FixedSingle;
                            bcldict.Add(bcl, "");
                            p.Controls.Add(bcl);
                        }
                    }
                }
            }
        }
    }
}
