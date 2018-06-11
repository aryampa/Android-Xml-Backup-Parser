namespace Android_XML_SMS_BACKUP_PARSER
{
    partial class Main
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
            this.tbxPrevXml = new System.Windows.Forms.TextBox();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxParsePrev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.rbtnText = new System.Windows.Forms.RadioButton();
            this.rbtnExcel = new System.Windows.Forms.RadioButton();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxPrevXml
            // 
            this.tbxPrevXml.Location = new System.Drawing.Point(13, 62);
            this.tbxPrevXml.Multiline = true;
            this.tbxPrevXml.Name = "tbxPrevXml";
            this.tbxPrevXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxPrevXml.Size = new System.Drawing.Size(262, 252);
            this.tbxPrevXml.TabIndex = 0;
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(13, 5);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(100, 35);
            this.btnLoadXML.TabIndex = 1;
            this.btnLoadXML.Text = "Load XML FILE";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "XML Preview:";
            // 
            // tbxParsePrev
            // 
            this.tbxParsePrev.Location = new System.Drawing.Point(296, 62);
            this.tbxParsePrev.Multiline = true;
            this.tbxParsePrev.Name = "tbxParsePrev";
            this.tbxParsePrev.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxParsePrev.Size = new System.Drawing.Size(347, 252);
            this.tbxParsePrev.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(293, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parsing Results:";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(524, 1);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(118, 35);
            this.btnParse.TabIndex = 5;
            this.btnParse.Text = "Parse XML";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // rbtnText
            // 
            this.rbtnText.AutoSize = true;
            this.rbtnText.Location = new System.Drawing.Point(293, 362);
            this.rbtnText.Name = "rbtnText";
            this.rbtnText.Size = new System.Drawing.Size(71, 17);
            this.rbtnText.TabIndex = 6;
            this.rbtnText.TabStop = true;
            this.rbtnText.Text = "Text/Doc";
            this.rbtnText.UseVisualStyleBackColor = true;
            // 
            // rbtnExcel
            // 
            this.rbtnExcel.AutoSize = true;
            this.rbtnExcel.Location = new System.Drawing.Point(293, 339);
            this.rbtnExcel.Name = "rbtnExcel";
            this.rbtnExcel.Size = new System.Drawing.Size(77, 17);
            this.rbtnExcel.TabIndex = 7;
            this.rbtnExcel.TabStop = true;
            this.rbtnExcel.Text = "Excel/CSV";
            this.rbtnExcel.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(524, 339);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(117, 35);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create File";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblStats
            // 
            this.lblStats.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStats.ForeColor = System.Drawing.Color.Red;
            this.lblStats.Location = new System.Drawing.Point(13, 321);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(274, 58);
            this.lblStats.TabIndex = 9;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 382);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.rbtnExcel);
            this.Controls.Add(this.rbtnText);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxParsePrev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadXML);
            this.Controls.Add(this.tbxPrevXml);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPrevXml;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxParsePrev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.RadioButton rbtnText;
        private System.Windows.Forms.RadioButton rbtnExcel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblStats;
    }
}

