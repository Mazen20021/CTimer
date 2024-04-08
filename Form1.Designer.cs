namespace CTimer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            modebox = new ComboBox();
            label1 = new Label();
            Hleft = new Label();
            start = new Button();
            label3 = new Label();
            menuStrip1 = new MenuStrip();
            sToolStripMenuItem = new ToolStripMenuItem();
            versionToolStripMenuItem = new ToolStripMenuItem();
            actionByProcessToolStripMenuItem = new ToolStripMenuItem();
            MLeft = new Label();
            Sleft = new Label();
            label2 = new Label();
            label4 = new Label();
            mod_text = new Label();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            Tseconds = new Label();
            HBox = new TextBox();
            mBox = new TextBox();
            SBox = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // modebox
            // 
            modebox.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modebox.FormattingEnabled = true;
            modebox.Items.AddRange(new object[] { "Shutdown", "Sleep", "Restart", "DoNothing" });
            modebox.Location = new Point(12, 88);
            modebox.Name = "modebox";
            modebox.Size = new Size(360, 40);
            modebox.TabIndex = 3;
            modebox.SelectedIndexChanged += modebox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 134);
            label1.Name = "label1";
            label1.Size = new Size(231, 37);
            label1.TabIndex = 4;
            label1.Text = "Time Left Before";
            // 
            // Hleft
            // 
            Hleft.AutoSize = true;
            Hleft.Cursor = Cursors.Hand;
            Hleft.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            Hleft.Location = new Point(30, 175);
            Hleft.Name = "Hleft";
            Hleft.Size = new Size(40, 47);
            Hleft.TabIndex = 5;
            Hleft.Text = "0";
            Hleft.Click += Hleft_Click;
            // 
            // start
            // 
            start.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            start.Location = new Point(256, 301);
            start.Name = "start";
            start.Size = new Size(117, 39);
            start.TabIndex = 6;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label3.Location = new Point(50, 29);
            label3.Name = "label3";
            label3.Size = new Size(291, 47);
            label3.TabIndex = 7;
            label3.Text = "Computer Timer";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(384, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { versionToolStripMenuItem, actionByProcessToolStripMenuItem });
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(61, 20);
            sToolStripMenuItem.Text = "Settings";
            // 
            // versionToolStripMenuItem
            // 
            versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            versionToolStripMenuItem.Size = new Size(168, 22);
            versionToolStripMenuItem.Text = "Version";
            versionToolStripMenuItem.Click += versionToolStripMenuItem_Click;
            // 
            // actionByProcessToolStripMenuItem
            // 
            actionByProcessToolStripMenuItem.Name = "actionByProcessToolStripMenuItem";
            actionByProcessToolStripMenuItem.Size = new Size(168, 22);
            actionByProcessToolStripMenuItem.Text = "Action By Process";
            actionByProcessToolStripMenuItem.Click += actionByProcessToolStripMenuItem_Click;
            // 
            // MLeft
            // 
            MLeft.AutoSize = true;
            MLeft.Cursor = Cursors.Hand;
            MLeft.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            MLeft.Location = new Point(176, 175);
            MLeft.Name = "MLeft";
            MLeft.Size = new Size(40, 47);
            MLeft.TabIndex = 9;
            MLeft.Text = "0";
            MLeft.Click += MLeft_Click;
            // 
            // Sleft
            // 
            Sleft.AutoSize = true;
            Sleft.Cursor = Cursors.Hand;
            Sleft.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            Sleft.Location = new Point(302, 175);
            Sleft.Name = "Sleft";
            Sleft.Size = new Size(40, 47);
            Sleft.TabIndex = 10;
            Sleft.Text = "0";
            Sleft.Click += Sleft_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label2.Location = new Point(100, 178);
            label2.Name = "label2";
            label2.Size = new Size(29, 47);
            label2.TabIndex = 11;
            label2.Text = ":";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label4.Location = new Point(256, 178);
            label4.Name = "label4";
            label4.Size = new Size(29, 47);
            label4.TabIndex = 12;
            label4.Text = ":";
            // 
            // mod_text
            // 
            mod_text.AutoSize = true;
            mod_text.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mod_text.ForeColor = Color.Black;
            mod_text.Location = new Point(221, 131);
            mod_text.Name = "mod_text";
            mod_text.Size = new Size(31, 37);
            mod_text.TabIndex = 13;
            mod_text.Text = "..";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(135, 301);
            button1.Name = "button1";
            button1.Size = new Size(113, 39);
            button1.TabIndex = 14;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(16, 301);
            button2.Name = "button2";
            button2.Size = new Size(113, 39);
            button2.TabIndex = 15;
            button2.Text = "Force";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(2, 249);
            label5.Name = "label5";
            label5.Size = new Size(201, 37);
            label5.TabIndex = 16;
            label5.Text = "Total Seconds:";
            // 
            // Tseconds
            // 
            Tseconds.AutoSize = true;
            Tseconds.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Tseconds.ForeColor = Color.Black;
            Tseconds.Location = new Point(221, 250);
            Tseconds.Name = "Tseconds";
            Tseconds.Size = new Size(33, 37);
            Tseconds.TabIndex = 17;
            Tseconds.Text = "0";
            // 
            // HBox
            // 
            HBox.Location = new Point(16, 225);
            HBox.MaxLength = 2;
            HBox.Name = "HBox";
            HBox.Size = new Size(73, 23);
            HBox.TabIndex = 18;
            HBox.TextChanged += HBox_TextChanged;
            // 
            // mBox
            // 
            mBox.Location = new Point(158, 225);
            mBox.MaxLength = 2;
            mBox.Name = "mBox";
            mBox.Size = new Size(75, 23);
            mBox.TabIndex = 19;
            mBox.TextChanged += mBox_TextChanged;
            // 
            // SBox
            // 
            SBox.Location = new Point(283, 225);
            SBox.MaxLength = 2;
            SBox.Name = "SBox";
            SBox.Size = new Size(75, 23);
            SBox.TabIndex = 20;
            SBox.TextChanged += SBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(384, 361);
            Controls.Add(SBox);
            Controls.Add(mBox);
            Controls.Add(HBox);
            Controls.Add(Tseconds);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(mod_text);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(Sleft);
            Controls.Add(MLeft);
            Controls.Add(label3);
            Controls.Add(start);
            Controls.Add(Hleft);
            Controls.Add(label1);
            Controls.Add(modebox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CTime";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox modebox;
        private Label label1;
        private Label Hleft;
        private Button start;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sToolStripMenuItem;
        private Label MLeft;
        private Label Sleft;
        private Label label2;
        private Label label4;
        private Label mod_text;
        private Button button1;
        private Button button2;
        private ToolStripMenuItem versionToolStripMenuItem;
        private ToolStripMenuItem actionByProcessToolStripMenuItem;
        private Label label5;
        private Label Tseconds;
        private TextBox HBox;
        private TextBox mBox;
        private TextBox SBox;
    }
}
