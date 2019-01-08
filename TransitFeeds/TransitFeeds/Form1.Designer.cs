namespace TransitFeeds
{
    partial class Form1
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
            this.UpdateButton = new System.Windows.Forms.Button();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.TimerCheck = new System.Windows.Forms.CheckBox();
            this.ZoomBar = new System.Windows.Forms.TrackBar();
            this.ZoomLabel = new System.Windows.Forms.Label();
            this.MetaCheck = new System.Windows.Forms.CheckBox();
            this.DivvyCheck = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CTATrainsCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(12, 11);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(77, 23);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.Text = "Update Map";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // MainMap
            // 
            this.MainMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMap.Bearing = 0F;
            this.MainMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainMap.CanDragMap = true;
            this.MainMap.EmptyTileColor = System.Drawing.SystemColors.Control;
            this.MainMap.GrayScaleMode = true;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(12, 43);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 100;
            this.MainMap.MinZoom = 1;
            this.MainMap.MouseWheelZoomEnabled = true;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(1387, 1354);
            this.MainMap.TabIndex = 5;
            this.MainMap.Zoom = 10D;
            this.MainMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.MainMap_OnMapZoomChanged);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 10000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // TimerCheck
            // 
            this.TimerCheck.AutoSize = true;
            this.TimerCheck.Checked = true;
            this.TimerCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TimerCheck.Location = new System.Drawing.Point(95, 15);
            this.TimerCheck.Name = "TimerCheck";
            this.TimerCheck.Size = new System.Drawing.Size(90, 17);
            this.TimerCheck.TabIndex = 6;
            this.TimerCheck.Text = "Update Timer";
            this.TimerCheck.UseVisualStyleBackColor = true;
            // 
            // ZoomBar
            // 
            this.ZoomBar.AutoSize = false;
            this.ZoomBar.Location = new System.Drawing.Point(1405, 43);
            this.ZoomBar.Maximum = 20;
            this.ZoomBar.Minimum = 1;
            this.ZoomBar.Name = "ZoomBar";
            this.ZoomBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ZoomBar.Size = new System.Drawing.Size(31, 1334);
            this.ZoomBar.TabIndex = 7;
            this.ZoomBar.TickFrequency = 100;
            this.ZoomBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.ZoomBar.Value = 10;
            this.ZoomBar.ValueChanged += new System.EventHandler(this.ZoomBar_ValueChanged);
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.Location = new System.Drawing.Point(1405, 1379);
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(31, 18);
            this.ZoomLabel.TabIndex = 8;
            this.ZoomLabel.Text = "20%";
            this.ZoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MetaCheck
            // 
            this.MetaCheck.AutoSize = true;
            this.MetaCheck.Checked = true;
            this.MetaCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MetaCheck.Location = new System.Drawing.Point(9, 4);
            this.MetaCheck.Name = "MetaCheck";
            this.MetaCheck.Size = new System.Drawing.Size(53, 17);
            this.MetaCheck.TabIndex = 6;
            this.MetaCheck.Text = "Metra";
            this.MetaCheck.UseVisualStyleBackColor = true;
            this.MetaCheck.CheckedChanged += new System.EventHandler(this.MetaCheck_CheckedChanged);
            // 
            // DivvyCheck
            // 
            this.DivvyCheck.AutoSize = true;
            this.DivvyCheck.Checked = true;
            this.DivvyCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DivvyCheck.Location = new System.Drawing.Point(74, 4);
            this.DivvyCheck.Name = "DivvyCheck";
            this.DivvyCheck.Size = new System.Drawing.Size(53, 17);
            this.DivvyCheck.TabIndex = 6;
            this.DivvyCheck.Text = "Divvy";
            this.DivvyCheck.UseVisualStyleBackColor = true;
            this.DivvyCheck.CheckedChanged += new System.EventHandler(this.DivvyCheck_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.MetaCheck);
            this.panel1.Controls.Add(this.CTATrainsCheck);
            this.panel1.Controls.Add(this.DivvyCheck);
            this.panel1.Location = new System.Drawing.Point(1203, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 25);
            this.panel1.TabIndex = 9;
            // 
            // CTATrainsCheck
            // 
            this.CTATrainsCheck.AutoSize = true;
            this.CTATrainsCheck.Checked = true;
            this.CTATrainsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CTATrainsCheck.Location = new System.Drawing.Point(139, 4);
            this.CTATrainsCheck.Name = "CTATrainsCheck";
            this.CTATrainsCheck.Size = new System.Drawing.Size(79, 17);
            this.CTATrainsCheck.TabIndex = 6;
            this.CTATrainsCheck.Text = "CTA Trains";
            this.CTATrainsCheck.UseVisualStyleBackColor = true;
            this.CTATrainsCheck.CheckedChanged += new System.EventHandler(this.CTATrainsCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 1410);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ZoomLabel);
            this.Controls.Add(this.ZoomBar);
            this.Controls.Add(this.TimerCheck);
            this.Controls.Add(this.MainMap);
            this.Controls.Add(this.UpdateButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ZoomBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button UpdateButton;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.CheckBox TimerCheck;
        private System.Windows.Forms.TrackBar ZoomBar;
        private System.Windows.Forms.Label ZoomLabel;
        private System.Windows.Forms.CheckBox MetaCheck;
        private System.Windows.Forms.CheckBox DivvyCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CTATrainsCheck;
    }
}

