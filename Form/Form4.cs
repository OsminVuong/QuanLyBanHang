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
    public partial class Form4 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        private SqlCommand Cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        #endregion=============================
        public Form4(string input)
        {
            InitializeComponent();
            IDtext.Text = input;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            ShowNV();            
        }

        #region======== Truy cập thông tin NV===========
        //-- Đọc dữ theo tuần tự từng dòng và truy xuất chỉ số cột
        private string Xuat_kq(SqlDataReader kq)
        {
            StringBuilder strb = new StringBuilder();
            while (kq.Read())
            {

                //-- Truy chỉ số cột
                for (int i = 0; i < kq.FieldCount; i++)
                    strb.Append(kq[i].ToString() + (i == kq.FieldCount - 1 ? "" : ":"));
                strb.AppendLine();
            }
            return strb.ToString();
        }
        //--- Tải tên NV lên Lable
        private void ShowNV()
        {
            
            try
            {
                SqlConnection Cnn = db._DbContext();
                Cnn.Open();
                string tamp = "select HotenNV from NHANVIEN WHERE MaNV = '" + IDtext.Text + "' ";
                Cmd = new SqlCommand(tamp, Cnn);
                SqlDataReader dr = Cmd.ExecuteReader();
                TenNVtext.Text = Xuat_kq(dr);
                Cnn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi GUI ADmin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

       
        
        #endregion===========================================================

       

       

        
        private void CloseForm4_Click(object sender, EventArgs e)
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

        

        private void Refresh_button_Click(object sender, EventArgs e)
        {
            // reset 
        }

       
        private void ThemNV_button_Click_1(object sender, EventArgs e)
        {
            //them
        }

        private void XoaNV_button_Click_1(object sender, EventArgs e)
        {
          
        }

        private void ThemAc_button_Click(object sender, EventArgs e)
        {
           
        }

        private void SetAc_button_Click_1(object sender, EventArgs e)
        {
            
        }

        

        private void Them_KH_Click(object sender, EventArgs e)
        {
            
        }

        private void Xoa_KH_Click(object sender, EventArgs e)
        {
            
        }

        private void TTHD_Click_Click(object sender, EventArgs e)
        {
            
        }
        
        private void XoaAc_button_Click(object sender, EventArgs e)
        {
        }
    }
}
