using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Quanlybanhang
{   

    public partial class Form3 : Form
    {
       
        public Form3(string input)
        {
            InitializeComponent();
            IDtext.Text = input;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        
        private void CloseForm3_Click(object sender, EventArgs e)
        {
            DialogResult Cl_Ap;
            Cl_Ap = MessageBox.Show("Bạn có muốn THOÁT ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Cl_Ap == DialogResult.Yes)
            {
                Form1 frm1 = new Form1();
                this.Visible = false;
                if ((new Form1()).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                { this.Visible = true; }
                frm1.Show();
                this.Close();
            }
        }

        private void ThemSPbutton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateSLbutton_Click(object sender, EventArgs e)
        {

        }

        private void XóaSPbutton_Click(object sender, EventArgs e)
        {

        }

        private void ThemNCCbutton_Click(object sender, EventArgs e)
        {

        }

        private void XoaNCCbutton_Click(object sender, EventArgs e)
        {

        }

        private void Reftextbox_Click(object sender, EventArgs e)
        {

        }
    }
}
