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
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Dir:";
            // 
            // consoleOutRichTextBox1
            // 
            this.consoleOutRichTextBox1.Location = new System.Drawing.Point(116, 76);
            this.consoleOutRichTextBox1.Name = "consoleOutRichTextBox1";
            this.consoleOutRichTextBox1.Size = new System.Drawing.Size(494, 335);
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
            this.searchButton1.Location = new System.Drawing.Point(12, 64);
            this.searchButton1.Name = "searchButton1";
            this.searchButton1.Size = new System.Drawing.Size(75, 23);
            this.searchButton1.TabIndex = 4;
            this.searchButton1.Text = "Search";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchButton1);
            this.Controls.Add(this.searchStringTextBox1);
            this.Controls.Add(this.consoleOutRichTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchLocationBox1);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

