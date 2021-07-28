
namespace Worms
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.fieldPanel = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.startToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.speedToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.speedToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rulesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.openLogFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldPanel
            // 
            this.fieldPanel.Location = new System.Drawing.Point(12, 28);
            this.fieldPanel.Name = "fieldPanel";
            this.fieldPanel.Size = new System.Drawing.Size(800, 800);
            this.fieldPanel.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripButton,
            this.toolStripSeparator1,
            this.restartToolStripButton,
            this.toolStripSeparator2,
            this.stopToolStripButton,
            this.toolStripSeparator3,
            this.speedToolStripLabel,
            this.speedToolStripComboBox,
            this.toolStripSeparator4,
            this.rulesToolStripButton,
            this.toolStripSeparator5,
            this.openLogFileToolStripButton,
            this.toolStripSeparator6,
            this.aboutToolStripButton,
            this.toolStripSeparator7,
            this.exitToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(824, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "Menu";
            // 
            // startToolStripButton
            // 
            this.startToolStripButton.Image = global::Worms.Properties.Resources.StartWithoutDebug_16x;
            this.startToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startToolStripButton.Name = "startToolStripButton";
            this.startToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.startToolStripButton.Text = "Start";
            this.startToolStripButton.Click += new System.EventHandler(this.startToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // restartToolStripButton
            // 
            this.restartToolStripButton.Image = global::Worms.Properties.Resources.Restart_16x;
            this.restartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.restartToolStripButton.Name = "restartToolStripButton";
            this.restartToolStripButton.Size = new System.Drawing.Size(63, 22);
            this.restartToolStripButton.Text = "Restart";
            this.restartToolStripButton.Click += new System.EventHandler(this.restartToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // stopToolStripButton
            // 
            this.stopToolStripButton.Image = global::Worms.Properties.Resources.Stop_16x;
            this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripButton.Name = "stopToolStripButton";
            this.stopToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.stopToolStripButton.Text = "Stop";
            this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // speedToolStripLabel
            // 
            this.speedToolStripLabel.Name = "speedToolStripLabel";
            this.speedToolStripLabel.Size = new System.Drawing.Size(42, 22);
            this.speedToolStripLabel.Text = "Speed:";
            // 
            // speedToolStripComboBox
            // 
            this.speedToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.speedToolStripComboBox.Items.AddRange(new object[] {
            "Very Slow",
            "Slow",
            "Normal",
            "Fast",
            "Very Fast"});
            this.speedToolStripComboBox.Name = "speedToolStripComboBox";
            this.speedToolStripComboBox.Size = new System.Drawing.Size(80, 25);
            this.speedToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.speedToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // rulesToolStripButton
            // 
            this.rulesToolStripButton.Image = global::Worms.Properties.Resources.ReadingMode_16x;
            this.rulesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rulesToolStripButton.Name = "rulesToolStripButton";
            this.rulesToolStripButton.Size = new System.Drawing.Size(55, 22);
            this.rulesToolStripButton.Text = "Rules";
            this.rulesToolStripButton.Click += new System.EventHandler(this.rulesToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // openLogFileToolStripButton
            // 
            this.openLogFileToolStripButton.Image = global::Worms.Properties.Resources.Log_16x;
            this.openLogFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openLogFileToolStripButton.Name = "openLogFileToolStripButton";
            this.openLogFileToolStripButton.Size = new System.Drawing.Size(79, 22);
            this.openLogFileToolStripButton.Text = "Open Log";
            this.openLogFileToolStripButton.Click += new System.EventHandler(this.openLogFileToolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.Image = global::Worms.Properties.Resources.InformationSymbol_16x;
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.aboutToolStripButton.Text = "About";
            this.aboutToolStripButton.Click += new System.EventHandler(this.aboutToolStripButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.Image = global::Worms.Properties.Resources.Close_16x;
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(46, 22);
            this.exitToolStripButton.Text = "Exit";
            this.exitToolStripButton.Click += new System.EventHandler(this.exitToolStripButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 841);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.fieldPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Worms and Apples";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel fieldPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton startToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton restartToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton openLogFileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.ToolStripButton aboutToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel speedToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox speedToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton rulesToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

