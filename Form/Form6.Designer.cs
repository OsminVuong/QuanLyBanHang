namespace Quanlybanhang
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.MaHDtext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Er_button = new System.Windows.Forms.Button();
            this.Hoantat_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MaHDtext
            // 
            this.MaHDtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaHDtext.Location = new System.Drawing.Point(124, 36);
            this.MaHDtext.Name = "MaHDtext";
            this.MaHDtext.Size = new System.Drawing.Size(100, 29);
            this.MaHDtext.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(39, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã HD:";
            // 
            // Er_button
            // 
            this.Er_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Er_button.ForeColor = System.Drawing.Color.Red;
            this.Er_button.Location = new System.Drawing.Point(251, 36);
            this.Er_button.Name = "Er_button";
            this.Er_button.Size = new System.Drawing.Size(108, 29);
            this.Er_button.TabIndex = 1;
            this.Er_button.Text = "Lỗi";
            this.Er_button.UseVisualStyleBackColor = true;
            this.Er_button.Click += new System.EventHandler(this.Er_button_Click);
            // 
            // Hoantat_button
            // 
            this.Hoantat_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hoantat_button.Location = new System.Drawing.Point(251, 104);
            this.Hoantat_button.Name = "Hoantat_button";
            this.Hoantat_button.Size = new System.Drawing.Size(108, 35);
            this.Hoantat_button.TabIndex = 2;
            this.Hoantat_button.Text = "Hoàn tất";
            this.Hoantat_button.UseVisualStyleBackColor = true;
            this.Hoantat_button.Click += new System.EventHandler(this.Hoantat_button_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 151);
            this.ControlBox = false;
            this.Controls.Add(this.Hoantat_button);
            this.Controls.Add(this.Er_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaHDtext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(407, 190);
            this.MinimumSize = new System.Drawing.Size(407, 190);
            this.Name = "Form6";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Báo Lỗi Hóa Đơn - Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MaHDtext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Er_button;
        private System.Windows.Forms.Button Hoantat_button;
    }
}