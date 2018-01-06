namespace Quanlybanhang
{
    partial class Form19
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form19));
            this.Hoantat_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.MaKH_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Hoantat_button
            // 
            this.Hoantat_button.BackColor = System.Drawing.Color.White;
            this.Hoantat_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hoantat_button.ForeColor = System.Drawing.Color.Red;
            this.Hoantat_button.Location = new System.Drawing.Point(383, 49);
            this.Hoantat_button.Name = "Hoantat_button";
            this.Hoantat_button.Size = new System.Drawing.Size(110, 37);
            this.Hoantat_button.TabIndex = 11;
            this.Hoantat_button.Text = "Hoàn Tất";
            this.Hoantat_button.UseVisualStyleBackColor = false;
            this.Hoantat_button.Click += new System.EventHandler(this.Hoantat_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.BackColor = System.Drawing.Color.White;
            this.Delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_button.ForeColor = System.Drawing.Color.Red;
            this.Delete_button.Location = new System.Drawing.Point(219, 49);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(110, 37);
            this.Delete_button.TabIndex = 10;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = false;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // MaKH_text
            // 
            this.MaKH_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaKH_text.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.MaKH_text.Location = new System.Drawing.Point(55, 57);
            this.MaKH_text.Name = "MaKH_text";
            this.MaKH_text.Size = new System.Drawing.Size(136, 29);
            this.MaKH_text.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(51, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 137);
            this.ControlBox = false;
            this.Controls.Add(this.Hoantat_button);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.MaKH_text);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(608, 176);
            this.MinimumSize = new System.Drawing.Size(608, 176);
            this.Name = "Form19";
            this.Text = "Xóa Khách Hàng";
            this.Load += new System.EventHandler(this.Form19_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Hoantat_button;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.TextBox MaKH_text;
        private System.Windows.Forms.Label label1;
    }
}