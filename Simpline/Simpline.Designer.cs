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
            this.PrintButton = new System.Windows.Forms.Button();
            this.PrintersList = new System.Windows.Forms.ComboBox();
            this.printersLabel = new System.Windows.Forms.Label();
            this.AddBarcodeButton = new System.Windows.Forms.Button();
            this.SetBarcodeButton = new System.Windows.Forms.Button();
            this.BarcodeTextTbx = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.BarcodeTypeCbx = new System.Windows.Forms.ComboBox();
            this.BarcodeTypeLabel = new System.Windows.Forms.Label();
            this.BarcodeText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResizeButton = new System.Windows.Forms.Button();
            this.CopyPasteButton = new System.Windows.Forms.Button();
            this.SavePictureButton = new System.Windows.Forms.Button();
            this.TextSizeLabel = new System.Windows.Forms.Label();
            this.TextSizeTbx = new System.Windows.Forms.TextBox();
            this.TextFontLabel = new System.Windows.Forms.Label();
            this.TextLabel = new System.Windows.Forms.Label();
            this.SetTextButton = new System.Windows.Forms.Button();
            this.AddTextButton = new System.Windows.Forms.Button();
            this.TextFontCbx = new System.Windows.Forms.ComboBox();
            this.TextTbx = new System.Windows.Forms.TextBox();
            this.LoadPictureButton = new System.Windows.Forms.Button();
            this.OpenPicButton = new System.Windows.Forms.Button();
            this.PaperSizeList = new System.Windows.Forms.ComboBox();
            this.PaperSizeLabel = new System.Windows.Forms.Label();
            this.RectButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.labFileName = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
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
            // AddBarcodeButton
            // 
            this.AddBarcodeButton.BackColor = System.Drawing.Color.White;
            this.AddBarcodeButton.Location = new System.Drawing.Point(16, 61);
            this.AddBarcodeButton.Name = "AddBarcodeButton";
            this.AddBarcodeButton.Size = new System.Drawing.Size(75, 40);
            this.AddBarcodeButton.TabIndex = 5;
            this.AddBarcodeButton.Text = "Új vonalkód";
            this.AddBarcodeButton.UseVisualStyleBackColor = false;
            this.AddBarcodeButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SetBarcodeButton
            // 
            this.SetBarcodeButton.BackColor = System.Drawing.Color.White;
            this.SetBarcodeButton.Location = new System.Drawing.Point(97, 61);
            this.SetBarcodeButton.Name = "SetBarcodeButton";
            this.SetBarcodeButton.Size = new System.Drawing.Size(75, 40);
            this.SetBarcodeButton.TabIndex = 4;
            this.SetBarcodeButton.Text = "Alkalmaz";
            this.SetBarcodeButton.UseVisualStyleBackColor = false;
            this.SetBarcodeButton.Click += new System.EventHandler(this.SetBarcodeButton_Click);
            // 
            // BarcodeTextTbx
            // 
            this.BarcodeTextTbx.Location = new System.Drawing.Point(99, 36);
            this.BarcodeTextTbx.Name = "BarcodeTextTbx";
            this.BarcodeTextTbx.Size = new System.Drawing.Size(100, 20);
            this.BarcodeTextTbx.TabIndex = 3;
            this.BarcodeTextTbx.Text = "valami";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(12, 275);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 40);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Objektum törlése";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // BarcodeTypeCbx
            // 
            this.BarcodeTypeCbx.FormattingEnabled = true;
            this.BarcodeTypeCbx.Location = new System.Drawing.Point(99, 6);
            this.BarcodeTypeCbx.Name = "BarcodeTypeCbx";
            this.BarcodeTypeCbx.Size = new System.Drawing.Size(121, 21);
            this.BarcodeTypeCbx.TabIndex = 1;
            // 
            // BarcodeTypeLabel
            // 
            this.BarcodeTypeLabel.AutoSize = true;
            this.BarcodeTypeLabel.Location = new System.Drawing.Point(14, 9);
            this.BarcodeTypeLabel.Name = "BarcodeTypeLabel";
            this.BarcodeTypeLabel.Size = new System.Drawing.Size(79, 13);
            this.BarcodeTypeLabel.TabIndex = 0;
            this.BarcodeTypeLabel.Text = "Vonalkódtípus:";
            // 
            // BarcodeText
            // 
            this.BarcodeText.AutoSize = true;
            this.BarcodeText.Location = new System.Drawing.Point(47, 39);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.Size = new System.Drawing.Size(46, 13);
            this.BarcodeText.TabIndex = 0;
            this.BarcodeText.Text = "Szöveg:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(314, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 297);
            this.panel1.TabIndex = 23;
            this.panel1.SizeChanged += new System.EventHandler(this.Panel1_SizeChanged);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            // 
            // ResizeButton
            // 
            this.ResizeButton.BackColor = System.Drawing.Color.White;
            this.ResizeButton.Location = new System.Drawing.Point(93, 229);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(75, 40);
            this.ResizeButton.TabIndex = 6;
            this.ResizeButton.Text = "Méretező mód";
            this.ResizeButton.UseVisualStyleBackColor = false;
            this.ResizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            // 
            // CopyPasteButton
            // 
            this.CopyPasteButton.BackColor = System.Drawing.Color.White;
            this.CopyPasteButton.Location = new System.Drawing.Point(174, 229);
            this.CopyPasteButton.Name = "CopyPasteButton";
            this.CopyPasteButton.Size = new System.Drawing.Size(75, 40);
            this.CopyPasteButton.TabIndex = 27;
            this.CopyPasteButton.Text = "Másol Beilleszt";
            this.CopyPasteButton.UseVisualStyleBackColor = false;
            this.CopyPasteButton.Click += new System.EventHandler(this.CopyPasteButton_Click);
            // 
            // SavePictureButton
            // 
            this.SavePictureButton.BackColor = System.Drawing.Color.White;
            this.SavePictureButton.Location = new System.Drawing.Point(174, 275);
            this.SavePictureButton.Name = "SavePictureButton";
            this.SavePictureButton.Size = new System.Drawing.Size(75, 40);
            this.SavePictureButton.TabIndex = 28;
            this.SavePictureButton.Text = "Fájl mentése";
            this.SavePictureButton.UseVisualStyleBackColor = false;
            this.SavePictureButton.Click += new System.EventHandler(this.SavePictureButton_Click);
            // 
            // TextSizeLabel
            // 
            this.TextSizeLabel.AutoSize = true;
            this.TextSizeLabel.Location = new System.Drawing.Point(36, 35);
            this.TextSizeLabel.Name = "TextSizeLabel";
            this.TextSizeLabel.Size = new System.Drawing.Size(58, 13);
            this.TextSizeLabel.TabIndex = 38;
            this.TextSizeLabel.Text = "Betűméret:";
            // 
            // TextSizeTbx
            // 
            this.TextSizeTbx.Location = new System.Drawing.Point(101, 32);
            this.TextSizeTbx.Name = "TextSizeTbx";
            this.TextSizeTbx.Size = new System.Drawing.Size(40, 20);
            this.TextSizeTbx.TabIndex = 11;
            this.TextSizeTbx.Text = "22";
            // 
            // TextFontLabel
            // 
            this.TextFontLabel.AutoSize = true;
            this.TextFontLabel.Location = new System.Drawing.Point(36, 9);
            this.TextFontLabel.Name = "TextFontLabel";
            this.TextFontLabel.Size = new System.Drawing.Size(56, 13);
            this.TextFontLabel.TabIndex = 34;
            this.TextFontLabel.Text = "Betűtípus:";
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new System.Drawing.Point(46, 61);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(46, 13);
            this.TextLabel.TabIndex = 35;
            this.TextLabel.Text = "Szöveg:";
            // 
            // SetTextButton
            // 
            this.SetTextButton.BackColor = System.Drawing.Color.White;
            this.SetTextButton.Location = new System.Drawing.Point(126, 88);
            this.SetTextButton.Name = "SetTextButton";
            this.SetTextButton.Size = new System.Drawing.Size(75, 40);
            this.SetTextButton.TabIndex = 30;
            this.SetTextButton.Text = "Alkalmaz";
            this.SetTextButton.UseVisualStyleBackColor = false;
            this.SetTextButton.Click += new System.EventHandler(this.SetTextButton_Click);
            // 
            // AddTextButton
            // 
            this.AddTextButton.BackColor = System.Drawing.Color.White;
            this.AddTextButton.Location = new System.Drawing.Point(45, 88);
            this.AddTextButton.Name = "AddTextButton";
            this.AddTextButton.Size = new System.Drawing.Size(75, 40);
            this.AddTextButton.TabIndex = 32;
            this.AddTextButton.Text = "Új szöveg";
            this.AddTextButton.UseVisualStyleBackColor = false;
            this.AddTextButton.Click += new System.EventHandler(this.AddTextButton_Click);
            // 
            // TextFontCbx
            // 
            this.TextFontCbx.FormattingEnabled = true;
            this.TextFontCbx.Location = new System.Drawing.Point(101, 6);
            this.TextFontCbx.Name = "TextFontCbx";
            this.TextFontCbx.Size = new System.Drawing.Size(121, 21);
            this.TextFontCbx.TabIndex = 10;
            // 
            // TextTbx
            // 
            this.TextTbx.Location = new System.Drawing.Point(101, 58);
            this.TextTbx.Name = "TextTbx";
            this.TextTbx.Size = new System.Drawing.Size(100, 20);
            this.TextTbx.TabIndex = 12;
            this.TextTbx.Text = "valami";
            // 
            // LoadPictureButton
            // 
            this.LoadPictureButton.BackColor = System.Drawing.Color.White;
            this.LoadPictureButton.Location = new System.Drawing.Point(93, 275);
            this.LoadPictureButton.Name = "LoadPictureButton";
            this.LoadPictureButton.Size = new System.Drawing.Size(75, 40);
            this.LoadPictureButton.TabIndex = 39;
            this.LoadPictureButton.Text = "Fájl betöltése";
            this.LoadPictureButton.UseVisualStyleBackColor = false;
            this.LoadPictureButton.Click += new System.EventHandler(this.LoadPictureButton_Click);
            // 
            // OpenPicButton
            // 
            this.OpenPicButton.BackColor = System.Drawing.Color.White;
            this.OpenPicButton.Location = new System.Drawing.Point(93, 160);
            this.OpenPicButton.Name = "OpenPicButton";
            this.OpenPicButton.Size = new System.Drawing.Size(75, 40);
            this.OpenPicButton.TabIndex = 42;
            this.OpenPicButton.Text = "Kép betöltése";
            this.OpenPicButton.UseVisualStyleBackColor = false;
            this.OpenPicButton.Click += new System.EventHandler(this.OpenPicButton_Click);
            // 
            // PaperSizeList
            // 
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
            // RectButton
            // 
            this.RectButton.BackColor = System.Drawing.Color.White;
            this.RectButton.Location = new System.Drawing.Point(12, 160);
            this.RectButton.Name = "RectButton";
            this.RectButton.Size = new System.Drawing.Size(75, 40);
            this.RectButton.TabIndex = 46;
            this.RectButton.Text = "Új keret";
            this.RectButton.UseVisualStyleBackColor = false;
            this.RectButton.Click += new System.EventHandler(this.RectButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SendBackButton);
            this.panel2.Controls.Add(this.BringFrontButton);
            this.panel2.Controls.Add(this.RectButton);
            this.panel2.Controls.Add(this.OpenPicButton);
            this.panel2.Controls.Add(this.LoadPictureButton);
            this.panel2.Controls.Add(this.TextFontLabel);
            this.panel2.Controls.Add(this.TextSizeLabel);
            this.panel2.Controls.Add(this.DeleteButton);
            this.panel2.Controls.Add(this.TextSizeTbx);
            this.panel2.Controls.Add(this.ResizeButton);
            this.panel2.Controls.Add(this.CopyPasteButton);
            this.panel2.Controls.Add(this.TextLabel);
            this.panel2.Controls.Add(this.SavePictureButton);
            this.panel2.Controls.Add(this.SetTextButton);
            this.panel2.Controls.Add(this.TextTbx);
            this.panel2.Controls.Add(this.AddTextButton);
            this.panel2.Controls.Add(this.TextFontCbx);
            this.panel2.Location = new System.Drawing.Point(558, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 332);
            this.panel2.TabIndex = 47;
            // 
            // SendBackButton
            // 
            this.SendBackButton.BackColor = System.Drawing.Color.White;
            this.SendBackButton.Location = new System.Drawing.Point(12, 251);
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
            this.BringFrontButton.Location = new System.Drawing.Point(12, 229);
            this.BringFrontButton.Name = "BringFrontButton";
            this.BringFrontButton.Size = new System.Drawing.Size(75, 23);
            this.BringFrontButton.TabIndex = 47;
            this.BringFrontButton.Text = "Előrehozás";
            this.BringFrontButton.UseVisualStyleBackColor = false;
            this.BringFrontButton.Click += new System.EventHandler(this.BringFrontButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LabelList);
            this.panel3.Controls.Add(this.LabLabel);
            this.panel3.Controls.Add(this.CopiesTbx);
            this.panel3.Controls.Add(this.CopiesLabel);
            this.panel3.Controls.Add(this.PrintPreviewLabel);
            this.panel3.Controls.Add(this.PrintersList);
            this.panel3.Controls.Add(this.printersLabel);
            this.panel3.Controls.Add(this.PaperSizeList);
            this.panel3.Controls.Add(this.PaperSizeLabel);
            this.panel3.Controls.Add(this.BarcodeTypeLabel);
            this.panel3.Controls.Add(this.BarcodeText);
            this.panel3.Controls.Add(this.SetBarcodeButton);
            this.panel3.Controls.Add(this.AddBarcodeButton);
            this.panel3.Controls.Add(this.BarcodeTypeCbx);
            this.panel3.Controls.Add(this.PrintButton);
            this.panel3.Controls.Add(this.BarcodeTextTbx);
            this.panel3.Location = new System.Drawing.Point(16, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(271, 331);
            this.panel3.TabIndex = 48;
            // 
            // LabelList
            // 
            this.LabelList.FormattingEnabled = true;
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
            // labFileName
            // 
            this.labFileName.AutoSize = true;
            this.labFileName.Location = new System.Drawing.Point(401, 12);
            this.labFileName.Name = "labFileName";
            this.labFileName.Size = new System.Drawing.Size(26, 13);
            this.labFileName.TabIndex = 53;
            this.labFileName.Text = "Fájl:";
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(433, 12);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(0, 13);
            this.FileName.TabIndex = 54;
            // 
            // Simpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 369);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.labFileName);
            this.Controls.Add(this.laby);
            this.Controls.Add(this.Labx);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.X);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Simpline";
            this.Text = "Simpline";
            this.Load += new System.EventHandler(this.BarcodePrinter_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.ComboBox PrintersList;
        private System.Windows.Forms.Label printersLabel;
        private System.Windows.Forms.Button AddBarcodeButton;
        private System.Windows.Forms.Button SetBarcodeButton;
        private System.Windows.Forms.TextBox BarcodeTextTbx;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ComboBox BarcodeTypeCbx;
        private System.Windows.Forms.Label BarcodeTypeLabel;
        private System.Windows.Forms.Label BarcodeText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ResizeButton;
        private System.Windows.Forms.Button CopyPasteButton;
        private System.Windows.Forms.Button SavePictureButton;
        private System.Windows.Forms.Label TextSizeLabel;
        private System.Windows.Forms.TextBox TextSizeTbx;
        private System.Windows.Forms.Label TextFontLabel;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Button SetTextButton;
        private System.Windows.Forms.Button AddTextButton;
        private System.Windows.Forms.ComboBox TextFontCbx;
        private System.Windows.Forms.TextBox TextTbx;
        private System.Windows.Forms.Button LoadPictureButton;
        private System.Windows.Forms.Button OpenPicButton;
        private System.Windows.Forms.ComboBox PaperSizeList;
        private System.Windows.Forms.Label PaperSizeLabel;
        private System.Windows.Forms.Button RectButton;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.Label labFileName;
        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.ComboBox LabelList;
        private System.Windows.Forms.Label LabLabel;
    }
}

