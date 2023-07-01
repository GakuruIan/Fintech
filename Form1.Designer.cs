
namespace Fintech
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gunaGradientPanel1 = new Guna.UI.WinForms.GunaGradientPanel();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.loader = new Guna.UI.WinForms.GunaGradientPanel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gunaGradientPanel1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaGradientPanel1
            // 
            this.gunaGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.gunaGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaGradientPanel1.BackgroundImage")));
            this.gunaGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaGradientPanel1.Controls.Add(this.gunaPanel1);
            this.gunaGradientPanel1.Controls.Add(this.gunaLabel3);
            this.gunaGradientPanel1.Controls.Add(this.gunaLabel2);
            this.gunaGradientPanel1.Controls.Add(this.gunaLabel1);
            this.gunaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradientPanel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.gunaGradientPanel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.gunaGradientPanel1.GradientColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.gunaGradientPanel1.GradientColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.gunaGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradientPanel1.Name = "gunaGradientPanel1";
            this.gunaGradientPanel1.Size = new System.Drawing.Size(762, 423);
            this.gunaGradientPanel1.TabIndex = 0;
            this.gunaGradientPanel1.Text = "gunaGradientPanel1";
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.Controls.Add(this.loader);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 410);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(762, 13);
            this.gunaPanel1.TabIndex = 3;
            // 
            // loader
            // 
            this.loader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loader.BackgroundImage")));
            this.loader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loader.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(232)))), ((int)(((byte)(158)))));
            this.loader.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.loader.GradientColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(232)))), ((int)(((byte)(158)))));
            this.loader.GradientColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(50, 13);
            this.loader.TabIndex = 4;
            this.loader.Text = "gunaGradientPanel2";
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaLabel3.Location = new System.Drawing.Point(272, 221);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(215, 25);
            this.gunaLabel3.TabIndex = 2;
            this.gunaLabel3.Text = "Secure Banking Services";
            this.gunaLabel3.Click += new System.EventHandler(this.gunaLabel3_Click);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaLabel2.Location = new System.Drawing.Point(12, 378);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(73, 17);
            this.gunaLabel2.TabIndex = 1;
            this.gunaLabel2.Text = "Loading......";
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaLabel1.Location = new System.Drawing.Point(146, 94);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(465, 86);
            this.gunaLabel1.TabIndex = 0;
            this.gunaLabel1.Text = "FINTECH BANK";
            this.gunaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gunaLabel1.Click += new System.EventHandler(this.gunaLabel1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 423);
            this.Controls.Add(this.gunaGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.gunaGradientPanel1.ResumeLayout(false);
            this.gunaGradientPanel1.PerformLayout();
            this.gunaPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientPanel gunaGradientPanel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaGradientPanel loader;
        private System.Windows.Forms.Timer timer1;
    }
}

