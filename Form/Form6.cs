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
    public partial class Form6 : Form
    {
        
        public Form6()
        {
            InitializeComponent();
        }

        private void Hoantat_button_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) this.Close();
        }

        private void Er_button_Click(object sender, EventArgs e)
        {
            
        }


    }
}
