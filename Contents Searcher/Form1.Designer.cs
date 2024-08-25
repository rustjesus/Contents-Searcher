namespace Contents_Searcher
{
    partial class Form1
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
            this.searchLocationBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.consoleOutRichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.searchStringTextBox1 = new System.Windows.Forms.TextBox();
            this.searchButton1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileTypesTextBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.altSearchButton1 = new System.Windows.Forms.Button();
            this.resultsCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchLocationBox1
            // 
            this.searchLocationBox1.Location = new System.Drawing.Point(80, 12);
            this.searchLocationBox1.Name = "searchLocationBox1";
            this.searchLocationBox1.Size = new System.Drawing.Size(530, 20);
            this.searchLocationBox1.TabIndex = 0;
            this.searchLocationBox1.TextChanged += new System.EventHandler(this.searchLocationBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Dir:";
            // 
            // consoleOutRichTextBox1
            // 
            this.consoleOutRichTextBox1.Location = new System.Drawing.Point(93, 90);
            this.consoleOutRichTextBox1.Name = "consoleOutRichTextBox1";
            this.consoleOutRichTextBox1.Size = new System.Drawing.Size(517, 374);
            this.consoleOutRichTextBox1.TabIndex = 2;
            this.consoleOutRichTextBox1.Text = "";
            // 
            // searchStringTextBox1
            // 
            this.searchStringTextBox1.Location = new System.Drawing.Point(80, 38);
            this.searchStringTextBox1.Name = "searchStringTextBox1";
            this.searchStringTextBox1.Size = new System.Drawing.Size(530, 20);
            this.searchStringTextBox1.TabIndex = 3;
            this.searchStringTextBox1.TextChanged += new System.EventHandler(this.searchStringTextBox1_TextChanged);
            // 
            // searchButton1
            // 
            this.searchButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.searchButton1.Location = new System.Drawing.Point(3, 90);
            this.searchButton1.Name = "searchButton1";
            this.searchButton1.Size = new System.Drawing.Size(90, 23);
            this.searchButton1.TabIndex = 4;
            this.searchButton1.Text = "Deep Search";
            this.searchButton1.UseVisualStyleBackColor = true;
            this.searchButton1.Click += new System.EventHandler(this.searchButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search String:";
            // 
            // fileTypesTextBox1
            // 
            this.fileTypesTextBox1.Location = new System.Drawing.Point(80, 64);
            this.fileTypesTextBox1.Name = "fileTypesTextBox1";
            this.fileTypesTextBox1.Size = new System.Drawing.Size(530, 20);
            this.fileTypesTextBox1.TabIndex = 6;
            this.fileTypesTextBox1.TextChanged += new System.EventHandler(this.fileTypesTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Types:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(898, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "v1.0.2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Location = new System.Drawing.Point(618, 28);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(321, 436);
            this.panelButtons.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(618, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Open Location Found:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(3, 546);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(607, 10);
            this.progressBar1.TabIndex = 12;
            // 
            // altSearchButton1
            // 
            this.altSearchButton1.Location = new System.Drawing.Point(3, 119);
            this.altSearchButton1.Name = "altSearchButton1";
            this.altSearchButton1.Size = new System.Drawing.Size(90, 23);
            this.altSearchButton1.TabIndex = 13;
            this.altSearchButton1.Text = "Root Search";
            this.altSearchButton1.UseVisualStyleBackColor = true;
            this.altSearchButton1.Click += new System.EventHandler(this.altSearchButton1_Click);
            // 
            // resultsCountLabel
            // 
            this.resultsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsCountLabel.AutoSize = true;
            this.resultsCountLabel.Location = new System.Drawing.Point(0, 530);
            this.resultsCountLabel.Name = "resultsCountLabel";
            this.resultsCountLabel.Size = new System.Drawing.Size(102, 13);
            this.resultsCountLabel.TabIndex = 14;
            this.resultsCountLabel.Text = "Results: 324325345";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 565);
            this.Controls.Add(this.resultsCountLabel);
            this.Controls.Add(this.altSearchButton1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileTypesTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchButton1);
            this.Controls.Add(this.searchStringTextBox1);
            this.Controls.Add(this.consoleOutRichTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchLocationBox1);
            this.Name = "Form1";
            this.Text = "Any File Contents Searcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchLocationBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox consoleOutRichTextBox1;
        private System.Windows.Forms.TextBox searchStringTextBox1;
        private System.Windows.Forms.Button searchButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fileTypesTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button altSearchButton1;
        private System.Windows.Forms.Label resultsCountLabel;
    }
}

