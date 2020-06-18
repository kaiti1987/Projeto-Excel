namespace Excel.Front
{
    partial class FormExcel
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboDisplayType = new System.Windows.Forms.ComboBox();
            this.lblDisplayType = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gdvOperations = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.btnGenerateData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOperations)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDisplayType
            // 
            this.cboDisplayType.FormattingEnabled = true;
            this.cboDisplayType.Location = new System.Drawing.Point(40, 28);
            this.cboDisplayType.Name = "cboDisplayType";
            this.cboDisplayType.Size = new System.Drawing.Size(140, 21);
            this.cboDisplayType.TabIndex = 0;
            // 
            // lblDisplayType
            // 
            this.lblDisplayType.AutoSize = true;
            this.lblDisplayType.Location = new System.Drawing.Point(37, 9);
            this.lblDisplayType.Name = "lblDisplayType";
            this.lblDisplayType.Size = new System.Drawing.Size(90, 13);
            this.lblDisplayType.TabIndex = 1;
            this.lblDisplayType.Text = "Tipo Visualização";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(186, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gdvOperations
            // 
            this.gdvOperations.AllowUserToAddRows = false;
            this.gdvOperations.AllowUserToDeleteRows = false;
            this.gdvOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvOperations.Location = new System.Drawing.Point(40, 75);
            this.gdvOperations.Name = "gdvOperations";
            this.gdvOperations.ReadOnly = true;
            this.gdvOperations.ShowEditingIcon = false;
            this.gdvOperations.Size = new System.Drawing.Size(1150, 556);
            this.gdvOperations.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(354, 26);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(160, 23);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Exportar Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCsv
            // 
            this.btnCsv.Location = new System.Drawing.Point(520, 26);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(160, 23);
            this.btnCsv.TabIndex = 5;
            this.btnCsv.Text = "Exportar Csv";
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Visible = false;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.Location = new System.Drawing.Point(1030, 28);
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.Size = new System.Drawing.Size(160, 23);
            this.btnGenerateData.TabIndex = 6;
            this.btnGenerateData.Text = "Gerar Massa de Dados";
            this.btnGenerateData.UseVisualStyleBackColor = true;
            this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 708);
            this.Controls.Add(this.btnGenerateData);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.gdvOperations);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblDisplayType);
            this.Controls.Add(this.cboDisplayType);
            this.Name = "FormExcel";
            this.Text = "Excel";
            ((System.ComponentModel.ISupportInitialize)(this.gdvOperations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDisplayType;
        private System.Windows.Forms.Label lblDisplayType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView gdvOperations;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.Button btnGenerateData;
    }
}

