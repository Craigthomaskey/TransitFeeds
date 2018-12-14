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
            this.MainFeed = new System.Windows.Forms.Label();
            this.CopyButton = new System.Windows.Forms.Button();
            this.PositionsButton = new System.Windows.Forms.Button();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ShapesBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainFeed
            // 
            this.MainFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainFeed.Location = new System.Drawing.Point(12, 43);
            this.MainFeed.Name = "MainFeed";
            this.MainFeed.Size = new System.Drawing.Size(155, 658);
            this.MainFeed.TabIndex = 1;
            this.MainFeed.Text = "Feed goes here...";
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(95, 12);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(72, 23);
            this.CopyButton.TabIndex = 2;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // PositionsButton
            // 
            this.PositionsButton.Enabled = false;
            this.PositionsButton.Location = new System.Drawing.Point(12, 12);
            this.PositionsButton.Name = "PositionsButton";
            this.PositionsButton.Size = new System.Drawing.Size(77, 23);
            this.PositionsButton.TabIndex = 3;
            this.PositionsButton.Text = "Update Map";
            this.PositionsButton.UseVisualStyleBackColor = true;
            this.PositionsButton.Click += new System.EventHandler(this.PositionsButton_Click);
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.Bearing = 0F;
            this.gMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.SystemColors.Control;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(173, 43);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 18;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(648, 658);
            this.gMap.TabIndex = 5;
            this.gMap.Zoom = 10D;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 10000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // ShapesBttn
            // 
            this.ShapesBttn.Location = new System.Drawing.Point(173, 12);
            this.ShapesBttn.Name = "ShapesBttn";
            this.ShapesBttn.Size = new System.Drawing.Size(86, 23);
            this.ShapesBttn.TabIndex = 6;
            this.ShapesBttn.Text = "Make Shapes";
            this.ShapesBttn.UseVisualStyleBackColor = true;
            this.ShapesBttn.Click += new System.EventHandler(this.ShapesBttn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 714);
            this.Controls.Add(this.ShapesBttn);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.PositionsButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.MainFeed);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label MainFeed;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button PositionsButton;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Button ShapesBttn;
    }
}

