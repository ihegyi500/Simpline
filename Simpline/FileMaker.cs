using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;
using ZXing;

namespace SimplinePrinter
{
    class FileMaker
    {
        Panel p;
        Label l;
        List<SimplineObject> bclList = new List<SimplineObject>();
        public FileMaker(Panel pan, Label lab, List<SimplineObject> listParam)
        {
            bclList = listParam;
            p = pan;
            l = lab;
        }

        public void AddPicture()
        {
            using(OpenFileDialog open = new OpenFileDialog() { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp",
                                                               ValidateNames = true, Title = "Add a picture" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap(open.FileName);
                    SimplineObject bcl = new SimplineObject();
                    bcl.Height = b.Height;
                    bcl.Width = b.Width;
                    bcl.BackgroundImage = b;
                    bclList.Add(bcl);
                    bcl.setPicture(open.FileName);
                    p.Controls.Add(bcl);
                    bcl.BackColor = Color.White;
                }
            }
        }

        public void SaveTxt()
        {
            BarcodeReader read = new BarcodeReader();
            Bitmap bitmap;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Title = "Save a Txt file" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter file = File.CreateText(sfd.FileName))
                    {
                        foreach (SimplineObject b in bclList)
                        {
                            file.Write(b.getX() + ";" 
                                        + b.getY() + ";"
                                        + b.getPanHeight() + ";"
                                        + b.getPanWidth() + ";");
                            if(b.BackgroundImage != null)
                            {
                                if(b.getCodeType() != "")
                                {

                                    bitmap = new Bitmap(b.BackgroundImage);
                                    file.Write(b.getCodeType() + ";" 
                                         + read.Decode(bitmap) + ";");
                                }
                                else
                                {
                                    file.Write(b.getPicture());
                                }
                            }
                            else
                            {
                                if (b.getSimplineObjectString() != "")
                                {
                                    file.Write(b.getSimplineObjectType() + ";"
                                    + b.getSimplineObjectString() + ";"
                                    + b.getLabX() + ";"
                                    + b.getLabY() + ";"
                                    + b.getSimplineObjectSize() + ";");
                                }
                                else
                                    file.Write(";");
                            }
                            if (b.BorderStyle == BorderStyle.FixedSingle)
                                file.Write("1");
                            file.Write(Environment.NewLine);
                        }
                    }
                    if (!l.Text.Contains(" (Mentve)"))
                        l.Text += " (Mentve)";
                }
            }
        }

        public void LoadTxt()
        {
            string line;
            string[] fiNa;
            Bitmap bitmap;
            List<string> fonts = new List<string>();
            BarcodeWriter w = new BarcodeWriter();
            w.Options.PureBarcode = true;
            InstalledFontCollection ifc = new InstalledFontCollection();
            foreach(FontFamily ff in ifc.Families)
            {
                fonts.Add(ff.Name);
            }
            p.Controls.Clear();
            bclList.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Title = "Open a txt file" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            SimplineObject bcl = new SimplineObject();
                            string[] parameters = line.Split(';');
                            bcl.setX(Convert.ToInt32(parameters[0]));
                            bcl.setY(Convert.ToInt32(parameters[1]));
                            bcl.setPanHeight(Convert.ToInt32(parameters[2]));
                            bcl.setPanWidth(Convert.ToInt32(parameters[3]));
                            w.Options.Height = bcl.getPanHeight();
                            w.Options.Width = bcl.getPanWidth();
                            if (parameters[4] != "")
                            {
                                if (parameters[4] == "39 Code" || parameters[4] == "128 Code" || parameters[4] == "QR Code")
                                {
                                    switch (parameters[4])
                                    {
                                        case "39 Code":
                                            {
                                                w.Format = BarcodeFormat.CODE_39;
                                                bcl.BackgroundImage = w.Write(parameters[5]);
                                                break;
                                            }
                                        case "128 Code":
                                            {
                                                w.Format = BarcodeFormat.CODE_128;
                                                bcl.BackgroundImage = w.Write(parameters[5]);
                                                break;
                                            }
                                        case "QR Code":
                                            {
                                                w.Format = BarcodeFormat.QR_CODE;
                                                bcl.BackgroundImage = w.Write(parameters[5]);
                                                break;
                                            }
                                    }
                                    bcl.BackgroundImageLayout = ImageLayout.Stretch;
                                    bcl.setCodeType(parameters[4]);
                                    bcl.BackColor = Color.White;
                                }
                                else if (fonts.Contains(parameters[4]))
                                {
                                    bcl.setSimplineObjectType(parameters[4]);
                                    bcl.setSimplineObjectString(parameters[5]);
                                    bcl.setLabX(Convert.ToInt32(parameters[6]));
                                    bcl.setLabY(Convert.ToInt32(parameters[7]));
                                    bcl.setSimplineObjectSize(Convert.ToInt32(parameters[8]));
                                }
                                else
                                {
                                    bitmap = new Bitmap(parameters[4]);
                                    bcl.BackgroundImage = bitmap;
                                    bcl.BackgroundImageLayout = ImageLayout.Stretch;
                                    bcl.setPicture(parameters[4]);
                                    bcl.BackColor = Color.White;
                                }
                            }
                            else
                            {
                                bcl.BorderStyle = BorderStyle.FixedSingle;
                            }
                            bclList.Add(bcl);
                            if (parameters[parameters.Length - 1] == "1")
                                bcl.BorderStyle = BorderStyle.FixedSingle;
                            p.Controls.Add(bcl);
                        }
                    }
                    fiNa = ofd.FileName.Split('\\');
                    l.Text = fiNa[fiNa.Length-1];
                }
            }
        }
    }
}
