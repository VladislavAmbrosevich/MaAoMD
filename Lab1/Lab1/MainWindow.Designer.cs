namespace Lab1
{
    partial class MainWIndow
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
            this.DrawAreaPictureBox = new System.Windows.Forms.PictureBox();
            this.PointsCountTextBox = new System.Windows.Forms.TextBox();
            this.PointsCountLabel = new System.Windows.Forms.Label();
            this.ClassesCountLabel = new System.Windows.Forms.Label();
            this.ClassesCountComboBox = new System.Windows.Forms.ComboBox();
            this.AverageKButton = new System.Windows.Forms.Button();
            this.MaximinButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawAreaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawAreaPictureBox
            // 
            this.DrawAreaPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.DrawAreaPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.DrawAreaPictureBox.Location = new System.Drawing.Point(0, 0);
            this.DrawAreaPictureBox.MaximumSize = new System.Drawing.Size(640, 480);
            this.DrawAreaPictureBox.MinimumSize = new System.Drawing.Size(640, 480);
            this.DrawAreaPictureBox.Name = "DrawAreaPictureBox";
            this.DrawAreaPictureBox.Size = new System.Drawing.Size(640, 480);
            this.DrawAreaPictureBox.TabIndex = 0;
            this.DrawAreaPictureBox.TabStop = false;
            // 
            // PointsCountTextBox
            // 
            this.PointsCountTextBox.Location = new System.Drawing.Point(666, 46);
            this.PointsCountTextBox.Name = "PointsCountTextBox";
            this.PointsCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.PointsCountTextBox.TabIndex = 1;
            this.PointsCountTextBox.Text = "10000";
            // 
            // PointsCountLabel
            // 
            this.PointsCountLabel.AutoSize = true;
            this.PointsCountLabel.Location = new System.Drawing.Point(663, 30);
            this.PointsCountLabel.Name = "PointsCountLabel";
            this.PointsCountLabel.Size = new System.Drawing.Size(69, 13);
            this.PointsCountLabel.TabIndex = 2;
            this.PointsCountLabel.Text = "Points count:";
            // 
            // ClassesCountLabel
            // 
            this.ClassesCountLabel.AutoSize = true;
            this.ClassesCountLabel.Location = new System.Drawing.Point(663, 86);
            this.ClassesCountLabel.Name = "ClassesCountLabel";
            this.ClassesCountLabel.Size = new System.Drawing.Size(76, 13);
            this.ClassesCountLabel.TabIndex = 3;
            this.ClassesCountLabel.Text = "Classes count:";
            // 
            // ClassesCountComboBox
            // 
            this.ClassesCountComboBox.FormattingEnabled = true;
            this.ClassesCountComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.ClassesCountComboBox.Location = new System.Drawing.Point(666, 102);
            this.ClassesCountComboBox.Name = "ClassesCountComboBox";
            this.ClassesCountComboBox.Size = new System.Drawing.Size(100, 21);
            this.ClassesCountComboBox.TabIndex = 4;
            this.ClassesCountComboBox.Text = "2";
            // 
            // AverageKButton
            // 
            this.AverageKButton.Location = new System.Drawing.Point(666, 171);
            this.AverageKButton.Name = "AverageKButton";
            this.AverageKButton.Size = new System.Drawing.Size(99, 24);
            this.AverageKButton.TabIndex = 5;
            this.AverageKButton.Text = "K-Average";
            this.AverageKButton.UseVisualStyleBackColor = true;
            this.AverageKButton.Click += new System.EventHandler(this.AverageKButton_Click);
            // 
            // MaximinButton
            // 
            this.MaximinButton.Location = new System.Drawing.Point(666, 223);
            this.MaximinButton.Name = "MaximinButton";
            this.MaximinButton.Size = new System.Drawing.Size(99, 24);
            this.MaximinButton.TabIndex = 6;
            this.MaximinButton.Text = "Maximin";
            this.MaximinButton.UseVisualStyleBackColor = true;
            this.MaximinButton.Click += new System.EventHandler(this.MaximinButton_Click);
            // 
            // MainWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(785, 481);
            this.Controls.Add(this.MaximinButton);
            this.Controls.Add(this.AverageKButton);
            this.Controls.Add(this.ClassesCountComboBox);
            this.Controls.Add(this.ClassesCountLabel);
            this.Controls.Add(this.PointsCountLabel);
            this.Controls.Add(this.PointsCountTextBox);
            this.Controls.Add(this.DrawAreaPictureBox);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(801, 520);
            this.MinimumSize = new System.Drawing.Size(801, 520);
            this.Name = "MainWIndow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab_1";
            ((System.ComponentModel.ISupportInitialize)(this.DrawAreaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawAreaPictureBox;
        private System.Windows.Forms.TextBox PointsCountTextBox;
        private System.Windows.Forms.Label PointsCountLabel;
        private System.Windows.Forms.Label ClassesCountLabel;
        private System.Windows.Forms.ComboBox ClassesCountComboBox;
        private System.Windows.Forms.Button AverageKButton;
        private System.Windows.Forms.Button MaximinButton;
    }
}