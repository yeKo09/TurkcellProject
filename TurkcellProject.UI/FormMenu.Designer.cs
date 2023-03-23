
namespace TurkcellProject.UI
{
    partial class FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.varlıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varlıkListelemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varlıkGüncellemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıZimmetiRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekipZimmetiRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.varlıkToolStripMenuItem,
            this.raporToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1086, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // varlıkToolStripMenuItem
            // 
            this.varlıkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.varlıkListelemeToolStripMenuItem,
            this.varlıkGüncellemeToolStripMenuItem});
            this.varlıkToolStripMenuItem.Name = "varlıkToolStripMenuItem";
            this.varlıkToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.varlıkToolStripMenuItem.Text = "Varlık";
            // 
            // varlıkListelemeToolStripMenuItem
            // 
            this.varlıkListelemeToolStripMenuItem.Name = "varlıkListelemeToolStripMenuItem";
            this.varlıkListelemeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.varlıkListelemeToolStripMenuItem.Text = "Varlık Listeleme";
            this.varlıkListelemeToolStripMenuItem.Click += new System.EventHandler(this.varlıkListelemeToolStripMenuItem_Click);
            // 
            // varlıkGüncellemeToolStripMenuItem
            // 
            this.varlıkGüncellemeToolStripMenuItem.Name = "varlıkGüncellemeToolStripMenuItem";
            this.varlıkGüncellemeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.varlıkGüncellemeToolStripMenuItem.Text = "Varlık Güncelleme";
            this.varlıkGüncellemeToolStripMenuItem.Click += new System.EventHandler(this.varlıkGüncellemeToolStripMenuItem_Click);
            // 
            // raporToolStripMenuItem
            // 
            this.raporToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıZimmetiRaporuToolStripMenuItem,
            this.ekipZimmetiRaporuToolStripMenuItem});
            this.raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            this.raporToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.raporToolStripMenuItem.Text = "Rapor";
            // 
            // kullanıcıZimmetiRaporuToolStripMenuItem
            // 
            this.kullanıcıZimmetiRaporuToolStripMenuItem.Name = "kullanıcıZimmetiRaporuToolStripMenuItem";
            this.kullanıcıZimmetiRaporuToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.kullanıcıZimmetiRaporuToolStripMenuItem.Text = "Kullanıcı Zimmeti Raporu";
            this.kullanıcıZimmetiRaporuToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıZimmetiRaporuToolStripMenuItem_Click);
            // 
            // ekipZimmetiRaporuToolStripMenuItem
            // 
            this.ekipZimmetiRaporuToolStripMenuItem.Name = "ekipZimmetiRaporuToolStripMenuItem";
            this.ekipZimmetiRaporuToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.ekipZimmetiRaporuToolStripMenuItem.Text = "Ekip Zimmeti Raporu";
            this.ekipZimmetiRaporuToolStripMenuItem.Click += new System.EventHandler(this.ekipZimmetiRaporuToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 605);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem varlıkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem varlıkListelemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem varlıkGüncellemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıZimmetiRaporuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekipZimmetiRaporuToolStripMenuItem;
    }
}