﻿using System;
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
        Dictionary<BarcodeLabel, string> bcldict;
        public FileMaker(Panel pan, Label lab, Dictionary<BarcodeLabel, string> bclDict)
        {
            p = pan;
            l = lab;
            bcldict = bclDict;
        }

        public void AddPicture()
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
                    bcl.setPicture(open.FileName);
                    p.Controls.Add(bcl);
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
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
                        /*if (sfd.FileName.Contains("renault"))
                        {
                            file.Write("")
                        }*/
                        foreach (BarcodeLabel b in bcldict.Keys)
                        {
                            file.Write(b.getX() + ";" 
                                        + b.getY() + ";"
                                        + b.getPanHeight() + ";"
                                        + b.getPanWidth() + ";"
                                        + bcldict[b] + ";");
                            if (bcldict[b] != "" && b.BackgroundImage != null) {
                                bitmap = new Bitmap(b.BackgroundImage);
                                file.Write(read.Decode(bitmap) + ";");
                            }
                            file.Write(b.getBarcodeLabelString() + ";");
                            if(b.getBarcodeLabelString() != "")
                            {
                                file.Write(b.getLabX() + ";"
                                    + b.getLabY() + ";"
                                    + b.getBarcodeLabelSize() + ";"
                                    /*+ b.getBarcodeLabelType() + ";"*/);
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
            bcldict.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Multiselect = false, Title = "Open a txt file" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    /*if (ofd.FileName.Contains("Volvo"))
                    {
                        p.Height = 120;
                        p.Width = 197;
                    }*/
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            BarcodeLabel bcl = new BarcodeLabel();
                            string[] parameters = line.Split(';');
                            bcl.setX(Convert.ToInt32(parameters[0]));
                            bcl.setY(Convert.ToInt32(parameters[1]));
                            bcl.setPanHeight(Convert.ToInt32(parameters[2]));
                            bcl.setPanWidth(Convert.ToInt32(parameters[3]));
                            w.Options.Height = bcl.getPanHeight();
                            w.Options.Width = bcl.getPanWidth();
                            if (parameters[4] != "")
                            {
                                if (parameters[4] == "Free 3 of 9 Extended" || parameters[4] == "Code 128" || parameters[4] == "QR Code")
                                {
                                    switch (parameters[4])
                                    {
                                        case "Free 3 of 9 Extended":
                                            {
                                                w.Format = BarcodeFormat.CODE_39;
                                                bcl.BackgroundImage = w.Write(parameters[5]);
                                                bcldict.Add(bcl, parameters[4]);
                                                break;
                                            }
                                        case "Code 128":
                                            {
                                                w.Format = BarcodeFormat.CODE_128;
                                                bcl.BackgroundImage = w.Write(parameters[5]);
                                                bcldict.Add(bcl, parameters[4]);
                                                break;
                                            }
                                        case "QR Code":
                                            {
                                                w.Format = BarcodeFormat.QR_CODE;
                                                bcl.BackgroundImage = w.Write(parameters[5]);
                                                bcldict.Add(bcl, parameters[4]);
                                                break;
                                            }
                                    }
                                    bcl.BackgroundImageLayout = ImageLayout.Stretch;
                                    bcl.setCodeType(parameters[4]);
                                }
                                else if (fonts.Contains(parameters[4]))
                                {
                                    bcl.setBarcodeLabelType(parameters[4]);
                                    bcl.setBarcodeLabelString(parameters[5]);
                                    bcl.setLabX(Convert.ToInt32(parameters[6]));
                                    bcl.setLabY(Convert.ToInt32(parameters[7]));
                                    bcl.setBarcodeLabelSize(Convert.ToInt32(parameters[8]));
                                    bcldict.Add(bcl, parameters[4]);
                                }
                                else
                                {
                                    bitmap = new Bitmap(parameters[4]);
                                    bcl.BackgroundImage = bitmap;
                                    bcl.BackgroundImageLayout = ImageLayout.Stretch;
                                    bcldict.Add(bcl, parameters[4]);
                                    bcl.setPicture(parameters[4]);
                                }
                            }
                            else
                            {
                                bcl.BorderStyle = BorderStyle.FixedSingle;
                                bcldict.Add(bcl, "");
                            }
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
