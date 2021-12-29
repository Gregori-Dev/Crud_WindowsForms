
namespace CRUD
{
    partial class FormMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalhesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Deletar = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV_List = new System.Windows.Forms.DataGridView();
            this.BSair_Menu = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_List)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.detalhesToolStripMenuItem,
            this.Deletar});
            this.menuStrip1.Location = new System.Drawing.Point(335, 225);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(182, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.cadastroToolStripMenuItem.Text = "Cadastrar";
            this.cadastroToolStripMenuItem.Click += new System.EventHandler(this.cadastroToolStripMenuItem_Click);
            // 
            // detalhesToolStripMenuItem
            // 
            this.detalhesToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.detalhesToolStripMenuItem.Name = "detalhesToolStripMenuItem";
            this.detalhesToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.detalhesToolStripMenuItem.Text = "Editar";
            this.detalhesToolStripMenuItem.Click += new System.EventHandler(this.detalhesToolStripMenuItem_Click);
            // 
            // Deletar
            // 
            this.Deletar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Deletar.Name = "Deletar";
            this.Deletar.Size = new System.Drawing.Size(56, 20);
            this.Deletar.Text = "Deletar";
            this.Deletar.Click += new System.EventHandler(this.Deletar_Click);
            // 
            // DGV_List
            // 
            this.DGV_List.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_List.Location = new System.Drawing.Point(9, 12);
            this.DGV_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGV_List.Name = "DGV_List";
            this.DGV_List.RowTemplate.Height = 25;
            this.DGV_List.Size = new System.Drawing.Size(510, 213);
            this.DGV_List.TabIndex = 1;
            // 
            // BSair_Menu
            // 
            this.BSair_Menu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BSair_Menu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BSair_Menu.Location = new System.Drawing.Point(9, 225);
            this.BSair_Menu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BSair_Menu.Name = "BSair_Menu";
            this.BSair_Menu.Size = new System.Drawing.Size(78, 25);
            this.BSair_Menu.TabIndex = 2;
            this.BSair_Menu.Text = "Sair";
            this.BSair_Menu.UseVisualStyleBackColor = false;
            this.BSair_Menu.Click += new System.EventHandler(this.BSair_Menu_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(528, 248);
            this.Controls.Add(this.BSair_Menu);
            this.Controls.Add(this.DGV_List);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMenu";
            this.Text = "Inicio";
          
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalhesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Deletar;
        private System.Windows.Forms.DataGridView DGV_List;
        private System.Windows.Forms.Button BSair_Menu;
    }
}

