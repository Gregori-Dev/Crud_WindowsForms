
namespace CRUD
{
    partial class FormCadastro
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
            this.TbNome = new System.Windows.Forms.TextBox();
            this.TbIdade = new System.Windows.Forms.TextBox();
            this.BtSalvar = new System.Windows.Forms.Button();
            this.BtLimpar = new System.Windows.Forms.Button();
            this.BtRetornar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Idade";
            // 
            // TbNome
            // 
            this.TbNome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbNome.Location = new System.Drawing.Point(29, 102);
            this.TbNome.Name = "TbNome";
            this.TbNome.Size = new System.Drawing.Size(100, 23);
            this.TbNome.TabIndex = 2;
            // 
            // TbIdade
            // 
            this.TbIdade.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbIdade.Location = new System.Drawing.Point(29, 168);
            this.TbIdade.Name = "TbIdade";
            this.TbIdade.Size = new System.Drawing.Size(100, 23);
            this.TbIdade.TabIndex = 3;
            // 
            // BtSalvar
            // 
            this.BtSalvar.Location = new System.Drawing.Point(378, 276);
            this.BtSalvar.Name = "BtSalvar";
            this.BtSalvar.Size = new System.Drawing.Size(75, 23);
            this.BtSalvar.TabIndex = 4;
            this.BtSalvar.Text = "Salvar";
            this.BtSalvar.UseVisualStyleBackColor = true;
            this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // BtLimpar
            // 
            this.BtLimpar.Location = new System.Drawing.Point(29, 276);
            this.BtLimpar.Name = "BtLimpar";
            this.BtLimpar.Size = new System.Drawing.Size(117, 23);
            this.BtLimpar.TabIndex = 5;
            this.BtLimpar.Text = "Limpar campos";
            this.BtLimpar.UseVisualStyleBackColor = true;
            this.BtLimpar.Click += new System.EventHandler(this.BtLimpar_Click);
            // 
            // BtRetornar
            // 
            this.BtRetornar.Location = new System.Drawing.Point(459, 276);
            this.BtRetornar.Name = "BtRetornar";
            this.BtRetornar.Size = new System.Drawing.Size(75, 23);
            this.BtRetornar.TabIndex = 6;
            this.BtRetornar.Text = "Cancelar";
            this.BtRetornar.UseVisualStyleBackColor = true;
            this.BtRetornar.Click += new System.EventHandler(this.BtRetornar_Click);
            // 
            // FormCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.BtRetornar);
            this.Controls.Add(this.BtLimpar);
            this.Controls.Add(this.BtSalvar);
            this.Controls.Add(this.TbIdade);
            this.Controls.Add(this.TbNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCadastro";
            this.Text = "FormCadastro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbNome;
        private System.Windows.Forms.TextBox TbIdade;
        private System.Windows.Forms.Button BtSalvar;
        private System.Windows.Forms.Button BtLimpar;
        private System.Windows.Forms.Button BtRetornar;
    }
}