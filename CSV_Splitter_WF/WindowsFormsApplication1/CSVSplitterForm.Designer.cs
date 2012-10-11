namespace WindowsFormsApplication1
{
    partial class CSVSplitterForm
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
            this.csvLabel = new System.Windows.Forms.Label();
            this.nolLabel = new System.Windows.Forms.Label();
            this.maxPiecesLabel = new System.Windows.Forms.Label();
            this.nol_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxPieces_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.csv_TextBox = new System.Windows.Forms.TextBox();
            this.browse_Button = new System.Windows.Forms.Button();
            this.splitNow_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nol_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPieces_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // csvLabel
            // 
            this.csvLabel.AutoSize = true;
            this.csvLabel.Location = new System.Drawing.Point(14, 29);
            this.csvLabel.Name = "csvLabel";
            this.csvLabel.Size = new System.Drawing.Size(50, 13);
            this.csvLabel.TabIndex = 0;
            this.csvLabel.Text = "CSV File:";
            // 
            // nolLabel
            // 
            this.nolLabel.AutoSize = true;
            this.nolLabel.Location = new System.Drawing.Point(14, 60);
            this.nolLabel.Name = "nolLabel";
            this.nolLabel.Size = new System.Drawing.Size(87, 13);
            this.nolLabel.TabIndex = 1;
            this.nolLabel.Text = "Number of Lines:";
            // 
            // maxPiecesLabel
            // 
            this.maxPiecesLabel.AutoSize = true;
            this.maxPiecesLabel.Location = new System.Drawing.Point(14, 95);
            this.maxPiecesLabel.Name = "maxPiecesLabel";
            this.maxPiecesLabel.Size = new System.Drawing.Size(65, 13);
            this.maxPiecesLabel.TabIndex = 2;
            this.maxPiecesLabel.Text = "Max Pieces:";
            // 
            // nol_NumericUpDown
            // 
            this.nol_NumericUpDown.Location = new System.Drawing.Point(103, 58);
            this.nol_NumericUpDown.Name = "nol_NumericUpDown";
            this.nol_NumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.nol_NumericUpDown.TabIndex = 3;
            // 
            // maxPieces_NumericUpDown
            // 
            this.maxPieces_NumericUpDown.Location = new System.Drawing.Point(103, 88);
            this.maxPieces_NumericUpDown.Name = "maxPieces_NumericUpDown";
            this.maxPieces_NumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.maxPieces_NumericUpDown.TabIndex = 4;
            // 
            // csv_TextBox
            // 
            this.csv_TextBox.Location = new System.Drawing.Point(103, 26);
            this.csv_TextBox.Name = "csv_TextBox";
            this.csv_TextBox.Size = new System.Drawing.Size(245, 20);
            this.csv_TextBox.TabIndex = 5;
            // 
            // browse_Button
            // 
            this.browse_Button.Location = new System.Drawing.Point(381, 23);
            this.browse_Button.Name = "browse_Button";
            this.browse_Button.Size = new System.Drawing.Size(75, 23);
            this.browse_Button.TabIndex = 6;
            this.browse_Button.Text = "Browse File";
            this.browse_Button.UseVisualStyleBackColor = true;
            this.browse_Button.Click += new System.EventHandler(this.browse_Button_Click);
            // 
            // splitNow_Button
            // 
            this.splitNow_Button.Location = new System.Drawing.Point(381, 55);
            this.splitNow_Button.Name = "splitNow_Button";
            this.splitNow_Button.Size = new System.Drawing.Size(75, 23);
            this.splitNow_Button.TabIndex = 7;
            this.splitNow_Button.Text = "Split Now!";
            this.splitNow_Button.UseVisualStyleBackColor = true;
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(381, 85);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 8;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            // 
            // CVSSplitterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 162);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.splitNow_Button);
            this.Controls.Add(this.browse_Button);
            this.Controls.Add(this.csv_TextBox);
            this.Controls.Add(this.maxPieces_NumericUpDown);
            this.Controls.Add(this.nol_NumericUpDown);
            this.Controls.Add(this.maxPiecesLabel);
            this.Controls.Add(this.nolLabel);
            this.Controls.Add(this.csvLabel);
            this.Name = "CVSSplitterForm";
            this.Text = "CVS Splitter";
            ((System.ComponentModel.ISupportInitialize)(this.nol_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPieces_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label csvLabel;
        private System.Windows.Forms.Label nolLabel;
        private System.Windows.Forms.Label maxPiecesLabel;
        private System.Windows.Forms.NumericUpDown nol_NumericUpDown;
        private System.Windows.Forms.NumericUpDown maxPieces_NumericUpDown;
        private System.Windows.Forms.TextBox csv_TextBox;
        private System.Windows.Forms.Button splitNow_Button;
        private System.Windows.Forms.Button cancel_Button;
        internal System.Windows.Forms.Button browse_Button;
    }
}

