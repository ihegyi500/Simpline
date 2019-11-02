namespace Simpline
{
    partial class LabelObject
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lab
            // 
            this.Lab.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Lab.AutoSize = true;
            this.Lab.Location = new System.Drawing.Point(49, 28);
            this.Lab.Name = "Lab";
            this.Lab.Size = new System.Drawing.Size(62, 13);
            this.Lab.TabIndex = 1;
            this.Lab.Text = "placeholder";
            this.Lab.DoubleClick += new System.EventHandler(this.Lab_DoubleClick);
            this.Lab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Lab_MouseClick);
            this.Lab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lab_MouseMove);
            // 
            // LabelObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lab);
            this.Name = "LabelObject";
            this.SizeChanged += new System.EventHandler(this.SimplineObject_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab;
    }
}
