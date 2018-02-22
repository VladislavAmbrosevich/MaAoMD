namespace Lab3
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GraphicsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InputProbabilityTextBox = new System.Windows.Forms.TextBox();
            this.InputProbabilityLabel = new System.Windows.Forms.Label();
            this.FalseAlarmZoneCaptionLabel = new System.Windows.Forms.Label();
            this.MissingErrorDetectionZoneCaptionLabel = new System.Windows.Forms.Label();
            this.TotalClassificationErrorCaptionLabel = new System.Windows.Forms.Label();
            this.FalseAlarmZoneValueLabel = new System.Windows.Forms.Label();
            this.MissingErrorDetectionZoneValueLabel = new System.Windows.Forms.Label();
            this.TotalClassificationErrorValueLabel = new System.Windows.Forms.Label();
            this.BuildChartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphicsChart
            // 
            chartArea3.Name = "ChartArea1";
            this.GraphicsChart.ChartAreas.Add(chartArea3);
            this.GraphicsChart.Dock = System.Windows.Forms.DockStyle.Right;
            legend3.Name = "Legend1";
            this.GraphicsChart.Legends.Add(legend3);
            this.GraphicsChart.Location = new System.Drawing.Point(302, 0);
            this.GraphicsChart.Name = "GraphicsChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.GraphicsChart.Series.Add(series3);
            this.GraphicsChart.Size = new System.Drawing.Size(781, 495);
            this.GraphicsChart.TabIndex = 0;
            this.GraphicsChart.Text = "chart1";
            // 
            // InputProbabilityTextBox
            // 
            this.InputProbabilityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputProbabilityTextBox.Location = new System.Drawing.Point(32, 72);
            this.InputProbabilityTextBox.Name = "InputProbabilityTextBox";
            this.InputProbabilityTextBox.Size = new System.Drawing.Size(93, 29);
            this.InputProbabilityTextBox.TabIndex = 1;
            // 
            // InputProbabilityLabel
            // 
            this.InputProbabilityLabel.AutoSize = true;
            this.InputProbabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputProbabilityLabel.Location = new System.Drawing.Point(28, 45);
            this.InputProbabilityLabel.Name = "InputProbabilityLabel";
            this.InputProbabilityLabel.Size = new System.Drawing.Size(174, 24);
            this.InputProbabilityLabel.TabIndex = 2;
            this.InputProbabilityLabel.Text = "Input 1st probability:";
            // 
            // FalseAlarmZoneCaptionLabel
            // 
            this.FalseAlarmZoneCaptionLabel.AutoSize = true;
            this.FalseAlarmZoneCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FalseAlarmZoneCaptionLabel.Location = new System.Drawing.Point(28, 250);
            this.FalseAlarmZoneCaptionLabel.Name = "FalseAlarmZoneCaptionLabel";
            this.FalseAlarmZoneCaptionLabel.Size = new System.Drawing.Size(159, 24);
            this.FalseAlarmZoneCaptionLabel.TabIndex = 3;
            this.FalseAlarmZoneCaptionLabel.Text = "False alarm zone:";
            // 
            // MissingErrorDetectionZoneCaptionLabel
            // 
            this.MissingErrorDetectionZoneCaptionLabel.AutoSize = true;
            this.MissingErrorDetectionZoneCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MissingErrorDetectionZoneCaptionLabel.Location = new System.Drawing.Point(28, 313);
            this.MissingErrorDetectionZoneCaptionLabel.Name = "MissingErrorDetectionZoneCaptionLabel";
            this.MissingErrorDetectionZoneCaptionLabel.Size = new System.Drawing.Size(252, 20);
            this.MissingErrorDetectionZoneCaptionLabel.TabIndex = 4;
            this.MissingErrorDetectionZoneCaptionLabel.Text = "Missing errro detection zone prob.:";
            // 
            // TotalClassificationErrorCaptionLabel
            // 
            this.TotalClassificationErrorCaptionLabel.AutoSize = true;
            this.TotalClassificationErrorCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalClassificationErrorCaptionLabel.Location = new System.Drawing.Point(28, 391);
            this.TotalClassificationErrorCaptionLabel.Name = "TotalClassificationErrorCaptionLabel";
            this.TotalClassificationErrorCaptionLabel.Size = new System.Drawing.Size(252, 22);
            this.TotalClassificationErrorCaptionLabel.TabIndex = 5;
            this.TotalClassificationErrorCaptionLabel.Text = "Total classification error prob.:";
            // 
            // FalseAlarmZoneValueLabel
            // 
            this.FalseAlarmZoneValueLabel.BackColor = System.Drawing.SystemColors.Window;
            this.FalseAlarmZoneValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FalseAlarmZoneValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FalseAlarmZoneValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FalseAlarmZoneValueLabel.Location = new System.Drawing.Point(32, 278);
            this.FalseAlarmZoneValueLabel.Name = "FalseAlarmZoneValueLabel";
            this.FalseAlarmZoneValueLabel.Size = new System.Drawing.Size(136, 23);
            this.FalseAlarmZoneValueLabel.TabIndex = 6;
            // 
            // MissingErrorDetectionZoneValueLabel
            // 
            this.MissingErrorDetectionZoneValueLabel.BackColor = System.Drawing.SystemColors.Window;
            this.MissingErrorDetectionZoneValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MissingErrorDetectionZoneValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MissingErrorDetectionZoneValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MissingErrorDetectionZoneValueLabel.Location = new System.Drawing.Point(32, 349);
            this.MissingErrorDetectionZoneValueLabel.Name = "MissingErrorDetectionZoneValueLabel";
            this.MissingErrorDetectionZoneValueLabel.Size = new System.Drawing.Size(136, 23);
            this.MissingErrorDetectionZoneValueLabel.TabIndex = 7;
            // 
            // TotalClassificationErrorValueLabel
            // 
            this.TotalClassificationErrorValueLabel.BackColor = System.Drawing.SystemColors.Window;
            this.TotalClassificationErrorValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalClassificationErrorValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalClassificationErrorValueLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TotalClassificationErrorValueLabel.Location = new System.Drawing.Point(32, 425);
            this.TotalClassificationErrorValueLabel.Name = "TotalClassificationErrorValueLabel";
            this.TotalClassificationErrorValueLabel.Size = new System.Drawing.Size(136, 23);
            this.TotalClassificationErrorValueLabel.TabIndex = 8;
            // 
            // BuildChartButton
            // 
            this.BuildChartButton.Location = new System.Drawing.Point(32, 130);
            this.BuildChartButton.Name = "BuildChartButton";
            this.BuildChartButton.Size = new System.Drawing.Size(116, 44);
            this.BuildChartButton.TabIndex = 9;
            this.BuildChartButton.Text = "Build chart";
            this.BuildChartButton.UseVisualStyleBackColor = true;
            this.BuildChartButton.Click += new System.EventHandler(this.BuildChartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 495);
            this.Controls.Add(this.BuildChartButton);
            this.Controls.Add(this.TotalClassificationErrorValueLabel);
            this.Controls.Add(this.MissingErrorDetectionZoneValueLabel);
            this.Controls.Add(this.FalseAlarmZoneValueLabel);
            this.Controls.Add(this.TotalClassificationErrorCaptionLabel);
            this.Controls.Add(this.MissingErrorDetectionZoneCaptionLabel);
            this.Controls.Add(this.FalseAlarmZoneCaptionLabel);
            this.Controls.Add(this.InputProbabilityLabel);
            this.Controls.Add(this.InputProbabilityTextBox);
            this.Controls.Add(this.GraphicsChart);
            this.Name = "MainForm";
            this.Text = "Lab3";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GraphicsChart;
        private System.Windows.Forms.TextBox InputProbabilityTextBox;
        private System.Windows.Forms.Label InputProbabilityLabel;
        private System.Windows.Forms.Label FalseAlarmZoneCaptionLabel;
        private System.Windows.Forms.Label MissingErrorDetectionZoneCaptionLabel;
        private System.Windows.Forms.Label TotalClassificationErrorCaptionLabel;
        private System.Windows.Forms.Label FalseAlarmZoneValueLabel;
        private System.Windows.Forms.Label MissingErrorDetectionZoneValueLabel;
        private System.Windows.Forms.Label TotalClassificationErrorValueLabel;
        private System.Windows.Forms.Button BuildChartButton;
    }
}

