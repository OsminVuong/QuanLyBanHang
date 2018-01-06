namespace Quanlybanhang
{
    partial class Form14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14));
            this.Hoantat_button = new System.Windows.Forms.Button();
            this.DeleteNV_button = new System.Windows.Forms.Button();
            this.MaNV_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Hoantat_button
            // 
            this.Hoantat_button.BackColor = System.Drawing.Color.White;
            this.Hoantat_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hoantat_button.ForeColor = System.Drawing.Color.Red;
            this.Hoantat_button.Location = new System.Drawing.Point(404, 79);
            this.Hoantat_button.Name = "Hoantat_button";
            this.Hoantat_button.Size = new System.Drawing.Size(110, 37);
            this.Hoantat_button.TabIndex = 6;
            this.Hoantat_button.Text = "Hoàn Tất";
            this.Hoantat_button.UseVisualStyleBackColor = false;
            this.Hoantat_button.Click += new System.EventHandler(this.Hoantat_button_Click);
            // 
            // DeleteNV_button
            // 
            this.DeleteNV_button.BackColor = System.Drawing.Color.White;
            this.DeleteNV_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteNV_button.ForeColor = System.Drawing.Color.Red;
            this.DeleteNV_button.Location = new System.Drawing.Point(190, 79);
            this.DeleteNV_button.Name = "DeleteNV_button";
            this.DeleteNV_button.Size = new System.Drawing.Size(110, 37);
            this.DeleteNV_button.TabIndex = 5;
            this.DeleteNV_button.Text = "Delete";
            this.DeleteNV_button.UseVisualStyleBackColor = false;
            this.DeleteNV_button.Click += new System.EventHandler(this.DeleteNV_button_Click);
            // 
            // MaNV_text
            // 
            this.MaNV_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaNV_text.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.MaNV_text.Location = new System.Drawing.Point(26, 87);
            this.MaNV_text.Name = "MaNV_text";
            this.MaNV_text.Size = new System.Drawing.Size(136, 29);
            this.MaNV_text.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 161);
            this.ControlBox = false;
            this.Controls.Add(this.Hoantat_button);
            this.Controls.Add(this.DeleteNV_button);
            this.Controls.Add(this.MaNV_text);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(560, 200);
            this.MinimumSize = new System.Drawing.Size(560, 200);
            this.Name = "Form14";
            this.Text = "Xóa Nhân Viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Hoantat_button;
        private System.Windows.Forms.Button DeleteNV_button;
        private System.Windows.Forms.TextBox MaNV_text;
        private System.Windows.Forms.Label label1;
    }
}