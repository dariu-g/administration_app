namespace AplicatieDisertatie
{
    partial class ledger_form
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
            this.components = new System.ComponentModel.Container();
            this.btnCauta = new System.Windows.Forms.Button();
            this.dateTimeDin = new System.Windows.Forms.DateTimePicker();
            this.dataGridLedger = new System.Windows.Forms.DataGridView();
            this.id_reparatie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nr_telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip_telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_primirii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_predarii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_constatat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observatii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piese_inlocuite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pret_achitat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePana = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.numeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledgerclassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerclassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCauta
            // 
            this.btnCauta.Location = new System.Drawing.Point(609, 40);
            this.btnCauta.Name = "btnCauta";
            this.btnCauta.Size = new System.Drawing.Size(75, 23);
            this.btnCauta.TabIndex = 0;
            this.btnCauta.Text = "Cauta";
            this.btnCauta.UseVisualStyleBackColor = true;
            this.btnCauta.Click += new System.EventHandler(this.btnCauta_Click);
            // 
            // dateTimeDin
            // 
            this.dateTimeDin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDin.Location = new System.Drawing.Point(59, 40);
            this.dateTimeDin.Name = "dateTimeDin";
            this.dateTimeDin.Size = new System.Drawing.Size(224, 22);
            this.dateTimeDin.TabIndex = 1;
            this.dateTimeDin.ValueChanged += new System.EventHandler(this.btnCauta_Click);
            // 
            // dataGridLedger
            // 
            this.dataGridLedger.AutoGenerateColumns = false;
            this.dataGridLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_reparatie,
            this.numeDataGridViewTextBoxColumn,
            this.nr_telefon,
            this.tip_telefon,
            this.model,
            this.imei,
            this.data_primirii,
            this.data_predarii,
            this.defect_constatat,
            this.observatii,
            this.piese_inlocuite,
            this.pret_achitat,
            this.prenumeDataGridViewTextBoxColumn});
            this.dataGridLedger.DataSource = this.ledgerclassBindingSource;
            this.dataGridLedger.Location = new System.Drawing.Point(23, 80);
            this.dataGridLedger.Name = "dataGridLedger";
            this.dataGridLedger.RowHeadersWidth = 51;
            this.dataGridLedger.RowTemplate.Height = 24;
            this.dataGridLedger.Size = new System.Drawing.Size(998, 463);
            this.dataGridLedger.TabIndex = 2;
            // 
            // id_reparatie
            // 
            this.id_reparatie.DataPropertyName = "id_reparatie";
            this.id_reparatie.HeaderText = "id_reparatie";
            this.id_reparatie.MinimumWidth = 6;
            this.id_reparatie.Name = "id_reparatie";
            this.id_reparatie.Width = 125;
            // 
            // nr_telefon
            // 
            this.nr_telefon.DataPropertyName = "nr_telefon";
            this.nr_telefon.HeaderText = "nr_telefon";
            this.nr_telefon.MinimumWidth = 6;
            this.nr_telefon.Name = "nr_telefon";
            this.nr_telefon.Width = 125;
            // 
            // tip_telefon
            // 
            this.tip_telefon.DataPropertyName = "tip_telefon";
            this.tip_telefon.HeaderText = "tip_telefon";
            this.tip_telefon.MinimumWidth = 6;
            this.tip_telefon.Name = "tip_telefon";
            this.tip_telefon.Width = 125;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "model";
            this.model.MinimumWidth = 6;
            this.model.Name = "model";
            this.model.Width = 125;
            // 
            // imei
            // 
            this.imei.DataPropertyName = "imei";
            this.imei.HeaderText = "imei";
            this.imei.MinimumWidth = 6;
            this.imei.Name = "imei";
            this.imei.Width = 125;
            // 
            // data_primirii
            // 
            this.data_primirii.DataPropertyName = "data_primirii";
            this.data_primirii.HeaderText = "data_primirii";
            this.data_primirii.MinimumWidth = 6;
            this.data_primirii.Name = "data_primirii";
            this.data_primirii.Width = 125;
            // 
            // data_predarii
            // 
            this.data_predarii.DataPropertyName = "data_predarii";
            this.data_predarii.HeaderText = "data_predarii";
            this.data_predarii.MinimumWidth = 6;
            this.data_predarii.Name = "data_predarii";
            this.data_predarii.Width = 125;
            // 
            // defect_constatat
            // 
            this.defect_constatat.DataPropertyName = "defect_constatat";
            this.defect_constatat.HeaderText = "defect_constatat";
            this.defect_constatat.MinimumWidth = 6;
            this.defect_constatat.Name = "defect_constatat";
            this.defect_constatat.Width = 125;
            // 
            // observatii
            // 
            this.observatii.DataPropertyName = "observatii";
            this.observatii.HeaderText = "observatii";
            this.observatii.MinimumWidth = 6;
            this.observatii.Name = "observatii";
            this.observatii.Width = 125;
            // 
            // piese_inlocuite
            // 
            this.piese_inlocuite.DataPropertyName = "piese_inlocuite";
            this.piese_inlocuite.HeaderText = "piese_inlocuite";
            this.piese_inlocuite.MinimumWidth = 6;
            this.piese_inlocuite.Name = "piese_inlocuite";
            this.piese_inlocuite.Width = 125;
            // 
            // pret_achitat
            // 
            this.pret_achitat.DataPropertyName = "pret_achitat";
            this.pret_achitat.HeaderText = "pret_achitat";
            this.pret_achitat.MinimumWidth = 6;
            this.pret_achitat.Name = "pret_achitat";
            this.pret_achitat.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Din:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pana in";
            // 
            // dateTimePana
            // 
            this.dateTimePana.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePana.Location = new System.Drawing.Point(363, 40);
            this.dateTimePana.Name = "dateTimePana";
            this.dateTimePana.Size = new System.Drawing.Size(224, 22);
            this.dateTimePana.TabIndex = 4;
            this.dateTimePana.ValueChanged += new System.EventHandler(this.btnCauta_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(946, 549);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // numeDataGridViewTextBoxColumn
            // 
            this.numeDataGridViewTextBoxColumn.DataPropertyName = "nume";
            this.numeDataGridViewTextBoxColumn.HeaderText = "nume";
            this.numeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numeDataGridViewTextBoxColumn.Name = "numeDataGridViewTextBoxColumn";
            this.numeDataGridViewTextBoxColumn.Width = 125;
            // 
            // prenumeDataGridViewTextBoxColumn
            // 
            this.prenumeDataGridViewTextBoxColumn.DataPropertyName = "prenume";
            this.prenumeDataGridViewTextBoxColumn.HeaderText = "prenume";
            this.prenumeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.prenumeDataGridViewTextBoxColumn.Name = "prenumeDataGridViewTextBoxColumn";
            this.prenumeDataGridViewTextBoxColumn.Width = 125;
            // 
            // ledgerclassBindingSource
            // 
            this.ledgerclassBindingSource.DataSource = typeof(AplicatieDisertatie.ledger_class);
            // 
            // ledger_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 602);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePana);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridLedger);
            this.Controls.Add(this.dateTimeDin);
            this.Controls.Add(this.btnCauta);
            this.Name = "ledger_form";
            this.Text = "Istoric";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerclassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCauta;
        private System.Windows.Forms.DateTimePicker dateTimeDin;
        private System.Windows.Forms.DataGridView dataGridLedger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePana;
        private System.Windows.Forms.Button btnPrint;
        /*
        private System.Windows.Forms.DataGridViewTextBoxColumn idreparatieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrtelefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiptelefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imeiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataprimiriiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datapredariiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defectconstatatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observatiiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pieseinlocuiteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretachitatDataGridViewTextBoxColumn;
        */
        private System.Windows.Forms.BindingSource ledgerclassBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_reparatie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nr_telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn tip_telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn imei;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_primirii;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_predarii;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_constatat;
        private System.Windows.Forms.DataGridViewTextBoxColumn observatii;
        private System.Windows.Forms.DataGridViewTextBoxColumn piese_inlocuite;
        private System.Windows.Forms.DataGridViewTextBoxColumn pret_achitat;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}