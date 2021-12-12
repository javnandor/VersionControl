
namespace Beadandó_8
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chartRate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimeTol = new System.Windows.Forms.DateTimePicker();
            this.dateTimeIg = new System.Windows.Forms.DateTimePicker();
            this.cmbValuta = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(425, 380);
            this.dataGridView1.TabIndex = 0;
            // 
            // chartRate
            // 
            chartArea5.Name = "ChartArea1";
            this.chartRate.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartRate.Legends.Add(legend5);
            this.chartRate.Location = new System.Drawing.Point(458, 79);
            this.chartRate.Name = "chartRate";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartRate.Series.Add(series5);
            this.chartRate.Size = new System.Drawing.Size(504, 380);
            this.chartRate.TabIndex = 1;
            this.chartRate.Text = "chart1";
            // 
            // dateTimeTol
            // 
            this.dateTimeTol.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTol.Location = new System.Drawing.Point(27, 23);
            this.dateTimeTol.Name = "dateTimeTol";
            this.dateTimeTol.Size = new System.Drawing.Size(153, 26);
            this.dateTimeTol.TabIndex = 2;
            this.dateTimeTol.ValueChanged += new System.EventHandler(this.paramChanged);
            // 
            // dateTimeIg
            // 
            this.dateTimeIg.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeIg.Location = new System.Drawing.Point(208, 23);
            this.dateTimeIg.Name = "dateTimeIg";
            this.dateTimeIg.Size = new System.Drawing.Size(158, 26);
            this.dateTimeIg.TabIndex = 3;
            this.dateTimeIg.ValueChanged += new System.EventHandler(this.paramChanged);
            // 
            // cmbValuta
            // 
            this.cmbValuta.FormattingEnabled = true;
            this.cmbValuta.Items.AddRange(new object[] {
            "EUR",
            "USD",
            "GBP"});
            this.cmbValuta.Location = new System.Drawing.Point(393, 21);
            this.cmbValuta.Name = "cmbValuta";
            this.cmbValuta.Size = new System.Drawing.Size(121, 28);
            this.cmbValuta.TabIndex = 4;
            this.cmbValuta.SelectedIndexChanged += new System.EventHandler(this.paramChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 450);
            this.Controls.Add(this.cmbValuta);
            this.Controls.Add(this.dateTimeIg);
            this.Controls.Add(this.dateTimeTol);
            this.Controls.Add(this.chartRate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRate;
        private System.Windows.Forms.DateTimePicker dateTimeTol;
        private System.Windows.Forms.DateTimePicker dateTimeIg;
        private System.Windows.Forms.ComboBox cmbValuta;
    }
}

