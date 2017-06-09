namespace RequestIt
{
    partial class Navigation
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
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosGerenciaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storageReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.menuToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1109, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.requestsToolStripMenuItem,
            this.relatóriosGerenciaisToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.productsToolStripMenuItem.Text = "&Produtos";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.simpleProductToolStripMenuItem_Click);
            // 
            // requestsToolStripMenuItem
            // 
            this.requestsToolStripMenuItem.Name = "requestsToolStripMenuItem";
            this.requestsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.requestsToolStripMenuItem.Text = "&Requisições";
            this.requestsToolStripMenuItem.Click += new System.EventHandler(this.requestsToolStripMenuItem_Click);
            // 
            // relatóriosGerenciaisToolStripMenuItem
            // 
            this.relatóriosGerenciaisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestsReportToolStripMenuItem,
            this.storageReportToolStripMenuItem});
            this.relatóriosGerenciaisToolStripMenuItem.Name = "relatóriosGerenciaisToolStripMenuItem";
            this.relatóriosGerenciaisToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.relatóriosGerenciaisToolStripMenuItem.Text = "Relatórios &gerenciais";
            // 
            // requestsReportToolStripMenuItem
            // 
            this.requestsReportToolStripMenuItem.Name = "requestsReportToolStripMenuItem";
            this.requestsReportToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.requestsReportToolStripMenuItem.Text = "Relatório de requisições";
            this.requestsReportToolStripMenuItem.Click += new System.EventHandler(this.requestsReportToolStripMenuItem_Click);
            // 
            // storageReportToolStripMenuItem
            // 
            this.storageReportToolStripMenuItem.Name = "storageReportToolStripMenuItem";
            this.storageReportToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.storageReportToolStripMenuItem.Text = "Relatório de saídas do estoque";
            this.storageReportToolStripMenuItem.Click += new System.EventHandler(this.storageReportToolStripMenuItem_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 594);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Navigation";
            this.Text = "Navigation";
            this.Load += new System.EventHandler(this.Navigation_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosGerenciaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storageReportToolStripMenuItem;
    }
}