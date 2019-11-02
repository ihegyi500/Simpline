using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Simpline
{
    public partial class FrameObject : SimplineObject
    {
        public FrameObject() : base()
        {
            InitializeComponent();
        }
        protected override void SimplineObject_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.BackColor == Color.LightGray && this.Name.Contains("*"))
            {
                this.BackColor = Color.Transparent;
                this.Name = this.Name.Replace("*", "");
            }
            else
            {
                this.BackColor = Color.LightGray;
                this.Name = this.Name + "*";
            }
        }
    }
}
