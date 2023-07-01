
namespace Fintech.Forms
{
    partial class Deposit
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
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.amountLabel = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.amount = new Guna.UI.WinForms.GunaTextBox();
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gunaLabel1.Location = new System.Drawing.Point(121, 15);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(76, 25);
            this.gunaLabel1.TabIndex = 1;
            this.gunaLabel1.Text = "Deposit";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gunaLabel2.Location = new System.Drawing.Point(12, 59);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(64, 20);
            this.gunaLabel2.TabIndex = 2;
            this.gunaLabel2.Text = "Balance:";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.amountLabel.Location = new System.Drawing.Point(97, 59);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(0, 20);
            this.amountLabel.TabIndex = 3;
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel4.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaLabel4.Location = new System.Drawing.Point(13, 111);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(112, 17);
            this.gunaLabel4.TabIndex = 4;
            this.gunaLabel4.Text = "Amount to Deposit";
            // 
            // amount
            // 
            this.amount.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.amount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.amount.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.amount.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.amount.FocusedForeColor = System.Drawing.SystemColors.Control;
            this.amount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.amount.ForeColor = System.Drawing.SystemColors.Control;
            this.amount.Location = new System.Drawing.Point(19, 142);
            this.amount.Name = "amount";
            this.amount.PasswordChar = '\0';
            this.amount.SelectedText = "";
            this.amount.Size = new System.Drawing.Size(276, 29);
            this.amount.TabIndex = 5;
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.SlateBlue;
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.Fuchsia;
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.Image = null;
            this.gunaGradientButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton1.Location = new System.Drawing.Point(16, 212);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Size = new System.Drawing.Size(280, 36);
            this.gunaGradientButton1.TabIndex = 7;
            this.gunaGradientButton1.Text = "DEPOSIT";
            this.gunaGradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton1.Click += new System.EventHandler(this.gunaGradientButton1_Click);
            // 
            // Deposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(316, 313);
            this.Controls.Add(this.gunaGradientButton1);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel amountLabel;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI.WinForms.GunaTextBox amount;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
    }
}