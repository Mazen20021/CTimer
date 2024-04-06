namespace CTimer
{
    partial class CountdownForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountdownForm));
            label1 = new Label();
            counter = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 9);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(315, 32);
            label1.TabIndex = 0;
            label1.Text = "Save Every Thing You Have ";
            // 
            // counter
            // 
            counter.AutoSize = true;
            counter.Location = new Point(74, 91);
            counter.Margin = new Padding(6, 0, 6, 0);
            counter.Name = "counter";
            counter.Size = new Size(42, 32);
            counter.TabIndex = 1;
            counter.Text = "00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 91);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 32);
            label3.TabIndex = 2;
            label3.Text = "Seconds";
            // 
            // CountdownForm
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(478, 181);
            Controls.Add(label3);
            Controls.Add(counter);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CountdownForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Times Up!";
            Load += CountdownForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label counter;
        private Label label3;
    }
}