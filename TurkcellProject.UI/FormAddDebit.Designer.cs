
namespace TurkcellProject.UI
{
    partial class FormAddDebit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDebitOwner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDebitReason = new System.Windows.Forms.ComboBox();
            this.cmbDebitType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtEntryDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.btnAddDebit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(72, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zimmet Ata";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(74, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zimmet Sahibi";
            // 
            // txtDebitOwner
            // 
            this.txtDebitOwner.Location = new System.Drawing.Point(77, 114);
            this.txtDebitOwner.Name = "txtDebitOwner";
            this.txtDebitOwner.Size = new System.Drawing.Size(219, 20);
            this.txtDebitOwner.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(77, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zimmet Nedeni";
            // 
            // cmbDebitReason
            // 
            this.cmbDebitReason.FormattingEnabled = true;
            this.cmbDebitReason.Location = new System.Drawing.Point(80, 179);
            this.cmbDebitReason.Name = "cmbDebitReason";
            this.cmbDebitReason.Size = new System.Drawing.Size(216, 21);
            this.cmbDebitReason.TabIndex = 4;
            // 
            // cmbDebitType
            // 
            this.cmbDebitType.FormattingEnabled = true;
            this.cmbDebitType.Location = new System.Drawing.Point(81, 243);
            this.cmbDebitType.Name = "cmbDebitType";
            this.cmbDebitType.Size = new System.Drawing.Size(215, 21);
            this.cmbDebitType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(77, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Zimmet Türü";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(77, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Zimmet Başlangıç Tarihi";
            // 
            // dtEntryDate
            // 
            this.dtEntryDate.Location = new System.Drawing.Point(80, 313);
            this.dtEntryDate.MinDate = new System.DateTime(2023, 3, 22, 0, 0, 0, 0);
            this.dtEntryDate.Name = "dtEntryDate";
            this.dtEntryDate.Size = new System.Drawing.Size(216, 20);
            this.dtEntryDate.TabIndex = 8;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(80, 380);
            this.dtEndDate.MinDate = new System.DateTime(2023, 3, 22, 0, 0, 0, 0);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(216, 20);
            this.dtEndDate.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(77, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Zimmet Bitiş Tarihi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(78, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Açıklama";
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Location = new System.Drawing.Point(79, 448);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(217, 83);
            this.rtxtDescription.TabIndex = 12;
            this.rtxtDescription.Text = "";
            // 
            // btnAddDebit
            // 
            this.btnAddDebit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddDebit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAddDebit.Location = new System.Drawing.Point(137, 550);
            this.btnAddDebit.Name = "btnAddDebit";
            this.btnAddDebit.Size = new System.Drawing.Size(97, 36);
            this.btnAddDebit.TabIndex = 13;
            this.btnAddDebit.Text = "Zimmet Ata";
            this.btnAddDebit.UseVisualStyleBackColor = false;
            this.btnAddDebit.Click += new System.EventHandler(this.btnAddDebit_Click);
            // 
            // FormAddDebit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 598);
            this.Controls.Add(this.btnAddDebit);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtEntryDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDebitType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDebitReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDebitOwner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddDebit";
            this.Text = "FormAddDebit";
            this.Load += new System.EventHandler(this.FormAddDebit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDebitOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDebitReason;
        private System.Windows.Forms.ComboBox cmbDebitType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtEntryDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Button btnAddDebit;
    }
}