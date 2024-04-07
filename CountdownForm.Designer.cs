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
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            actionByTimerToolStripMenuItem = new ToolStripMenuItem();
            button2 = new Button();
            label3 = new Label();
            start = new Button();
            processbox = new ComboBox();
            modbox = new ComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actionByTimerToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // actionByTimerToolStripMenuItem
            // 
            resources.ApplyResources(actionByTimerToolStripMenuItem, "actionByTimerToolStripMenuItem");
            actionByTimerToolStripMenuItem.Name = "actionByTimerToolStripMenuItem";
            actionByTimerToolStripMenuItem.Click += actionByTimerToolStripMenuItem_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // start
            // 
            resources.ApplyResources(start, "start");
            start.Name = "start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // processbox
            // 
            resources.ApplyResources(processbox, "processbox");
            processbox.FormattingEnabled = true;
            processbox.Name = "processbox";
            // 
            // modbox
            // 
            resources.ApplyResources(modbox, "modbox");
            modbox.FormattingEnabled = true;
            modbox.Items.AddRange(new object[] { resources.GetString("modbox.Items"), resources.GetString("modbox.Items1"), resources.GetString("modbox.Items2"), resources.GetString("modbox.Items3") });
            modbox.Name = "modbox";
            // 
            // CountdownForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            Controls.Add(modbox);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(start);
            Controls.Add(processbox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CountdownForm";
            Load += CountdownForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem actionByTimerToolStripMenuItem;
        private Button button2;
        private Label label3;
        private Button start;
        private ComboBox processbox;
        private ComboBox modbox;
    }
}