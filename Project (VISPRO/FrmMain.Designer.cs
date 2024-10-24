namespace Project__VISPRO
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnDorm = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(12, 613);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 39);
            this.btnLogout.TabIndex = 40;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBooking.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBooking.Location = new System.Drawing.Point(82, 197);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(120, 34);
            this.btnBooking.TabIndex = 36;
            this.btnBooking.Text = "Booking";
            this.btnBooking.UseVisualStyleBackColor = false;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnDorm
            // 
            this.btnDorm.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDorm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDorm.Location = new System.Drawing.Point(82, 362);
            this.btnDorm.Name = "btnDorm";
            this.btnDorm.Size = new System.Drawing.Size(120, 34);
            this.btnDorm.TabIndex = 34;
            this.btnDorm.Text = "Dormitory";
            this.btnDorm.UseVisualStyleBackColor = false;
            this.btnDorm.Click += new System.EventHandler(this.btnDorm_Click_1);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.ForestGreen;
            this.btnHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHome.Location = new System.Drawing.Point(12, 573);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(111, 34);
            this.btnHome.TabIndex = 30;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInfo.Location = new System.Drawing.Point(82, 278);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(120, 34);
            this.btnInfo.TabIndex = 32;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(-9, -6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1274, 678);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 49;
            this.pictureBox5.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.btnDorm);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.pictureBox5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBooking;
        private System.Windows.Forms.Button btnDorm;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}