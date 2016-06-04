namespace testBench
{
    partial class Bench
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
            this.ButtonLancer = new System.Windows.Forms.Button();
            this.LabelTime = new System.Windows.Forms.Label();
            this.TimeMin = new System.Windows.Forms.Label();
            this.TimeMax = new System.Windows.Forms.Label();
            this.labelBoolTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonLancer
            // 
            this.ButtonLancer.Location = new System.Drawing.Point(36, 25);
            this.ButtonLancer.Name = "ButtonLancer";
            this.ButtonLancer.Size = new System.Drawing.Size(168, 122);
            this.ButtonLancer.TabIndex = 0;
            this.ButtonLancer.Text = "Test";
            this.ButtonLancer.UseVisualStyleBackColor = true;
            this.ButtonLancer.Click += new System.EventHandler(this.ButtonLancer_Click);
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Location = new System.Drawing.Point(46, 197);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(43, 20);
            this.LabelTime.TabIndex = 1;
            this.LabelTime.Text = "Time";
            // 
            // TimeMin
            // 
            this.TimeMin.AutoSize = true;
            this.TimeMin.Location = new System.Drawing.Point(46, 177);
            this.TimeMin.Name = "TimeMin";
            this.TimeMin.Size = new System.Drawing.Size(80, 20);
            this.TimeMin.TabIndex = 2;
            this.TimeMin.Text = "TimeMin : ";
            // 
            // TimeMax
            // 
            this.TimeMax.AutoSize = true;
            this.TimeMax.Location = new System.Drawing.Point(46, 217);
            this.TimeMax.Name = "TimeMax";
            this.TimeMax.Size = new System.Drawing.Size(84, 20);
            this.TimeMax.TabIndex = 3;
            this.TimeMax.Text = "TimeMax : ";
            // 
            // labelBoolTest
            // 
            this.labelBoolTest.AutoSize = true;
            this.labelBoolTest.Location = new System.Drawing.Point(46, 157);
            this.labelBoolTest.Name = "labelBoolTest";
            this.labelBoolTest.Size = new System.Drawing.Size(84, 20);
            this.labelBoolTest.TabIndex = 4;
            this.labelBoolTest.Text = "BoolTest : ";
            // 
            // Bench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 280);
            this.Controls.Add(this.labelBoolTest);
            this.Controls.Add(this.TimeMax);
            this.Controls.Add(this.TimeMin);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.ButtonLancer);
            this.Name = "Bench";
            this.Text = "Bench";
            this.Load += new System.EventHandler(this.Bench_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonLancer;
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label TimeMin;
        private System.Windows.Forms.Label TimeMax;
        private System.Windows.Forms.Label labelBoolTest;
    }
}

