namespace UTC_Clock
{
    partial class AnalogClock
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
            this.clockControl1 = new ClockControl.ClockControl();
            this.SuspendLayout();
            // 
            // clockControl1
            // 
            this.clockControl1.Location = new System.Drawing.Point(42, 3);
            this.clockControl1.Name = "clockControl1";
            this.clockControl1.ShowHourHand = true;
            this.clockControl1.ShowMajorSegments = true;
            this.clockControl1.ShowMinorSegments = true;
            this.clockControl1.ShowMinuteHand = true;
            this.clockControl1.ShowSecondhand = true;
            this.clockControl1.Size = new System.Drawing.Size(302, 302);
            this.clockControl1.TabIndex = 0;
            this.clockControl1.Text = "clockControl1";
            // 
            // AnalogClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 317);
            this.Controls.Add(this.clockControl1);
            this.Name = "AnalogClock";
            this.Text = "AnalogClock";
            this.ResumeLayout(false);

        }

        #endregion

        public ClockControl.ClockControl clockControl1;

    }
}