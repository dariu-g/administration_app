namespace AplicatieDisertatie
{
    partial class statusUnclaimed_form
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
            System.Windows.Forms.Label label1;
            this.dataGridCurrent = new System.Windows.Forms.DataGridView();
            this.dataGridGreaterThan6m = new System.Windows.Forms.DataGridView();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.labelDataPredarii = new System.Windows.Forms.Label();
            this.dateTimeDataPredarii = new System.Windows.Forms.DateTimePicker();
            this.txtObservatii = new System.Windows.Forms.TextBox();
            this.labelTelNeridicate6luni = new System.Windows.Forms.Label();
            this.btnCaseaza = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGreaterThan6m)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(332, 248);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 17);
            label1.TabIndex = 79;
            label1.Text = "Observatii:";
            // 
            // dataGridCurrent
            // 
            this.dataGridCurrent.AllowUserToAddRows = false;
            this.dataGridCurrent.AllowUserToDeleteRows = false;
            this.dataGridCurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridCurrent.Location = new System.Drawing.Point(0, 0);
            this.dataGridCurrent.Name = "dataGridCurrent";
            this.dataGridCurrent.ReadOnly = true;
            this.dataGridCurrent.RowHeadersWidth = 51;
            this.dataGridCurrent.RowTemplate.Height = 24;
            this.dataGridCurrent.Size = new System.Drawing.Size(1060, 150);
            this.dataGridCurrent.TabIndex = 0;
            this.dataGridCurrent.Click += new System.EventHandler(this.dataGridCurrent_Click);
            // 
            // dataGridGreaterThan6m
            // 
            this.dataGridGreaterThan6m.AllowUserToAddRows = false;
            this.dataGridGreaterThan6m.AllowUserToDeleteRows = false;
            this.dataGridGreaterThan6m.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGreaterThan6m.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridGreaterThan6m.Location = new System.Drawing.Point(0, 458);
            this.dataGridGreaterThan6m.Name = "dataGridGreaterThan6m";
            this.dataGridGreaterThan6m.ReadOnly = true;
            this.dataGridGreaterThan6m.RowHeadersWidth = 51;
            this.dataGridGreaterThan6m.RowTemplate.Height = 24;
            this.dataGridGreaterThan6m.Size = new System.Drawing.Size(1060, 117);
            this.dataGridGreaterThan6m.TabIndex = 1;
            this.dataGridGreaterThan6m.Click += new System.EventHandler(this.dataGridGreaterThan6m_Click);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(484, 156);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(110, 30);
            this.btnSalveaza.TabIndex = 10;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // labelDataPredarii
            // 
            this.labelDataPredarii.AutoSize = true;
            this.labelDataPredarii.Location = new System.Drawing.Point(332, 210);
            this.labelDataPredarii.Name = "labelDataPredarii";
            this.labelDataPredarii.Size = new System.Drawing.Size(90, 17);
            this.labelDataPredarii.TabIndex = 12;
            this.labelDataPredarii.Text = "Data predarii";
            // 
            // dateTimeDataPredarii
            // 
            this.dateTimeDataPredarii.CustomFormat = "dd/MM/yyyy";
            this.dateTimeDataPredarii.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDataPredarii.Location = new System.Drawing.Point(438, 205);
            this.dateTimeDataPredarii.Name = "dateTimeDataPredarii";
            this.dateTimeDataPredarii.Size = new System.Drawing.Size(242, 22);
            this.dateTimeDataPredarii.TabIndex = 11;
            // 
            // txtObservatii
            // 
            this.txtObservatii.Location = new System.Drawing.Point(438, 235);
            this.txtObservatii.Margin = new System.Windows.Forms.Padding(5);
            this.txtObservatii.MaxLength = 250;
            this.txtObservatii.Multiline = true;
            this.txtObservatii.Name = "txtObservatii";
            this.txtObservatii.Size = new System.Drawing.Size(242, 49);
            this.txtObservatii.TabIndex = 78;
            // 
            // labelTelNeridicate6luni
            // 
            this.labelTelNeridicate6luni.AutoSize = true;
            this.labelTelNeridicate6luni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.labelTelNeridicate6luni.Location = new System.Drawing.Point(320, 417);
            this.labelTelNeridicate6luni.Name = "labelTelNeridicate6luni";
            this.labelTelNeridicate6luni.Size = new System.Drawing.Size(526, 26);
            this.labelTelNeridicate6luni.TabIndex = 80;
            this.labelTelNeridicate6luni.Text = "Telefoane neridicate de peste 6 luni de la data primirii";
            // 
            // btnCaseaza
            // 
            this.btnCaseaza.Location = new System.Drawing.Point(484, 302);
            this.btnCaseaza.Name = "btnCaseaza";
            this.btnCaseaza.Size = new System.Drawing.Size(110, 30);
            this.btnCaseaza.TabIndex = 81;
            this.btnCaseaza.Text = "Caseaza";
            this.btnCaseaza.UseVisualStyleBackColor = true;
            this.btnCaseaza.Click += new System.EventHandler(this.btnCaseaza_Click);
            // 
            // statusUnclaimed_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 575);
            this.Controls.Add(this.btnCaseaza);
            this.Controls.Add(this.labelTelNeridicate6luni);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtObservatii);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.labelDataPredarii);
            this.Controls.Add(this.dateTimeDataPredarii);
            this.Controls.Add(this.dataGridGreaterThan6m);
            this.Controls.Add(this.dataGridCurrent);
            this.Name = "statusUnclaimed_form";
            this.Text = "Status - neridicate";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGreaterThan6m)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCurrent;
        private System.Windows.Forms.DataGridView dataGridGreaterThan6m;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Label labelDataPredarii;
        private System.Windows.Forms.DateTimePicker dateTimeDataPredarii;
        private System.Windows.Forms.TextBox txtObservatii;
        private System.Windows.Forms.Label labelTelNeridicate6luni;
        private System.Windows.Forms.Button btnCaseaza;
    }
}