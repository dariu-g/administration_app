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
            this.imei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip_telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.culoare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.garantie = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.data_primirii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_predarii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defect_constatat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observatii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piese_inlocuite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pret_estimativ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pret_avans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pret_achitat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termen_rezolvare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termen_garantie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verdict_reparatie = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePana = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnDescarca = new System.Windows.Forms.Button();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.labelNume = new System.Windows.Forms.Label();
            this.btnCautaNume = new System.Windows.Forms.Button();
            this.btnNrInreg = new System.Windows.Forms.Button();
            this.labelNrInreg = new System.Windows.Forms.Label();
            this.txtNrInreg = new System.Windows.Forms.TextBox();
            this.btnNrTelefon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNrTelefon = new System.Windows.Forms.TextBox();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnReparatiiRecente = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.dateTimeDin.CustomFormat = "dd/MM/yyyy";
            this.dateTimeDin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDin.Location = new System.Drawing.Point(59, 40);
            this.dateTimeDin.Name = "dateTimeDin";
            this.dateTimeDin.Size = new System.Drawing.Size(224, 22);
            this.dateTimeDin.TabIndex = 1;
            this.dateTimeDin.ValueChanged += new System.EventHandler(this.btnCauta_Click);
            // 
            // dataGridLedger
            // 
            this.dataGridLedger.AllowUserToAddRows = false;
            this.dataGridLedger.AllowUserToDeleteRows = false;
            this.dataGridLedger.AutoGenerateColumns = false;
            this.dataGridLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_reparatie,
            this.nr_telefon,
            this.numeDataGridViewTextBoxColumn,
            this.prenumeDataGridViewTextBoxColumn,
            this.imei,
            this.tip_telefon,
            this.model,
            this.culoare,
            this.cod_telefon,
            this.garantie,
            this.data_primirii,
            this.data_predarii,
            this.defect_constatat,
            this.observatii,
            this.piese_inlocuite,
            this.pret_estimativ,
            this.pret_avans,
            this.pret_achitat,
            this.termen_rezolvare,
            this.termen_garantie,
            this.verdict_reparatie});
            this.dataGridLedger.DataSource = this.ledgerclassBindingSource;
            this.dataGridLedger.Location = new System.Drawing.Point(23, 134);
            this.dataGridLedger.Name = "dataGridLedger";
            this.dataGridLedger.ReadOnly = true;
            this.dataGridLedger.RowHeadersWidth = 51;
            this.dataGridLedger.RowTemplate.Height = 24;
            this.dataGridLedger.Size = new System.Drawing.Size(998, 409);
            this.dataGridLedger.TabIndex = 2;
            this.dataGridLedger.Click += new System.EventHandler(this.dataGridLedger_Click);
            // 
            // id_reparatie
            // 
            this.id_reparatie.DataPropertyName = "id_reparatie";
            this.id_reparatie.HeaderText = "Nr. inreg";
            this.id_reparatie.MinimumWidth = 6;
            this.id_reparatie.Name = "id_reparatie";
            this.id_reparatie.ReadOnly = true;
            this.id_reparatie.Width = 75;
            // 
            // nr_telefon
            // 
            this.nr_telefon.DataPropertyName = "nr_telefon";
            this.nr_telefon.HeaderText = "Nr. telefon";
            this.nr_telefon.MinimumWidth = 6;
            this.nr_telefon.Name = "nr_telefon";
            this.nr_telefon.ReadOnly = true;
            this.nr_telefon.Width = 125;
            // 
            // imei
            // 
            this.imei.DataPropertyName = "imei";
            this.imei.HeaderText = "IMEI";
            this.imei.MinimumWidth = 6;
            this.imei.Name = "imei";
            this.imei.ReadOnly = true;
            this.imei.Width = 140;
            // 
            // tip_telefon
            // 
            this.tip_telefon.DataPropertyName = "tip_telefon";
            this.tip_telefon.HeaderText = "Tip telefon";
            this.tip_telefon.MinimumWidth = 6;
            this.tip_telefon.Name = "tip_telefon";
            this.tip_telefon.ReadOnly = true;
            this.tip_telefon.Width = 125;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "Model";
            this.model.MinimumWidth = 6;
            this.model.Name = "model";
            this.model.ReadOnly = true;
            this.model.Width = 125;
            // 
            // culoare
            // 
            this.culoare.DataPropertyName = "culoare";
            this.culoare.HeaderText = "Culoare";
            this.culoare.MinimumWidth = 6;
            this.culoare.Name = "culoare";
            this.culoare.ReadOnly = true;
            this.culoare.Width = 125;
            // 
            // cod_telefon
            // 
            this.cod_telefon.DataPropertyName = "cod_telefon";
            this.cod_telefon.HeaderText = "Cod telefon";
            this.cod_telefon.MinimumWidth = 6;
            this.cod_telefon.Name = "cod_telefon";
            this.cod_telefon.ReadOnly = true;
            this.cod_telefon.Width = 125;
            // 
            // garantie
            // 
            this.garantie.DataPropertyName = "garantie";
            this.garantie.HeaderText = "Garantie";
            this.garantie.MinimumWidth = 6;
            this.garantie.Name = "garantie";
            this.garantie.ReadOnly = true;
            this.garantie.Width = 75;
            // 
            // data_primirii
            // 
            this.data_primirii.DataPropertyName = "data_primirii";
            this.data_primirii.HeaderText = "Data primirii";
            this.data_primirii.MinimumWidth = 6;
            this.data_primirii.Name = "data_primirii";
            this.data_primirii.ReadOnly = true;
            this.data_primirii.Width = 125;
            // 
            // data_predarii
            // 
            this.data_predarii.DataPropertyName = "data_predarii";
            this.data_predarii.HeaderText = "Data predarii";
            this.data_predarii.MinimumWidth = 6;
            this.data_predarii.Name = "data_predarii";
            this.data_predarii.ReadOnly = true;
            this.data_predarii.Width = 125;
            // 
            // defect_constatat
            // 
            this.defect_constatat.DataPropertyName = "defect_constatat";
            this.defect_constatat.HeaderText = "Defect constatat";
            this.defect_constatat.MinimumWidth = 6;
            this.defect_constatat.Name = "defect_constatat";
            this.defect_constatat.ReadOnly = true;
            this.defect_constatat.Width = 175;
            // 
            // observatii
            // 
            this.observatii.DataPropertyName = "observatii";
            this.observatii.HeaderText = "Observatii";
            this.observatii.MinimumWidth = 6;
            this.observatii.Name = "observatii";
            this.observatii.ReadOnly = true;
            this.observatii.Width = 125;
            // 
            // piese_inlocuite
            // 
            this.piese_inlocuite.DataPropertyName = "piese_inlocuite";
            this.piese_inlocuite.HeaderText = "Piese inlocuite";
            this.piese_inlocuite.MinimumWidth = 6;
            this.piese_inlocuite.Name = "piese_inlocuite";
            this.piese_inlocuite.ReadOnly = true;
            this.piese_inlocuite.Width = 125;
            // 
            // pret_estimativ
            // 
            this.pret_estimativ.DataPropertyName = "pret_estimativ";
            this.pret_estimativ.HeaderText = "Pret estimativ";
            this.pret_estimativ.MinimumWidth = 6;
            this.pret_estimativ.Name = "pret_estimativ";
            this.pret_estimativ.ReadOnly = true;
            this.pret_estimativ.Width = 125;
            // 
            // pret_avans
            // 
            this.pret_avans.DataPropertyName = "pret_avans";
            this.pret_avans.HeaderText = "Pret avans";
            this.pret_avans.MinimumWidth = 6;
            this.pret_avans.Name = "pret_avans";
            this.pret_avans.ReadOnly = true;
            this.pret_avans.Width = 125;
            // 
            // pret_achitat
            // 
            this.pret_achitat.DataPropertyName = "pret_achitat";
            this.pret_achitat.HeaderText = "Pret achitat";
            this.pret_achitat.MinimumWidth = 6;
            this.pret_achitat.Name = "pret_achitat";
            this.pret_achitat.ReadOnly = true;
            this.pret_achitat.Width = 125;
            // 
            // termen_rezolvare
            // 
            this.termen_rezolvare.DataPropertyName = "termen_rezolvare";
            this.termen_rezolvare.HeaderText = "Termen rezolvare";
            this.termen_rezolvare.MinimumWidth = 6;
            this.termen_rezolvare.Name = "termen_rezolvare";
            this.termen_rezolvare.ReadOnly = true;
            this.termen_rezolvare.Width = 125;
            // 
            // termen_garantie
            // 
            this.termen_garantie.DataPropertyName = "termen_garantie";
            this.termen_garantie.HeaderText = "Termen Garantie";
            this.termen_garantie.MinimumWidth = 6;
            this.termen_garantie.Name = "termen_garantie";
            this.termen_garantie.ReadOnly = true;
            this.termen_garantie.Width = 125;
            // 
            // verdict_reparatie
            // 
            this.verdict_reparatie.DataPropertyName = "verdict_reparatie";
            this.verdict_reparatie.HeaderText = "Verdict reparatie";
            this.verdict_reparatie.MinimumWidth = 6;
            this.verdict_reparatie.Name = "verdict_reparatie";
            this.verdict_reparatie.ReadOnly = true;
            this.verdict_reparatie.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.verdict_reparatie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.verdict_reparatie.Width = 125;
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
            this.dateTimePana.CustomFormat = "dd/MM/yyyy";
            this.dateTimePana.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePana.Location = new System.Drawing.Point(363, 40);
            this.dateTimePana.Name = "dateTimePana";
            this.dateTimePana.Size = new System.Drawing.Size(224, 22);
            this.dateTimePana.TabIndex = 4;
            this.dateTimePana.ValueChanged += new System.EventHandler(this.btnCauta_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(915, 549);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 31);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDescarca
            // 
            this.btnDescarca.Location = new System.Drawing.Point(479, 552);
            this.btnDescarca.Name = "btnDescarca";
            this.btnDescarca.Size = new System.Drawing.Size(108, 28);
            this.btnDescarca.TabIndex = 7;
            this.btnDescarca.Text = "Descarca";
            this.btnDescarca.UseVisualStyleBackColor = true;
            this.btnDescarca.Click += new System.EventHandler(this.btnDescarca_Click);
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(414, 90);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(158, 22);
            this.txtNume.TabIndex = 8;
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(362, 91);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(45, 17);
            this.labelNume.TabIndex = 9;
            this.labelNume.Text = "Nume";
            // 
            // btnCautaNume
            // 
            this.btnCautaNume.Location = new System.Drawing.Point(578, 90);
            this.btnCautaNume.Name = "btnCautaNume";
            this.btnCautaNume.Size = new System.Drawing.Size(75, 23);
            this.btnCautaNume.TabIndex = 10;
            this.btnCautaNume.Text = "Cauta";
            this.btnCautaNume.UseVisualStyleBackColor = true;
            // 
            // btnNrInreg
            // 
            this.btnNrInreg.Location = new System.Drawing.Point(252, 91);
            this.btnNrInreg.Name = "btnNrInreg";
            this.btnNrInreg.Size = new System.Drawing.Size(75, 23);
            this.btnNrInreg.TabIndex = 13;
            this.btnNrInreg.Text = "Cauta";
            this.btnNrInreg.UseVisualStyleBackColor = true;
            // 
            // labelNrInreg
            // 
            this.labelNrInreg.AutoSize = true;
            this.labelNrInreg.Location = new System.Drawing.Point(23, 92);
            this.labelNrInreg.Name = "labelNrInreg";
            this.labelNrInreg.Size = new System.Drawing.Size(59, 17);
            this.labelNrInreg.TabIndex = 12;
            this.labelNrInreg.Text = "Nr.inreg";
            // 
            // txtNrInreg
            // 
            this.txtNrInreg.Location = new System.Drawing.Point(88, 90);
            this.txtNrInreg.Name = "txtNrInreg";
            this.txtNrInreg.Size = new System.Drawing.Size(158, 22);
            this.txtNrInreg.TabIndex = 11;
            // 
            // btnNrTelefon
            // 
            this.btnNrTelefon.Location = new System.Drawing.Point(915, 91);
            this.btnNrTelefon.Name = "btnNrTelefon";
            this.btnNrTelefon.Size = new System.Drawing.Size(75, 23);
            this.btnNrTelefon.TabIndex = 16;
            this.btnNrTelefon.Text = "Cauta";
            this.btnNrTelefon.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nr.telefon";
            // 
            // txtNrTelefon
            // 
            this.txtNrTelefon.Location = new System.Drawing.Point(751, 91);
            this.txtNrTelefon.Name = "txtNrTelefon";
            this.txtNrTelefon.Size = new System.Drawing.Size(158, 22);
            this.txtNrTelefon.TabIndex = 14;
            // 
            // btnSterge
            // 
            this.btnSterge.Location = new System.Drawing.Point(23, 552);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(105, 28);
            this.btnSterge.TabIndex = 17;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnReparatiiRecente
            // 
            this.btnReparatiiRecente.Location = new System.Drawing.Point(850, 32);
            this.btnReparatiiRecente.Name = "btnReparatiiRecente";
            this.btnReparatiiRecente.Size = new System.Drawing.Size(140, 39);
            this.btnReparatiiRecente.TabIndex = 18;
            this.btnReparatiiRecente.Text = "Reparatii Recente";
            this.btnReparatiiRecente.UseVisualStyleBackColor = true;
            this.btnReparatiiRecente.Click += new System.EventHandler(this.btnReparatiiRecente_Click);
            // 
            // numeDataGridViewTextBoxColumn
            // 
            this.numeDataGridViewTextBoxColumn.DataPropertyName = "nume";
            this.numeDataGridViewTextBoxColumn.HeaderText = "Nume";
            this.numeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numeDataGridViewTextBoxColumn.Name = "numeDataGridViewTextBoxColumn";
            this.numeDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeDataGridViewTextBoxColumn.Width = 125;
            // 
            // prenumeDataGridViewTextBoxColumn
            // 
            this.prenumeDataGridViewTextBoxColumn.DataPropertyName = "prenume";
            this.prenumeDataGridViewTextBoxColumn.HeaderText = "Prenume";
            this.prenumeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.prenumeDataGridViewTextBoxColumn.Name = "prenumeDataGridViewTextBoxColumn";
            this.prenumeDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.Controls.Add(this.btnReparatiiRecente);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnNrTelefon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNrTelefon);
            this.Controls.Add(this.btnNrInreg);
            this.Controls.Add(this.labelNrInreg);
            this.Controls.Add(this.txtNrInreg);
            this.Controls.Add(this.btnCautaNume);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.btnDescarca);
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
        private System.Windows.Forms.BindingSource ledgerclassBindingSource;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnDescarca;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.Button btnCautaNume;
        private System.Windows.Forms.Button btnNrInreg;
        private System.Windows.Forms.Label labelNrInreg;
        private System.Windows.Forms.TextBox txtNrInreg;
        private System.Windows.Forms.Button btnNrTelefon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNrTelefon;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnReparatiiRecente;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_reparatie;
        private System.Windows.Forms.DataGridViewTextBoxColumn nr_telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imei;
        private System.Windows.Forms.DataGridViewTextBoxColumn tip_telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn culoare;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_telefon;
        private System.Windows.Forms.DataGridViewCheckBoxColumn garantie;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_primirii;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_predarii;
        private System.Windows.Forms.DataGridViewTextBoxColumn defect_constatat;
        private System.Windows.Forms.DataGridViewTextBoxColumn observatii;
        private System.Windows.Forms.DataGridViewTextBoxColumn piese_inlocuite;
        private System.Windows.Forms.DataGridViewTextBoxColumn pret_estimativ;
        private System.Windows.Forms.DataGridViewTextBoxColumn pret_avans;
        private System.Windows.Forms.DataGridViewTextBoxColumn pret_achitat;
        private System.Windows.Forms.DataGridViewTextBoxColumn termen_rezolvare;
        private System.Windows.Forms.DataGridViewTextBoxColumn termen_garantie;
        private System.Windows.Forms.DataGridViewCheckBoxColumn verdict_reparatie;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}