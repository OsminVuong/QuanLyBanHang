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
    public partial class Form13 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();        
        private SqlCommand Cmd;
        #endregion=============================
        public Form13()
        {
            InitializeComponent();
        }

       

        private void Tem_button_Click(object sender, EventArgs e)
        {
            if (KiemTraTextbox() == false)
            {
                DialogResult Xacnhan;
                Xacnhan = MessageBox.Show("Bạn có muốn Thêm", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Xacnhan == DialogResult.Yes)
                { ThemNV(); ThemCTNV();  }
            }
          
        }


        private void Hoantatbutton_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT?\n(Dữ liệu trên 'Textbox' sẽ mất)", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) this.Close();
        }

        private void ThemNV()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "INSERT INTO [dbo].[Nhanvien]([MaNV],[HotenNV],[Chucvu]) VALUES(@Manv,@TenNV,@Chucvu)";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.AddWithValue("@Manv", MaNVtextBox.Text);
                Cmd.Parameters.AddWithValue("@TenNV", HotentextBox.Text);
                Cmd.Parameters.AddWithValue("@Chucvu", ChucvutextBox.Text);
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi Dữ Liệu ! Mã Nhân Viên Đã Tồn Tại");

            }
        }

        private void ThemCTNV()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "INSERT INTO [dbo].[ChitietNV]([MaNV],[Ngaysinh],[SDT],[Diachi]) VALUES(@Manv,@ngaysinh,@SDT,@diachi)";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.AddWithValue("@Manv", MaNVtextBox.Text);
                Cmd.Parameters.AddWithValue("@ngaysinh", NgaysinhtextBox.Text);
                Cmd.Parameters.AddWithValue("@SDT", SDTtextBox.Text);
                Cmd.Parameters.AddWithValue("@diachi", DiachitextBox.Text);
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
            if (MaNVtextBox.Text.Length < 4)
            {
                MessageBox.Show("'Mã NV' Ít nhất 4 ký tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaNVtextBox.Text = string.Empty;
                return true;
            }


            if (HotentextBox.Text.Length < 3)
            {
                MessageBox.Show("Lỗi: 'Họ Tên NV' ít nhất 3 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HotentextBox.Text = string.Empty;
                return true;
            }
            if (NgaysinhtextBox.Text.Length < 8)
            {
                MessageBox.Show("Lỗi: 'Ngày Sinh' ít nhất 8 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NgaysinhtextBox.Text = string.Empty;
                return true;
            }
            if (ChucvutextBox.Text.Length < 2)
            {
                MessageBox.Show("Lỗi: 'Chức Vụ' ít nhất 2 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ChucvutextBox.Text = string.Empty;
                return true;
            }
            if (DiachitextBox.Text.Length < 2)
            {
                MessageBox.Show("Lỗi: 'Địa Chỉ' ít nhất 2 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DiachitextBox.Text = string.Empty;
                return true;
            }
            return false;
        }

        #endregion ===================================

        

        
    }
}
