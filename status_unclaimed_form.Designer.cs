namespace AplicatieDisertatie
{
    partial class status_unclaimed_form
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.labelDataPredarii = new System.Windows.Forms.Label();
            this.dateTimeDataPredarii = new System.Windows.Forms.DateTimePicker();
            this.txtObservatii = new System.Windows.Forms.TextBox();
            this.labelTelNeridicate6luni = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1060, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(0, 425);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1060, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(438, 350);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(110, 30);
            this.btnSalveaza.TabIndex = 10;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            // 
            // labelDataPredarii
            // 
            this.labelDataPredarii.AutoSize = true;
            this.labelDataPredarii.Location = new System.Drawing.Point(332, 205);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(346, 250);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 17);
            label1.TabIndex = 79;
            label1.Text = "Observatii:";
            // 
            // txtObservatii
            // 
            this.txtObservatii.Location = new System.Drawing.Point(438, 247);
            this.txtObservatii.Margin = new System.Windows.Forms.Padding(5);
            this.txtObservatii.Multiline = true;
            this.txtObservatii.Name = "txtObservatii";
            this.txtObservatii.ReadOnly = true;
            this.txtObservatii.Size = new System.Drawing.Size(242, 49);
            this.txtObservatii.TabIndex = 78;
            // 
            // labelTelNeridicate6luni
            // 
            this.labelTelNeridicate6luni.AutoSize = true;
            this.labelTelNeridicate6luni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.labelTelNeridicate6luni.Location = new System.Drawing.Point(311, 396);
            this.labelTelNeridicate6luni.Name = "labelTelNeridicate6luni";
            this.labelTelNeridicate6luni.Size = new System.Drawing.Size(526, 26);
            this.labelTelNeridicate6luni.TabIndex = 80;
            this.labelTelNeridicate6luni.Text = "Telefoane neridicate de peste 6 luni de la data primirii";
            // 
            // status_unclaimed_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 575);
            this.Controls.Add(this.labelTelNeridicate6luni);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtObservatii);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.labelDataPredarii);
            this.Controls.Add(this.dateTimeDataPredarii);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "status_unclaimed_form";
            this.Text = "status_unclaimed_form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Label labelDataPredarii;
        private System.Windows.Forms.DateTimePicker dateTimeDataPredarii;
        private System.Windows.Forms.TextBox txtObservatii;
        private System.Windows.Forms.Label labelTelNeridicate6luni;
    }
}