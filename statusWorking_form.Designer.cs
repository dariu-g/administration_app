namespace AplicatieDisertatie
{
    partial class statusWorking_form
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
            this.dataGridViewReparatii = new System.Windows.Forms.DataGridView();
            this.labelPretAchitat = new System.Windows.Forms.Label();
            this.checkBoxVerdictReparatie = new System.Windows.Forms.CheckBox();
            this.txtPretAchitat = new System.Windows.Forms.TextBox();
            this.txtPieseInlocuite = new System.Windows.Forms.TextBox();
            this.labelPieseInlocuite = new System.Windows.Forms.Label();
            this.txtTermenGarantie = new System.Windows.Forms.TextBox();
            this.labelTermenGarantie = new System.Windows.Forms.Label();
            this.dateTimeDataPredarii = new System.Windows.Forms.DateTimePicker();
            this.labelDataPredarii = new System.Windows.Forms.Label();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReparatii)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReparatii
            // 
            this.dataGridViewReparatii.AllowUserToAddRows = false;
            this.dataGridViewReparatii.AllowUserToDeleteRows = false;
            this.dataGridViewReparatii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReparatii.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewReparatii.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReparatii.Name = "dataGridViewReparatii";
            this.dataGridViewReparatii.ReadOnly = true;
            this.dataGridViewReparatii.RowHeadersWidth = 51;
            this.dataGridViewReparatii.RowTemplate.Height = 24;
            this.dataGridViewReparatii.Size = new System.Drawing.Size(1021, 388);
            this.dataGridViewReparatii.TabIndex = 0;
            this.dataGridViewReparatii.Click += new System.EventHandler(this.dataGridViewReparatii_Click);
            // 
            // labelPretAchitat
            // 
            this.labelPretAchitat.AutoSize = true;
            this.labelPretAchitat.Location = new System.Drawing.Point(357, 543);
            this.labelPretAchitat.Name = "labelPretAchitat";
            this.labelPretAchitat.Size = new System.Drawing.Size(104, 17);
            this.labelPretAchitat.TabIndex = 1;
            this.labelPretAchitat.Text = "Pret de achitat:";
            // 
            // checkBoxVerdictReparatie
            // 
            this.checkBoxVerdictReparatie.AutoSize = true;
            this.checkBoxVerdictReparatie.Location = new System.Drawing.Point(493, 572);
            this.checkBoxVerdictReparatie.Name = "checkBoxVerdictReparatie";
            this.checkBoxVerdictReparatie.Size = new System.Drawing.Size(38, 21);
            this.checkBoxVerdictReparatie.TabIndex = 4;
            this.checkBoxVerdictReparatie.Text = "?";
            this.checkBoxVerdictReparatie.UseVisualStyleBackColor = true;
            this.checkBoxVerdictReparatie.CheckStateChanged += new System.EventHandler(this.checkBoxVerdictReparatie_CheckStateChanged);
            // 
            // txtPretAchitat
            // 
            this.txtPretAchitat.Location = new System.Drawing.Point(493, 538);
            this.txtPretAchitat.MaxLength = 9;
            this.txtPretAchitat.Name = "txtPretAchitat";
            this.txtPretAchitat.Size = new System.Drawing.Size(242, 22);
            this.txtPretAchitat.TabIndex = 3;
            // 
            // txtPieseInlocuite
            // 
            this.txtPieseInlocuite.Location = new System.Drawing.Point(493, 455);
            this.txtPieseInlocuite.MaxLength = 500;
            this.txtPieseInlocuite.Multiline = true;
            this.txtPieseInlocuite.Name = "txtPieseInlocuite";
            this.txtPieseInlocuite.Size = new System.Drawing.Size(242, 49);
            this.txtPieseInlocuite.TabIndex = 1;
            // 
            // labelPieseInlocuite
            // 
            this.labelPieseInlocuite.AutoSize = true;
            this.labelPieseInlocuite.Location = new System.Drawing.Point(357, 458);
            this.labelPieseInlocuite.Name = "labelPieseInlocuite";
            this.labelPieseInlocuite.Size = new System.Drawing.Size(103, 17);
            this.labelPieseInlocuite.TabIndex = 4;
            this.labelPieseInlocuite.Text = "Piese inlocuite:";
            // 
            // txtTermenGarantie
            // 
            this.txtTermenGarantie.Location = new System.Drawing.Point(493, 510);
            this.txtTermenGarantie.MaxLength = 50;
            this.txtTermenGarantie.Name = "txtTermenGarantie";
            this.txtTermenGarantie.Size = new System.Drawing.Size(242, 22);
            this.txtTermenGarantie.TabIndex = 2;
            // 
            // labelTermenGarantie
            // 
            this.labelTermenGarantie.AutoSize = true;
            this.labelTermenGarantie.Location = new System.Drawing.Point(357, 513);
            this.labelTermenGarantie.Name = "labelTermenGarantie";
            this.labelTermenGarantie.Size = new System.Drawing.Size(117, 17);
            this.labelTermenGarantie.TabIndex = 6;
            this.labelTermenGarantie.Text = "Termen garantie:";
            // 
            // dateTimeDataPredarii
            // 
            this.dateTimeDataPredarii.CustomFormat = "dd/MM/yyyy";
            this.dateTimeDataPredarii.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDataPredarii.Location = new System.Drawing.Point(493, 418);
            this.dateTimeDataPredarii.Name = "dateTimeDataPredarii";
            this.dateTimeDataPredarii.ShowCheckBox = true;
            this.dateTimeDataPredarii.Size = new System.Drawing.Size(242, 22);
            this.dateTimeDataPredarii.TabIndex = 8;
            // 
            // labelDataPredarii
            // 
            this.labelDataPredarii.AutoSize = true;
            this.labelDataPredarii.Location = new System.Drawing.Point(357, 418);
            this.labelDataPredarii.Name = "labelDataPredarii";
            this.labelDataPredarii.Size = new System.Drawing.Size(90, 17);
            this.labelDataPredarii.TabIndex = 9;
            this.labelDataPredarii.Text = "Data predarii";
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(493, 612);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(87, 38);
            this.btnSalveaza.TabIndex = 5;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 572);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Verdict reparatie:";
            // 
            // statusWorking_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 660);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.labelDataPredarii);
            this.Controls.Add(this.dateTimeDataPredarii);
            this.Controls.Add(this.txtTermenGarantie);
            this.Controls.Add(this.labelTermenGarantie);
            this.Controls.Add(this.txtPieseInlocuite);
            this.Controls.Add(this.labelPieseInlocuite);
            this.Controls.Add(this.txtPretAchitat);
            this.Controls.Add(this.checkBoxVerdictReparatie);
            this.Controls.Add(this.labelPretAchitat);
            this.Controls.Add(this.dataGridViewReparatii);
            this.Name = "statusWorking_form";
            this.Text = "Status - in lucru";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReparatii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReparatii;
        private System.Windows.Forms.Label labelPretAchitat;
        private System.Windows.Forms.CheckBox checkBoxVerdictReparatie;
        private System.Windows.Forms.TextBox txtPretAchitat;
        private System.Windows.Forms.TextBox txtPieseInlocuite;
        private System.Windows.Forms.Label labelPieseInlocuite;
        private System.Windows.Forms.TextBox txtTermenGarantie;
        private System.Windows.Forms.Label labelTermenGarantie;
        private System.Windows.Forms.DateTimePicker dateTimeDataPredarii;
        private System.Windows.Forms.Label labelDataPredarii;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Label label1;
    }
}