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
    public partial class Form14 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        private SqlCommand Cmd;
        
        #endregion=============================
        public Form14()
        {
            InitializeComponent();
        }

        private void Hoantat_button_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT?\n(Dữ liệu trên 'Textbox' sẽ mất)", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) this.Close();
        }

        private void DeleteNV_button_Click(object sender, EventArgs e)
        {
            if (KiemTraTextbox() == false)
            {
                DialogResult Xacnhan;
                Xacnhan = MessageBox.Show("Bạn có muốn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Xacnhan == DialogResult.Yes) { Xoa_CTNV(); Xoa_NV(); }
                MessageBox.Show("Đã Xóa Xong!");
            }
        }

        private void Xoa_NV()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "DELETE FROM [dbo].[Nhanvien] WHERE MaNV=@MaNV";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.AddWithValue("@MaNV", MaNV_text.Text);
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi Dữ Liệu !");

            }
        }
        private void Xoa_CTNV()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "DELETE FROM [dbo].[ChitietNV] WHERE MaNV=@MaNV";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.AddWithValue("@MaNV", MaNV_text.Text);
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi Dữ Liệu !");

            }
        }

        #region==== Bắt lỗi Dự Liệu ============
        public bool KiemTraTextbox()
        {
            if (MaNV_text.Text.Length < 4)
            {
                MessageBox.Show("'Mã Nhân Viên' Ít nhất 4 ký tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaNV_text.Text = string.Empty;
                return true;
            }

            return false;
        }
        #endregion ===================================
    }
}
