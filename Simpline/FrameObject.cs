using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (this.BackColor == Color.LightGray)
                this.BackColor = Color.White;
            else
                this.BackColor = Color.LightGray;
        }
    }
}
