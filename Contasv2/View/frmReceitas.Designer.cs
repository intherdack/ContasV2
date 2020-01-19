namespace Contasv2.View
{
    partial class frmReceitas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.dgvRec = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoReceita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceitas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRel = new System.Windows.Forms.Button();
            this.anoBusca = new System.Windows.Forms.TextBox();
            this.labelnome = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRec)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAlterar);
            this.groupBox3.Controls.Add(this.btnExcluir);
            this.groupBox3.Location = new System.Drawing.Point(621, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 141);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operações Receitas";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(7, 24);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(152, 46);
            this.btnAlterar.TabIndex = 37;
            this.btnAlterar.Text = "Alterar Receita";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(7, 76);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(152, 47);
            this.btnExcluir.TabIndex = 52;
            this.btnExcluir.Text = "Excluir Receita";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dgvRec
            // 
            this.dgvRec.AllowUserToAddRows = false;
            this.dgvRec.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Column1,
            this.Valor,
            this.Column2,
            this.Column3,
            this.codigoReceita});
            this.dgvRec.Location = new System.Drawing.Point(11, 87);
            this.dgvRec.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvRec.Name = "dgvRec";
            this.dgvRec.ReadOnly = true;
            this.dgvRec.Size = new System.Drawing.Size(601, 255);
            this.dgvRec.TabIndex = 57;
            // 
            // Codigo
            // 
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            this.Codigo.Width = 5;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Descricao";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Descrição";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 155;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DataCadastro";
            this.Column2.HeaderText = "Data Cadastro";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Meses";
            this.Column3.HeaderText = "Meses";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // codigoReceita
            // 
            this.codigoReceita.HeaderText = "Código da Receita";
            this.codigoReceita.Name = "codigoReceita";
            this.codigoReceita.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(449, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 25);
            this.label3.TabIndex = 59;
            this.label3.Text = "Total Receitas:";
            // 
            // txtReceitas
            // 
            this.txtReceitas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtReceitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceitas.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtReceitas.Location = new System.Drawing.Point(621, 369);
            this.txtReceitas.Name = "txtReceitas";
            this.txtReceitas.Size = new System.Drawing.Size(158, 31);
            this.txtReceitas.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Digite o ano em que deseja consultar: ";
            // 
            // btnRel
            // 
            this.btnRel.Location = new System.Drawing.Point(227, 31);
            this.btnRel.Name = "btnRel";
            this.btnRel.Size = new System.Drawing.Size(102, 23);
            this.btnRel.TabIndex = 61;
            this.btnRel.Text = "Buscar";
            this.btnRel.UseVisualStyleBackColor = true;
            this.btnRel.Click += new System.EventHandler(this.btnRel_Click);
            // 
            // anoBusca
            // 
            this.anoBusca.Location = new System.Drawing.Point(10, 31);
            this.anoBusca.Name = "anoBusca";
            this.anoBusca.Size = new System.Drawing.Size(211, 20);
            this.anoBusca.TabIndex = 60;
            this.anoBusca.TextChanged += new System.EventHandler(this.anoBusca_TextChanged);
            // 
            // labelnome
            // 
            this.labelnome.AutoSize = true;
            this.labelnome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnome.Location = new System.Drawing.Point(10, 369);
            this.labelnome.Name = "labelnome";
            this.labelnome.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelnome.Size = new System.Drawing.Size(65, 31);
            this.labelnome.TabIndex = 63;
            this.labelnome.Text = "Mês";
            this.labelnome.UseMnemonic = false;
            // 
            // frmReceitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.labelnome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRel);
            this.Controls.Add(this.anoBusca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReceitas);
            this.Controls.Add(this.dgvRec);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.Name = "frmReceitas";
            this.Text = "Receitas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReceitas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReceitas_FormClosed);
            this.Load += new System.EventHandler(this.frmReceitas_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.frmReceitas_ControlRemoved);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dgvRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoReceita;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReceitas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRel;
        private System.Windows.Forms.TextBox anoBusca;
        private System.Windows.Forms.Label labelnome;
    }
}