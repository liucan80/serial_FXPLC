using System;

namespace serial_FXPLC
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.openClosePortButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusX0Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openCloseY17Button = new System.Windows.Forms.Button();
            this.openCloseY7Button = new System.Windows.Forms.Button();
            this.openCloseY16Button = new System.Windows.Forms.Button();
            this.openCloseY6Button = new System.Windows.Forms.Button();
            this.openCloseY15Button = new System.Windows.Forms.Button();
            this.openCloseY5Button = new System.Windows.Forms.Button();
            this.openCloseY14Button = new System.Windows.Forms.Button();
            this.openCloseY4Button = new System.Windows.Forms.Button();
            this.openCloseY13Button = new System.Windows.Forms.Button();
            this.openCloseY3Button = new System.Windows.Forms.Button();
            this.openCloseY12Button = new System.Windows.Forms.Button();
            this.openCloseY2Button = new System.Windows.Forms.Button();
            this.openCloseY11Button = new System.Windows.Forms.Button();
            this.openCloseY1Button = new System.Windows.Forms.Button();
            this.openCloseY10Button = new System.Windows.Forms.Button();
            this.openCloseY0Button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "可用串口:";
            // 
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(73, 26);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(121, 21);
            this.portsComboBox.TabIndex = 2;
            // 
            // openClosePortButton
            // 
            this.openClosePortButton.Location = new System.Drawing.Point(6, 257);
            this.openClosePortButton.Name = "openClosePortButton";
            this.openClosePortButton.Size = new System.Drawing.Size(75, 23);
            this.openClosePortButton.TabIndex = 3;
            this.openClosePortButton.Text = "打开";
            this.openClosePortButton.UseVisualStyleBackColor = true;
            this.openClosePortButton.Click += new System.EventHandler(this.openClosePortButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.openClosePortButton);
            this.groupBox1.Controls.Add(this.portsComboBox);
            this.groupBox1.Location = new System.Drawing.Point(22, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 297);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置通讯参数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statusX0Label);
            this.groupBox2.Location = new System.Drawing.Point(269, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 189);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输入状态";
            // 
            // statusX0Label
            // 
            this.statusX0Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusX0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusX0Label.Location = new System.Drawing.Point(17, 26);
            this.statusX0Label.Name = "statusX0Label";
            this.statusX0Label.Size = new System.Drawing.Size(64, 18);
            this.statusX0Label.TabIndex = 0;
            this.statusX0Label.Text = "X0";
            this.statusX0Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.openCloseY17Button);
            this.groupBox3.Controls.Add(this.openCloseY7Button);
            this.groupBox3.Controls.Add(this.openCloseY16Button);
            this.groupBox3.Controls.Add(this.openCloseY6Button);
            this.groupBox3.Controls.Add(this.openCloseY15Button);
            this.groupBox3.Controls.Add(this.openCloseY5Button);
            this.groupBox3.Controls.Add(this.openCloseY14Button);
            this.groupBox3.Controls.Add(this.openCloseY4Button);
            this.groupBox3.Controls.Add(this.openCloseY13Button);
            this.groupBox3.Controls.Add(this.openCloseY3Button);
            this.groupBox3.Controls.Add(this.openCloseY12Button);
            this.groupBox3.Controls.Add(this.openCloseY2Button);
            this.groupBox3.Controls.Add(this.openCloseY11Button);
            this.groupBox3.Controls.Add(this.openCloseY1Button);
            this.groupBox3.Controls.Add(this.openCloseY10Button);
            this.groupBox3.Controls.Add(this.openCloseY0Button);
            this.groupBox3.Location = new System.Drawing.Point(269, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 309);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输出状态和控制";
            // 
            // openCloseY17Button
            // 
            this.openCloseY17Button.Location = new System.Drawing.Point(251, 236);
            this.openCloseY17Button.Name = "openCloseY17Button";
            this.openCloseY17Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY17Button.TabIndex = 0;
            this.openCloseY17Button.Text = "Y17";
            this.openCloseY17Button.UseVisualStyleBackColor = true;
            this.openCloseY17Button.Click += new System.EventHandler(this.openCloseY17Button_Click);
            // 
            // openCloseY7Button
            // 
            this.openCloseY7Button.Location = new System.Drawing.Point(6, 236);
            this.openCloseY7Button.Name = "openCloseY7Button";
            this.openCloseY7Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY7Button.TabIndex = 0;
            this.openCloseY7Button.Text = "Y7";
            this.openCloseY7Button.UseVisualStyleBackColor = true;
            this.openCloseY7Button.Click += new System.EventHandler(this.openCloseY7Button_Click);
            // 
            // openCloseY16Button
            // 
            this.openCloseY16Button.Location = new System.Drawing.Point(251, 207);
            this.openCloseY16Button.Name = "openCloseY16Button";
            this.openCloseY16Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY16Button.TabIndex = 0;
            this.openCloseY16Button.Text = "Y16";
            this.openCloseY16Button.UseVisualStyleBackColor = true;
            this.openCloseY16Button.Click += new System.EventHandler(this.openCloseY16Button_Click);
            // 
            // openCloseY6Button
            // 
            this.openCloseY6Button.Location = new System.Drawing.Point(6, 207);
            this.openCloseY6Button.Name = "openCloseY6Button";
            this.openCloseY6Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY6Button.TabIndex = 0;
            this.openCloseY6Button.Text = "Y6";
            this.openCloseY6Button.UseVisualStyleBackColor = true;
            this.openCloseY6Button.Click += new System.EventHandler(this.openCloseY6Button_Click);
            // 
            // openCloseY15Button
            // 
            this.openCloseY15Button.Location = new System.Drawing.Point(251, 178);
            this.openCloseY15Button.Name = "openCloseY15Button";
            this.openCloseY15Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY15Button.TabIndex = 0;
            this.openCloseY15Button.Text = "Y15";
            this.openCloseY15Button.UseVisualStyleBackColor = true;
            this.openCloseY15Button.Click += new System.EventHandler(this.openCloseY15Button_Click);
            // 
            // openCloseY5Button
            // 
            this.openCloseY5Button.Location = new System.Drawing.Point(6, 178);
            this.openCloseY5Button.Name = "openCloseY5Button";
            this.openCloseY5Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY5Button.TabIndex = 0;
            this.openCloseY5Button.Text = "Y5";
            this.openCloseY5Button.UseVisualStyleBackColor = true;
            this.openCloseY5Button.Click += new System.EventHandler(this.openCloseY5Button_Click);
            // 
            // openCloseY14Button
            // 
            this.openCloseY14Button.Location = new System.Drawing.Point(251, 149);
            this.openCloseY14Button.Name = "openCloseY14Button";
            this.openCloseY14Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY14Button.TabIndex = 0;
            this.openCloseY14Button.Text = "Y14";
            this.openCloseY14Button.UseVisualStyleBackColor = true;
            this.openCloseY14Button.Click += new System.EventHandler(this.openCloseY14Button_Click);
            // 
            // openCloseY4Button
            // 
            this.openCloseY4Button.Location = new System.Drawing.Point(6, 149);
            this.openCloseY4Button.Name = "openCloseY4Button";
            this.openCloseY4Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY4Button.TabIndex = 0;
            this.openCloseY4Button.Text = "Y4";
            this.openCloseY4Button.UseVisualStyleBackColor = true;
            this.openCloseY4Button.Click += new System.EventHandler(this.openCloseY4Button_Click);
            // 
            // openCloseY13Button
            // 
            this.openCloseY13Button.Location = new System.Drawing.Point(251, 120);
            this.openCloseY13Button.Name = "openCloseY13Button";
            this.openCloseY13Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY13Button.TabIndex = 0;
            this.openCloseY13Button.Text = "Y13";
            this.openCloseY13Button.UseVisualStyleBackColor = true;
            this.openCloseY13Button.Click += new System.EventHandler(this.openCloseY13Button_Click);
            // 
            // openCloseY3Button
            // 
            this.openCloseY3Button.Location = new System.Drawing.Point(6, 120);
            this.openCloseY3Button.Name = "openCloseY3Button";
            this.openCloseY3Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY3Button.TabIndex = 0;
            this.openCloseY3Button.Text = "Y3";
            this.openCloseY3Button.UseVisualStyleBackColor = true;
            this.openCloseY3Button.Click += new System.EventHandler(this.openCloseY3Button_Click);
            // 
            // openCloseY12Button
            // 
            this.openCloseY12Button.Location = new System.Drawing.Point(251, 91);
            this.openCloseY12Button.Name = "openCloseY12Button";
            this.openCloseY12Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY12Button.TabIndex = 0;
            this.openCloseY12Button.Text = "Y12";
            this.openCloseY12Button.UseVisualStyleBackColor = true;
            this.openCloseY12Button.Click += new System.EventHandler(this.openCloseY12Button_Click);
            // 
            // openCloseY2Button
            // 
            this.openCloseY2Button.Location = new System.Drawing.Point(6, 91);
            this.openCloseY2Button.Name = "openCloseY2Button";
            this.openCloseY2Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY2Button.TabIndex = 0;
            this.openCloseY2Button.Text = "Y2";
            this.openCloseY2Button.UseVisualStyleBackColor = true;
            this.openCloseY2Button.Click += new System.EventHandler(this.openCloseY2Button_Click);
            // 
            // openCloseY11Button
            // 
            this.openCloseY11Button.Location = new System.Drawing.Point(251, 62);
            this.openCloseY11Button.Name = "openCloseY11Button";
            this.openCloseY11Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY11Button.TabIndex = 0;
            this.openCloseY11Button.Text = "Y11";
            this.openCloseY11Button.UseVisualStyleBackColor = true;
            this.openCloseY11Button.Click += new System.EventHandler(this.openCloseY11Button_Click);
            // 
            // openCloseY1Button
            // 
            this.openCloseY1Button.Location = new System.Drawing.Point(6, 62);
            this.openCloseY1Button.Name = "openCloseY1Button";
            this.openCloseY1Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY1Button.TabIndex = 0;
            this.openCloseY1Button.Text = "Y1";
            this.openCloseY1Button.UseVisualStyleBackColor = true;
            this.openCloseY1Button.Click += new System.EventHandler(this.openCloseY1Button_Click);
            // 
            // openCloseY10Button
            // 
            this.openCloseY10Button.Location = new System.Drawing.Point(251, 33);
            this.openCloseY10Button.Name = "openCloseY10Button";
            this.openCloseY10Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY10Button.TabIndex = 0;
            this.openCloseY10Button.Text = "Y10";
            this.openCloseY10Button.UseVisualStyleBackColor = true;
            this.openCloseY10Button.Click += new System.EventHandler(this.openCloseY10Button_Click);
            // 
            // openCloseY0Button
            // 
            this.openCloseY0Button.Location = new System.Drawing.Point(6, 33);
            this.openCloseY0Button.Name = "openCloseY0Button";
            this.openCloseY0Button.Size = new System.Drawing.Size(75, 23);
            this.openCloseY0Button.TabIndex = 0;
            this.openCloseY0Button.Text = "Y0";
            this.openCloseY0Button.UseVisualStyleBackColor = true;
            this.openCloseY0Button.Click += new System.EventHandler(this.openCloseY0Button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(779, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 569);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(779, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 547);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(779, 22);
            this.statusStrip2.TabIndex = 9;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(779, 591);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.Button openClosePortButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button openCloseY0Button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button openCloseY7Button;
        private System.Windows.Forms.Button openCloseY6Button;
        private System.Windows.Forms.Button openCloseY5Button;
        private System.Windows.Forms.Button openCloseY4Button;
        private System.Windows.Forms.Button openCloseY3Button;
        private System.Windows.Forms.Button openCloseY2Button;
        private System.Windows.Forms.Button openCloseY1Button;
        private System.Windows.Forms.Button openCloseY17Button;
        private System.Windows.Forms.Button openCloseY16Button;
        private System.Windows.Forms.Button openCloseY15Button;
        private System.Windows.Forms.Button openCloseY14Button;
        private System.Windows.Forms.Button openCloseY13Button;
        private System.Windows.Forms.Button openCloseY12Button;
        private System.Windows.Forms.Button openCloseY11Button;
        private System.Windows.Forms.Button openCloseY10Button;
        private System.Windows.Forms.Label statusX0Label;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
    }
}

