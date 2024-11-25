﻿namespace WindowMeter
{
    partial class WindowMeterForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowMeterForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allScreensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screen1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screen2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screen3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screen4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catchAsIcon512x512ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.centerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.oCRRecognizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.exToolStripMenuItem,
            this.toolStripMenuItem1,
            this.captureToolStripMenuItem,
            this.captureWindowToolStripMenuItem,
            this.oCRRecognizeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.centerToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.setSizeToolStripMenuItem,
            this.changeColorToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 308);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // exToolStripMenuItem
            // 
            this.exToolStripMenuItem.Name = "exToolStripMenuItem";
            this.exToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.exToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.exToolStripMenuItem.Text = "Hide";
            this.exToolStripMenuItem.Click += new System.EventHandler(this.exToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.captureToolStripMenuItem.Text = "Capture area";
            this.captureToolStripMenuItem.Click += new System.EventHandler(this.captureToolStripMenuItem_Click);
            // 
            // captureWindowToolStripMenuItem
            // 
            this.captureWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentScreenToolStripMenuItem,
            this.allScreensToolStripMenuItem,
            this.screen1ToolStripMenuItem,
            this.screen2ToolStripMenuItem,
            this.screen3ToolStripMenuItem,
            this.screen4ToolStripMenuItem});
            this.captureWindowToolStripMenuItem.Name = "captureWindowToolStripMenuItem";
            this.captureWindowToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.captureWindowToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.captureWindowToolStripMenuItem.Text = "Capture screen";
            this.captureWindowToolStripMenuItem.Click += new System.EventHandler(this.captureWindowToolStripMenuItem_Click);
            // 
            // currentScreenToolStripMenuItem
            // 
            this.currentScreenToolStripMenuItem.Name = "currentScreenToolStripMenuItem";
            this.currentScreenToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.currentScreenToolStripMenuItem.Text = "Current screen";
            this.currentScreenToolStripMenuItem.Click += new System.EventHandler(this.currentScreenToolStripMenuItem_Click);
            // 
            // allScreensToolStripMenuItem
            // 
            this.allScreensToolStripMenuItem.Name = "allScreensToolStripMenuItem";
            this.allScreensToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.allScreensToolStripMenuItem.Text = "All screens";
            this.allScreensToolStripMenuItem.Click += new System.EventHandler(this.allScreensToolStripMenuItem_Click);
            // 
            // screen1ToolStripMenuItem
            // 
            this.screen1ToolStripMenuItem.Name = "screen1ToolStripMenuItem";
            this.screen1ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.screen1ToolStripMenuItem.Text = "Screen1";
            this.screen1ToolStripMenuItem.Click += new System.EventHandler(this.screen1ToolStripMenuItem_Click);
            // 
            // screen2ToolStripMenuItem
            // 
            this.screen2ToolStripMenuItem.Name = "screen2ToolStripMenuItem";
            this.screen2ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.screen2ToolStripMenuItem.Text = "Screen2";
            this.screen2ToolStripMenuItem.Click += new System.EventHandler(this.screen2ToolStripMenuItem_Click);
            // 
            // screen3ToolStripMenuItem
            // 
            this.screen3ToolStripMenuItem.Name = "screen3ToolStripMenuItem";
            this.screen3ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.screen3ToolStripMenuItem.Text = "Screen3";
            this.screen3ToolStripMenuItem.Click += new System.EventHandler(this.screen3ToolStripMenuItem_Click);
            // 
            // screen4ToolStripMenuItem
            // 
            this.screen4ToolStripMenuItem.Name = "screen4ToolStripMenuItem";
            this.screen4ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.screen4ToolStripMenuItem.Text = "Screen4";
            this.screen4ToolStripMenuItem.Click += new System.EventHandler(this.screen4ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.centerToolStripMenuItem.Text = "Center";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.copyToolStripMenuItem.Text = "Copy size";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // setSizeToolStripMenuItem
            // 
            this.setSizeToolStripMenuItem.Name = "setSizeToolStripMenuItem";
            this.setSizeToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.setSizeToolStripMenuItem.Text = "Set size";
            this.setSizeToolStripMenuItem.Click += new System.EventHandler(this.setSizeToolStripMenuItem_Click_1);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.changeColorToolStripMenuItem.Text = "Change Color";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.changeColorToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catchAsIcon512x512ToolStripMenuItem,
            this.topMostToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            this.optionsToolStripMenuItem.MouseEnter += new System.EventHandler(this.optionsToolStripMenuItem_MouseEnter);
            // 
            // catchAsIcon512x512ToolStripMenuItem
            // 
            this.catchAsIcon512x512ToolStripMenuItem.Name = "catchAsIcon512x512ToolStripMenuItem";
            this.catchAsIcon512x512ToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.catchAsIcon512x512ToolStripMenuItem.Text = "Catch as icon 512x512";
            this.catchAsIcon512x512ToolStripMenuItem.Click += new System.EventHandler(this.catchAsIcon512x512ToolStripMenuItem_Click);
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.topMostToolStripMenuItem.Text = "Top Most";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(191, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WindowMeter";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(120, 52);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            this.contextMenuStrip2.Click += new System.EventHandler(this.contextMenuStrip2_Click);
            this.contextMenuStrip2.DoubleClick += new System.EventHandler(this.contextMenuStrip2_Click);
            // 
            // centerToolStripMenuItem1
            // 
            this.centerToolStripMenuItem1.Name = "centerToolStripMenuItem1";
            this.centerToolStripMenuItem1.Size = new System.Drawing.Size(119, 24);
            this.centerToolStripMenuItem1.Text = "Center";
            this.centerToolStripMenuItem1.Click += new System.EventHandler(this.centerToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(119, 24);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // oCRRecognizeToolStripMenuItem
            // 
            this.oCRRecognizeToolStripMenuItem.Name = "oCRRecognizeToolStripMenuItem";
            this.oCRRecognizeToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.oCRRecognizeToolStripMenuItem.Text = "OCR recognize";
            this.oCRRecognizeToolStripMenuItem.Click += new System.EventHandler(this.oCRRecognizeToolStripMenuItem_Click);
            // 
            // WindowMeterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindowMeterForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WindowMeter";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowMeterForm_FormClosing);
            this.Load += new System.EventHandler(this.WindowMeterForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WindowMeterForm_Paint);
            this.DoubleClick += new System.EventHandler(this.WindowMeterForm_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowMeterForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WindowMeterForm_KeyPress);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.WindowMeterForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowMeterForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowMeterForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowMeterForm_MouseUp);
            this.Resize += new System.EventHandler(this.WindowMeterForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exToolStripMenuItem;
        
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureWindowToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem setSizeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catchAsIcon512x512ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screen1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screen2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screen3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screen4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allScreensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oCRRecognizeToolStripMenuItem;
    }
}

