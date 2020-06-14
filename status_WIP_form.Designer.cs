namespace AplicatieDisertatie
{
    partial class status_WIP_form
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
            this.btnAfiseaza = new System.Windows.Forms.Button();
            this.btnSalveaza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReparatii)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReparatii
            // 
            this.dataGridViewReparatii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReparatii.Location = new System.Drawing.Point(12, 36);
            this.dataGridViewReparatii.Name = "dataGridViewReparatii";
            this.dataGridViewReparatii.ReadOnly = true;
            this.dataGridViewReparatii.RowHeadersWidth = 51;
            this.dataGridViewReparatii.RowTemplate.Height = 24;
            this.dataGridViewReparatii.Size = new System.Drawing.Size(976, 366);
            this.dataGridViewReparatii.TabIndex = 0;
            this.dataGridViewReparatii.Click += new System.EventHandler(this.dataGridViewReparatii_Click);
            // 
            // labelPretAchitat
            // 
            this.labelPretAchitat.AutoSize = true;
            this.labelPretAchitat.Location = new System.Drawing.Point(397, 551);
            this.labelPretAchitat.Name = "labelPretAchitat";
            this.labelPretAchitat.Size = new System.Drawing.Size(80, 17);
            this.labelPretAchitat.TabIndex = 1;
            this.labelPretAchitat.Text = "Pret achitat";
            // 
            // checkBoxVerdictReparatie
            // 
            this.checkBoxVerdictReparatie.AutoSize = true;
            this.checkBoxVerdictReparatie.Location = new System.Drawing.Point(741, 483);
            this.checkBoxVerdictReparatie.Name = "checkBoxVerdictReparatie";
            this.checkBoxVerdictReparatie.Size = new System.Drawing.Size(147, 21);
            this.checkBoxVerdictReparatie.TabIndex = 2;
            this.checkBoxVerdictReparatie.Text = "Reparat/nereparat";
            this.checkBoxVerdictReparatie.UseVisualStyleBackColor = true;
            // 
            // txtPretAchitat
            // 
            this.txtPretAchitat.Location = new System.Drawing.Point(493, 548);
            this.txtPretAchitat.Name = "txtPretAchitat";
            this.txtPretAchitat.Size = new System.Drawing.Size(242, 22);
            this.txtPretAchitat.TabIndex = 3;
            // 
            // txtPieseInlocuite
            // 
            this.txtPieseInlocuite.Location = new System.Drawing.Point(493, 455);
            this.txtPieseInlocuite.Multiline = true;
            this.txtPieseInlocuite.Name = "txtPieseInlocuite";
            this.txtPieseInlocuite.Size = new System.Drawing.Size(242, 49);
            this.txtPieseInlocuite.TabIndex = 5;
            // 
            // labelPieseInlocuite
            // 
            this.labelPieseInlocuite.AutoSize = true;
            this.labelPieseInlocuite.Location = new System.Drawing.Point(378, 455);
            this.labelPieseInlocuite.Name = "labelPieseInlocuite";
            this.labelPieseInlocuite.Size = new System.Drawing.Size(99, 17);
            this.labelPieseInlocuite.TabIndex = 4;
            this.labelPieseInlocuite.Text = "Piese inlocuite";
            // 
            // txtTermenGarantie
            // 
            this.txtTermenGarantie.Location = new System.Drawing.Point(493, 510);
            this.txtTermenGarantie.Name = "txtTermenGarantie";
            this.txtTermenGarantie.Size = new System.Drawing.Size(242, 22);
            this.txtTermenGarantie.TabIndex = 7;
            // 
            // labelTermenGarantie
            // 
            this.labelTermenGarantie.AutoSize = true;
            this.labelTermenGarantie.Location = new System.Drawing.Point(364, 510);
            this.labelTermenGarantie.Name = "labelTermenGarantie";
            this.labelTermenGarantie.Size = new System.Drawing.Size(113, 17);
            this.labelTermenGarantie.TabIndex = 6;
            this.labelTermenGarantie.Text = "Termen garantie";
            // 
            // dateTimeDataPredarii
            // 
            this.dateTimeDataPredarii.Location = new System.Drawing.Point(493, 408);
            this.dateTimeDataPredarii.Name = "dateTimeDataPredarii";
            this.dateTimeDataPredarii.Size = new System.Drawing.Size(242, 22);
            this.dateTimeDataPredarii.TabIndex = 8;
            // 
            // labelDataPredarii
            // 
            this.labelDataPredarii.AutoSize = true;
            this.labelDataPredarii.Location = new System.Drawing.Point(387, 408);
            this.labelDataPredarii.Name = "labelDataPredarii";
            this.labelDataPredarii.Size = new System.Drawing.Size(90, 17);
            this.labelDataPredarii.TabIndex = 9;
            this.labelDataPredarii.Text = "Data predarii";
            // 
            // btnAfiseaza
            // 
            this.btnAfiseaza.Location = new System.Drawing.Point(12, 7);
            this.btnAfiseaza.Name = "btnAfiseaza";
            this.btnAfiseaza.Size = new System.Drawing.Size(130, 23);
            this.btnAfiseaza.TabIndex = 10;
            this.btnAfiseaza.Text = "Afiseaza";
            this.btnAfiseaza.UseVisualStyleBackColor = true;
            this.btnAfiseaza.Click += new System.EventHandler(this.btnAfiseaza_Click);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(258, 483);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(75, 23);
            this.btnSalveaza.TabIndex = 11;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // status_WIP_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 590);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.btnAfiseaza);
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
            this.Name = "status_WIP_form";
            this.Text = "Telefoane - in lucru";
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
        private System.Windows.Forms.Button btnAfiseaza;
        private System.Windows.Forms.Button btnSalveaza;
    }
}