namespace Simpline
{
    partial class Simpline
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simpline));
            this.PrintButton = new System.Windows.Forms.Button();
            this.PrintersList = new System.Windows.Forms.ComboBox();
            this.printersLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SavePictureButton = new System.Windows.Forms.Button();
            this.LoadPictureButton = new System.Windows.Forms.Button();
            this.PaperSizeList = new System.Windows.Forms.ComboBox();
            this.PaperSizeLabel = new System.Windows.Forms.Label();
            this.SendBackButton = new System.Windows.Forms.Button();
            this.BringFrontButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LabelList = new System.Windows.Forms.ComboBox();
            this.LabLabel = new System.Windows.Forms.Label();
            this.CopiesTbx = new System.Windows.Forms.TextBox();
            this.CopiesLabel = new System.Windows.Forms.Label();
            this.PrintPreviewLabel = new System.Windows.Forms.LinkLabel();
            this.X = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.Labx = new System.Windows.Forms.Label();
            this.laby = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(16, 275);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 40);
            this.PrintButton.TabIndex = 9;
            this.PrintButton.Text = "Nyomtatás";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // PrintersList
            // 
            this.PrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrintersList.FormattingEnabled = true;
            this.PrintersList.Location = new System.Drawing.Point(16, 179);
            this.PrintersList.Name = "PrintersList";
            this.PrintersList.Size = new System.Drawing.Size(240, 21);
            this.PrintersList.TabIndex = 8;
            this.PrintersList.SelectedIndexChanged += new System.EventHandler(this.PrintersList_SelectedIndexChanged);
            // 
            // printersLabel
            // 
            this.printersLabel.AutoSize = true;
            this.printersLabel.Location = new System.Drawing.Point(13, 163);
            this.printersLabel.Name = "printersLabel";
            this.printersLabel.Size = new System.Drawing.Size(101, 13);
            this.printersLabel.TabIndex = 0;
            this.printersLabel.Text = "Elérhető nyomtatók:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(314, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 297);
            this.panel1.TabIndex = 23;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            // 
            // SavePictureButton
            // 
            this.SavePictureButton.BackColor = System.Drawing.Color.White;
            this.SavePictureButton.Location = new System.Drawing.Point(97, 32);
            this.SavePictureButton.Name = "SavePictureButton";
            this.SavePictureButton.Size = new System.Drawing.Size(75, 40);
            this.SavePictureButton.TabIndex = 28;
            this.SavePictureButton.Text = "Fájl mentése";
            this.SavePictureButton.UseVisualStyleBackColor = false;
            this.SavePictureButton.Click += new System.EventHandler(this.SavePictureButton_Click);
            // 
            // LoadPictureButton
            // 
            this.LoadPictureButton.BackColor = System.Drawing.Color.White;
            this.LoadPictureButton.Location = new System.Drawing.Point(16, 32);
            this.LoadPictureButton.Name = "LoadPictureButton";
            this.LoadPictureButton.Size = new System.Drawing.Size(75, 40);
            this.LoadPictureButton.TabIndex = 39;
            this.LoadPictureButton.Text = "Fájl betöltése";
            this.LoadPictureButton.UseVisualStyleBackColor = false;
            this.LoadPictureButton.Click += new System.EventHandler(this.LoadPictureButton_Click);
            // 
            // PaperSizeList
            // 
            this.PaperSizeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PaperSizeList.FormattingEnabled = true;
            this.PaperSizeList.Location = new System.Drawing.Point(16, 221);
            this.PaperSizeList.Name = "PaperSizeList";
            this.PaperSizeList.Size = new System.Drawing.Size(240, 21);
            this.PaperSizeList.TabIndex = 44;
            this.PaperSizeList.SelectedIndexChanged += new System.EventHandler(this.PaperSizeList_SelectedIndexChanged);
            // 
            // PaperSizeLabel
            // 
            this.PaperSizeLabel.AutoSize = true;
            this.PaperSizeLabel.Location = new System.Drawing.Point(13, 205);
            this.PaperSizeLabel.Name = "PaperSizeLabel";
            this.PaperSizeLabel.Size = new System.Drawing.Size(62, 13);
            this.PaperSizeLabel.TabIndex = 43;
            this.PaperSizeLabel.Text = "Papírméret:";
            // 
            // SendBackButton
            // 
            this.SendBackButton.BackColor = System.Drawing.Color.White;
            this.SendBackButton.Location = new System.Drawing.Point(178, 52);
            this.SendBackButton.Name = "SendBackButton";
            this.SendBackButton.Size = new System.Drawing.Size(75, 20);
            this.SendBackButton.TabIndex = 48;
            this.SendBackButton.Text = "Hátraküldés";
            this.SendBackButton.UseVisualStyleBackColor = false;
            this.SendBackButton.Click += new System.EventHandler(this.SendBackButton_Click);
            // 
            // BringFrontButton
            // 
            this.BringFrontButton.BackColor = System.Drawing.Color.White;
            this.BringFrontButton.Location = new System.Drawing.Point(178, 32);
            this.BringFrontButton.Name = "BringFrontButton";
            this.BringFrontButton.Size = new System.Drawing.Size(75, 23);
            this.BringFrontButton.TabIndex = 47;
            this.BringFrontButton.Text = "Előrehozás";
            this.BringFrontButton.UseVisualStyleBackColor = false;
            this.BringFrontButton.Click += new System.EventHandler(this.BringFrontButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SendBackButton);
            this.panel3.Controls.Add(this.LabelList);
            this.panel3.Controls.Add(this.BringFrontButton);
            this.panel3.Controls.Add(this.LabLabel);
            this.panel3.Controls.Add(this.CopiesTbx);
            this.panel3.Controls.Add(this.CopiesLabel);
            this.panel3.Controls.Add(this.LoadPictureButton);
            this.panel3.Controls.Add(this.PrintPreviewLabel);
            this.panel3.Controls.Add(this.PrintersList);
            this.panel3.Controls.Add(this.SavePictureButton);
            this.panel3.Controls.Add(this.printersLabel);
            this.panel3.Controls.Add(this.PaperSizeList);
            this.panel3.Controls.Add(this.PaperSizeLabel);
            this.panel3.Controls.Add(this.PrintButton);
            this.panel3.Location = new System.Drawing.Point(16, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(271, 331);
            this.panel3.TabIndex = 48;
            // 
            // LabelList
            // 
            this.LabelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LabelList.FormattingEnabled = true;
            this.LabelList.Items.AddRange(new object[] {
            "Volvo",
            "Renault",
            "Alapértelmezett"});
            this.LabelList.Location = new System.Drawing.Point(16, 131);
            this.LabelList.Name = "LabelList";
            this.LabelList.Size = new System.Drawing.Size(240, 21);
            this.LabelList.TabIndex = 51;
            this.LabelList.TextChanged += new System.EventHandler(this.LabelList_TextChanged);
            // 
            // LabLabel
            // 
            this.LabLabel.AutoSize = true;
            this.LabLabel.Location = new System.Drawing.Point(14, 115);
            this.LabLabel.Name = "LabLabel";
            this.LabLabel.Size = new System.Drawing.Size(41, 13);
            this.LabLabel.TabIndex = 50;
            this.LabLabel.Text = "Címke:";
            // 
            // CopiesTbx
            // 
            this.CopiesTbx.Location = new System.Drawing.Point(193, 272);
            this.CopiesTbx.Name = "CopiesTbx";
            this.CopiesTbx.Size = new System.Drawing.Size(61, 20);
            this.CopiesTbx.TabIndex = 49;
            this.CopiesTbx.Text = "1";
            // 
            // CopiesLabel
            // 
            this.CopiesLabel.AutoSize = true;
            this.CopiesLabel.Location = new System.Drawing.Point(119, 275);
            this.CopiesLabel.Name = "CopiesLabel";
            this.CopiesLabel.Size = new System.Drawing.Size(60, 13);
            this.CopiesLabel.TabIndex = 48;
            this.CopiesLabel.Text = "Példányok:";
            // 
            // PrintPreviewLabel
            // 
            this.PrintPreviewLabel.AutoSize = true;
            this.PrintPreviewLabel.Location = new System.Drawing.Point(14, 251);
            this.PrintPreviewLabel.Name = "PrintPreviewLabel";
            this.PrintPreviewLabel.Size = new System.Drawing.Size(48, 13);
            this.PrintPreviewLabel.TabIndex = 46;
            this.PrintPreviewLabel.TabStop = true;
            this.PrintPreviewLabel.Text = "Előnézet";
            this.PrintPreviewLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PrintPreviewLabel_LinkClicked);
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Location = new System.Drawing.Point(327, 12);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(14, 13);
            this.X.TabIndex = 49;
            this.X.Text = "X";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Location = new System.Drawing.Point(371, 12);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(14, 13);
            this.Y.TabIndex = 50;
            this.Y.Text = "Y";
            // 
            // Labx
            // 
            this.Labx.AutoSize = true;
            this.Labx.Location = new System.Drawing.Point(311, 12);
            this.Labx.Name = "Labx";
            this.Labx.Size = new System.Drawing.Size(17, 13);
            this.Labx.TabIndex = 51;
            this.Labx.Text = "X:";
            // 
            // laby
            // 
            this.laby.AutoSize = true;
            this.laby.Location = new System.Drawing.Point(354, 12);
            this.laby.Name = "laby";
            this.laby.Size = new System.Drawing.Size(17, 13);
            this.laby.TabIndex = 52;
            this.laby.Text = "Y:";
            // 
            // Simpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 360);
            this.Controls.Add(this.laby);
            this.Controls.Add(this.Labx);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.X);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Simpline";
            this.Text = "Simpline";
            this.Load += new System.EventHandler(this.BarcodePrinter_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.ComboBox PrintersList;
        private System.Windows.Forms.Label printersLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SavePictureButton;
        private System.Windows.Forms.Button LoadPictureButton;
        private System.Windows.Forms.ComboBox PaperSizeList;
        private System.Windows.Forms.Label PaperSizeLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label Labx;
        private System.Windows.Forms.Label laby;
        private System.Windows.Forms.LinkLabel PrintPreviewLabel;
        private System.Windows.Forms.TextBox CopiesTbx;
        private System.Windows.Forms.Label CopiesLabel;
        private System.Windows.Forms.Button SendBackButton;
        private System.Windows.Forms.Button BringFrontButton;
        private System.Windows.Forms.ComboBox LabelList;
        private System.Windows.Forms.Label LabLabel;
    }
}

