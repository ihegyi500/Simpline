using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;
using ZXing;

namespace Simpline
{
    class FileHandler
    {
        Panel p;
        Label l;
        List<SimplineObject> SOList = new List<SimplineObject>();
        public FileHandler(Panel pan, Label lab, List<SimplineObject> listParam)
        {
            SOList = listParam;
            p = pan;
            l = lab;
        }

        public static void AddPicture(List<SimplineObject> list, Panel pan)
        {
            using(OpenFileDialog open = new OpenFileDialog() { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp",                                                 ValidateNames = true, Title = "Add a picture" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap(open.FileName);
                    SimplineObject SO = new PictureObject(open.FileName);
                    list.Add(SO);
                    pan.Controls.Add(SO);
                }
            }
        }

        public void SaveTxt()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Title = "Save a Txt file" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter file = File.CreateText(sfd.FileName))
                    {
                        foreach (SimplineObject SO in SOList)
                        {

                            if (SO is PictureObject)
                                file.Write("PictureObject;" +
                                    ((PictureObject)SO).getPicture() + ";");
                            else if (SO is BarcodeObject)
                                file.Write("BarcodeObject;" +
                                            ((BarcodeObject)SO).getCodeType() + ";"
                                            + ((BarcodeObject)SO).getCodeValue() + ";");
                            else if (SO is LabelObject)
                            {
                                file.Write("LabelObject;" +
                                    ((LabelObject)SO).getLabFont() + ";"
                                    + ((LabelObject)SO).getLabValue() + ";"
                                    + ((LabelObject)SO).getLabSize() + ";"
                                    + ((LabelObject)SO).getLabX() + ";"
                                    + ((LabelObject)SO).getLabY() + ";");
                            }
                            else
                                file.Write("FrameObject;");
                            file.Write(SO.getX() + ";"
                                        + SO.getY() + ";"
                                        + SO.Height + ";"
                                        + SO.Width + ";");
                            if (SO.BorderStyle == BorderStyle.FixedSingle)
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
            SimplineObject SO;
            string line;
            int i;
            List<string> fonts = new List<string>();
            InstalledFontCollection ifc = new InstalledFontCollection();
            foreach(FontFamily ff in ifc.Families)
            {
                fonts.Add(ff.Name);
            }

            p.Controls.Clear();
            SOList.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Txt file|*.txt", ValidateNames = true, Title = "Open a txt file" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            //SimplineObject SO = new SimplineObject();
                            i = 0;
                            string[] parameters = line.Split(';');
                            switch (parameters[i])
                            {
                                case "PictureObject":
                                    SO = new PictureObject(parameters[i+1]);
                                    i = i + 2;
                                    break;
                                case "BarcodeObject":
                                    SO = new BarcodeObject(parameters[i+1], parameters[i+2]);
                                    i = i + 3;
                                    break;
                                case "LabelObject":
                                    SO = new LabelObject(parameters[i+1], parameters[i+2], parameters[i + 3]);
                                    ((LabelObject)SO).setLabX(i + 4);
                                    ((LabelObject)SO).setLabY(i + 5);
                                    i = i + 6;
                                    break;
                                default:
                                    SO = new FrameObject();
                                    i++;
                                    break;
                            }
                            SO.setX(Convert.ToInt32(parameters[i]));
                            SO.setY(Convert.ToInt32(parameters[i + 1]));
                            SO.Height = Convert.ToInt32(parameters[i + 2]);
                            SO.Width = Convert.ToInt32(parameters[i + 3]);
                            if(SO is FrameObject || parameters[parameters.Length - 1] == "1")
                            {
                                SO.BorderStyle = BorderStyle.FixedSingle;
                            }
                            SOList.Add(SO);
                            p.Controls.Add(SO);
                        }
                    }
                    l.Text = ofd.FileName;
                }
            }
        }
    }
}
