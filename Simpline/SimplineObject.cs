﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simpline
{
    public partial class SimplineObject : UserControl
    {
        private Point MouseDownLocation;
        private bool resizeOn = false;
        private string pictureFilePath = "", codeType = "";

        public SimplineObject()
        {
            InitializeComponent();
        }

        public string getPicture()
        {
            return pictureFilePath;
        }

        public void setPicture(string str)
        {
            pictureFilePath = str;
        }

        public string getCodeType()
        {
            return codeType;
        }

        public void setCodeType(string str)
        {
            codeType = str;
        }

        public void setSimplineObject(string str, string s, int i)
        {
            label1.Font = new Font(s, i);
            label1.Text = str;
        }

        public string getSimplineObjectString()
        {
            return this.label1.Text;
        }

        public void setSimplineObjectString(string String)
        {
            label1.Text = String;
        }


        public int getSimplineObjectSize()
        {
            return Convert.ToInt32(this.label1.Font.Size);
        }

        public void setSimplineObjectSize(int Size)
        {
            label1.Font = new Font(label1.Font.FontFamily,Size,label1.Font.Style);
        }

        public string getSimplineObjectType()
        {
            return this.label1.Font.Name;
        }

        public void setSimplineObjectType(string String)
        {
            label1.Font = new Font(String, label1.Font.Size);
        }

        public int getX()
        {
            return Convert.ToInt32(this.Location.X);
        }

        public void setX(int X)
        {
            this.Left = X;
        }

        public int getY()
        {
            return Convert.ToInt32(this.Location.Y);
        }

        public void setY(int Y)
        {
            this.Top = Y;
        }

        public int getLabX()
        {
            return Convert.ToInt32(label1.Location.X) + Convert.ToInt32(this.Location.X);
        }

        public void setLabX(int X)
        {
            label1.Left = X;
        }

        public int getLabY()
        {
            return Convert.ToInt32(label1.Location.Y) + Convert.ToInt32(this.Location.Y);
        }

        public void setLabY(int Y)
        {
            label1.Top = Y;
        }

        public int getPanHeight()
        {
            return this.Height;
        }

        public void setPanHeight(int height)
        {
            this.Height = height;
        }
        public int getPanWidth()
        {
            return this.Width;
        }

        public void setPanWidth(int width)
        {
            this.Width = width;
        }


        //Középen tartja a vonalkódot a panel méretezése után is
        private void SimplineObject_SizeChanged(object sender, EventArgs e)
        {
            if (this.BackgroundImage != null)
                this.BackgroundImageLayout = ImageLayout.Stretch;
            else
            {
                label1.Left = (this.Width - label1.Width) / 2;
                label1.Top = (this.Height - label1.Height) / 2;
                if (this.Width < label1.Width || this.Height < label1.Height)
                {
                    this.Width = label1.Width + Convert.ToInt32(label1.Font.Size);
                    this.Height = label1.Height + Convert.ToInt32(label1.Font.Size);
                }
            }
        }
        //Betöltéskor középre rakja a vonalkódot
        private void SimplineObject_Load(object sender, EventArgs e)
        {
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = (this.Height - label1.Height) / 2;
        }

        //Egérpozíció elmentése
        public void bcl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        //Objektum méretezése/mozgatása
        public void bcl_MouseMove(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Left && resizeOn)
            {
                this.Height = this.Top + e.Y;
                this.Width = this.Left + e.X;

            }
            else if (e.Button == MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        //Objektum kijelölése
        public void bcl_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.BackColor == Color.LightGray)
            {
                if (this.BackgroundImage != null)
                    this.BackColor = Color.White;
                else
                    this.BackColor = Color.Empty;
                if (this.label1.Text != "" || this.BackgroundImage != null)
                    this.BorderStyle = BorderStyle.None;
            }
            else
            {
                this.BackColor = Color.LightGray;
                if (this.BackgroundImage != null || this.label1.Text != "")
                    this.BorderStyle = BorderStyle.FixedSingle;
            }
        }

         public void setResize(bool resOn)
        {
            resizeOn = resOn;
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            ObjectLoc ol = new ObjectLoc(this);
            ol.Show();
        }

        private void SimplineObject_DoubleClick(object sender, EventArgs e)
        {
            ObjectLoc ol = new ObjectLoc(this);
            ol.Show();
        }
    }
}