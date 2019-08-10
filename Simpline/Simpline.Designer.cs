namespace Simpline
{
    partial class BarcodePrinter
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
            this.BarcodeSizeLabel = new System.Windows.Forms.Label();
            this.BarcodeSizeTbx = new System.Windows.Forms.TextBox();
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
            this.RectChbx = new System.Windows.Forms.CheckBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(21, 279);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 40);
            this.PrintButton.TabIndex = 9;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // PrintersList
            // 
            this.PrintersList.FormattingEnabled = true;
            this.PrintersList.Location = new System.Drawing.Point(21, 250);
            this.PrintersList.Name = "PrintersList";
            this.PrintersList.Size = new System.Drawing.Size(240, 21);
            this.PrintersList.TabIndex = 8;
            // 
            // printersLabel
            // 
            this.printersLabel.AutoSize = true;
            this.printersLabel.Location = new System.Drawing.Point(19, 226);
            this.printersLabel.Name = "printersLabel";
            this.printersLabel.Size = new System.Drawing.Size(91, 13);
            this.printersLabel.TabIndex = 0;
            this.printersLabel.Text = "Available Printers:";
            // 
            // AddBarcodeButton
            // 
            this.AddBarcodeButton.BackColor = System.Drawing.Color.White;
            this.AddBarcodeButton.Location = new System.Drawing.Point(69, 114);
            this.AddBarcodeButton.Name = "AddBarcodeButton";
            this.AddBarcodeButton.Size = new System.Drawing.Size(75, 40);
            this.AddBarcodeButton.TabIndex = 5;
            this.AddBarcodeButton.Text = "Add new";
            this.AddBarcodeButton.UseVisualStyleBackColor = false;
            this.AddBarcodeButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SetBarcodeButton
            // 
            this.SetBarcodeButton.BackColor = System.Drawing.Color.White;
            this.SetBarcodeButton.Location = new System.Drawing.Point(150, 114);
            this.SetBarcodeButton.Name = "SetBarcodeButton";
            this.SetBarcodeButton.Size = new System.Drawing.Size(75, 40);
            this.SetBarcodeButton.TabIndex = 4;
            this.SetBarcodeButton.Text = "Set";
            this.SetBarcodeButton.UseVisualStyleBackColor = false;
            this.SetBarcodeButton.Click += new System.EventHandler(this.SetBarcodeButton_Click);
            // 
            // BarcodeTextTbx
            // 
            this.BarcodeTextTbx.Location = new System.Drawing.Point(104, 71);
            this.BarcodeTextTbx.Name = "BarcodeTextTbx";
            this.BarcodeTextTbx.Size = new System.Drawing.Size(100, 20);
            this.BarcodeTextTbx.TabIndex = 3;
            this.BarcodeTextTbx.Text = "valami";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(652, 204);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 40);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // BarcodeTypeCbx
            // 
            this.BarcodeTypeCbx.FormattingEnabled = true;
            this.BarcodeTypeCbx.Location = new System.Drawing.Point(104, 19);
            this.BarcodeTypeCbx.Name = "BarcodeTypeCbx";
            this.BarcodeTypeCbx.Size = new System.Drawing.Size(121, 21);
            this.BarcodeTypeCbx.TabIndex = 1;
            // 
            // BarcodeTypeLabel
            // 
            this.BarcodeTypeLabel.AutoSize = true;
            this.BarcodeTypeLabel.Location = new System.Drawing.Point(12, 22);
            this.BarcodeTypeLabel.Name = "BarcodeTypeLabel";
            this.BarcodeTypeLabel.Size = new System.Drawing.Size(89, 13);
            this.BarcodeTypeLabel.TabIndex = 0;
            this.BarcodeTypeLabel.Text = "Type of Barcode:";
            // 
            // BarcodeText
            // 
            this.BarcodeText.AutoSize = true;
            this.BarcodeText.Location = new System.Drawing.Point(24, 74);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.Size = new System.Drawing.Size(74, 13);
            this.BarcodeText.TabIndex = 0;
            this.BarcodeText.Text = "Barcode Text:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(324, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 297);
            this.panel1.TabIndex = 23;
            // 
            // ResizeButton
            // 
            this.ResizeButton.BackColor = System.Drawing.Color.White;
            this.ResizeButton.Location = new System.Drawing.Point(571, 204);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(75, 40);
            this.ResizeButton.TabIndex = 6;
            this.ResizeButton.Text = "Resize";
            this.ResizeButton.UseVisualStyleBackColor = false;
            this.ResizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            // 
            // BarcodeSizeLabel
            // 
            this.BarcodeSizeLabel.AutoSize = true;
            this.BarcodeSizeLabel.Location = new System.Drawing.Point(26, 48);
            this.BarcodeSizeLabel.Name = "BarcodeSizeLabel";
            this.BarcodeSizeLabel.Size = new System.Drawing.Size(71, 13);
            this.BarcodeSizeLabel.TabIndex = 0;
            this.BarcodeSizeLabel.Text = "Barcode size:";
            // 
            // BarcodeSizeTbx
            // 
            this.BarcodeSizeTbx.Location = new System.Drawing.Point(104, 45);
            this.BarcodeSizeTbx.Name = "BarcodeSizeTbx";
            this.BarcodeSizeTbx.Size = new System.Drawing.Size(40, 20);
            this.BarcodeSizeTbx.TabIndex = 2;
            this.BarcodeSizeTbx.Text = "22";
            // 
            // CopyPasteButton
            // 
            this.CopyPasteButton.BackColor = System.Drawing.Color.White;
            this.CopyPasteButton.Location = new System.Drawing.Point(571, 250);
            this.CopyPasteButton.Name = "CopyPasteButton";
            this.CopyPasteButton.Size = new System.Drawing.Size(75, 40);
            this.CopyPasteButton.TabIndex = 27;
            this.CopyPasteButton.Text = "Copy Paste";
            this.CopyPasteButton.UseVisualStyleBackColor = false;
            this.CopyPasteButton.Click += new System.EventHandler(this.CopyPasteButton_Click);
            // 
            // SavePictureButton
            // 
            this.SavePictureButton.BackColor = System.Drawing.Color.White;
            this.SavePictureButton.Location = new System.Drawing.Point(733, 250);
            this.SavePictureButton.Name = "SavePictureButton";
            this.SavePictureButton.Size = new System.Drawing.Size(75, 40);
            this.SavePictureButton.TabIndex = 28;
            this.SavePictureButton.Text = "Save Picture";
            this.SavePictureButton.UseVisualStyleBackColor = false;
            this.SavePictureButton.Click += new System.EventHandler(this.SavePictureButton_Click);
            // 
            // TextSizeLabel
            // 
            this.TextSizeLabel.AutoSize = true;
            this.TextSizeLabel.Location = new System.Drawing.Point(605, 48);
            this.TextSizeLabel.Name = "TextSizeLabel";
            this.TextSizeLabel.Size = new System.Drawing.Size(52, 13);
            this.TextSizeLabel.TabIndex = 38;
            this.TextSizeLabel.Text = "Text size:";
            // 
            // TextSizeTbx
            // 
            this.TextSizeTbx.Location = new System.Drawing.Point(663, 45);
            this.TextSizeTbx.Name = "TextSizeTbx";
            this.TextSizeTbx.Size = new System.Drawing.Size(40, 20);
            this.TextSizeTbx.TabIndex = 11;
            this.TextSizeTbx.Text = "22";
            // 
            // TextFontLabel
            // 
            this.TextFontLabel.AutoSize = true;
            this.TextFontLabel.Location = new System.Drawing.Point(600, 22);
            this.TextFontLabel.Name = "TextFontLabel";
            this.TextFontLabel.Size = new System.Drawing.Size(55, 13);
            this.TextFontLabel.TabIndex = 34;
            this.TextFontLabel.Text = "Text Font:";
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new System.Drawing.Point(626, 74);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(31, 13);
            this.TextLabel.TabIndex = 35;
            this.TextLabel.Text = "Text:";
            // 
            // SetTextButton
            // 
            this.SetTextButton.BackColor = System.Drawing.Color.White;
            this.SetTextButton.Location = new System.Drawing.Point(709, 114);
            this.SetTextButton.Name = "SetTextButton";
            this.SetTextButton.Size = new System.Drawing.Size(75, 40);
            this.SetTextButton.TabIndex = 30;
            this.SetTextButton.Text = "Set";
            this.SetTextButton.UseVisualStyleBackColor = false;
            this.SetTextButton.Click += new System.EventHandler(this.SetTextButton_Click);
            // 
            // AddTextButton
            // 
            this.AddTextButton.BackColor = System.Drawing.Color.White;
            this.AddTextButton.Location = new System.Drawing.Point(628, 114);
            this.AddTextButton.Name = "AddTextButton";
            this.AddTextButton.Size = new System.Drawing.Size(75, 40);
            this.AddTextButton.TabIndex = 32;
            this.AddTextButton.Text = "Add new";
            this.AddTextButton.UseVisualStyleBackColor = false;
            this.AddTextButton.Click += new System.EventHandler(this.AddTextButton_Click);
            // 
            // TextFontCbx
            // 
            this.TextFontCbx.FormattingEnabled = true;
            this.TextFontCbx.Location = new System.Drawing.Point(663, 19);
            this.TextFontCbx.Name = "TextFontCbx";
            this.TextFontCbx.Size = new System.Drawing.Size(121, 21);
            this.TextFontCbx.TabIndex = 10;
            // 
            // TextTbx
            // 
            this.TextTbx.Location = new System.Drawing.Point(663, 71);
            this.TextTbx.Name = "TextTbx";
            this.TextTbx.Size = new System.Drawing.Size(100, 20);
            this.TextTbx.TabIndex = 12;
            this.TextTbx.Text = "valami";
            // 
            // LoadPictureButton
            // 
            this.LoadPictureButton.BackColor = System.Drawing.Color.White;
            this.LoadPictureButton.Location = new System.Drawing.Point(652, 250);
            this.LoadPictureButton.Name = "LoadPictureButton";
            this.LoadPictureButton.Size = new System.Drawing.Size(75, 40);
            this.LoadPictureButton.TabIndex = 39;
            this.LoadPictureButton.Text = "Load Picture";
            this.LoadPictureButton.UseVisualStyleBackColor = false;
            // 
            // RectChbx
            // 
            this.RectChbx.AutoSize = true;
            this.RectChbx.Location = new System.Drawing.Point(571, 172);
            this.RectChbx.Name = "RectChbx";
            this.RectChbx.Size = new System.Drawing.Size(75, 17);
            this.RectChbx.TabIndex = 41;
            this.RectChbx.Text = "Rectangle";
            this.RectChbx.UseVisualStyleBackColor = true;
            this.RectChbx.CheckStateChanged += new System.EventHandler(this.RectChbx_CheckStateChanged);
            // 
            // ExportButton
            // 
            this.ExportButton.BackColor = System.Drawing.Color.White;
            this.ExportButton.Location = new System.Drawing.Point(733, 204);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 40);
            this.ExportButton.TabIndex = 42;
            this.ExportButton.Text = "Export to PNG";
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // BarcodePrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 340);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.RectChbx);
            this.Controls.Add(this.LoadPictureButton);
            this.Controls.Add(this.TextSizeLabel);
            this.Controls.Add(this.TextSizeTbx);
            this.Controls.Add(this.TextFontLabel);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.SetTextButton);
            this.Controls.Add(this.AddTextButton);
            this.Controls.Add(this.TextFontCbx);
            this.Controls.Add(this.TextTbx);
            this.Controls.Add(this.SavePictureButton);
            this.Controls.Add(this.CopyPasteButton);
            this.Controls.Add(this.BarcodeSizeLabel);
            this.Controls.Add(this.BarcodeSizeTbx);
            this.Controls.Add(this.ResizeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BarcodeTypeLabel);
            this.Controls.Add(this.BarcodeText);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SetBarcodeButton);
            this.Controls.Add(this.PrintersList);
            this.Controls.Add(this.AddBarcodeButton);
            this.Controls.Add(this.printersLabel);
            this.Controls.Add(this.BarcodeTypeCbx);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.BarcodeTextTbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BarcodePrinter";
            this.Text = "Simpline";
            this.Load += new System.EventHandler(this.BarcodePrinter_Load);
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
        private System.Windows.Forms.Label BarcodeSizeLabel;
        private System.Windows.Forms.TextBox BarcodeSizeTbx;
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
        private System.Windows.Forms.CheckBox RectChbx;
        private System.Windows.Forms.Button ExportButton;
    }
}

