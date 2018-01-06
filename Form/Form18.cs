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

    
    public partial class Form18 : Form
    {

        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        private SqlCommand Cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        #endregion=============================
        public Form18()
        {
            InitializeComponent();
        }

        private void Hoantatbutton_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT?\n(Dữ liệu trên 'Textbox' sẽ mất)", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) this.Close();
        }

        private void Tem_button_Click(object sender, EventArgs e)
        {
            if (KiemTraTextbox() == false)
            {
                DialogResult Xacnhan;
                Xacnhan = MessageBox.Show("Bạn có muốn Thêm", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Xacnhan == DialogResult.Yes)
                { ThemKH();  }
            }
        }

        private void ThemKH()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "INSERT INTO [dbo].[ChitietKH] ([MaKH],[HotenKH],[Ngaysinh],[SDT],[Diachi],[Mail]) VALUES(@MaKH,@HotenKH,@Ngaysinh,@SDT,@Diachi,@Mail)";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.AddWithValue("@MaKH", MaKHtextBox.Text);
                Cmd.Parameters.AddWithValue("@HotenKH", HotenKHtextBox.Text);
                Cmd.Parameters.AddWithValue("@Ngaysinh", NgaysinhKHtextBox.Text);
                Cmd.Parameters.AddWithValue("@SDT", SDTtextBox.Text);
                Cmd.Parameters.AddWithValue("@Diachi", DiachitextBox.Text);
                Cmd.Parameters.AddWithValue("@Mail", MailtextBox.Text);
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi Dữ Liệu ! Mã Khách Hàng Đã Tồn Tại");

            }
        }

        #region==== Bắt lỗi Dự Liệu ============
        public bool KiemTraTextbox()
        {
            if (MaKHtextBox.Text.Length < 4)
            {
                MessageBox.Show("'Mã NV' Ít nhất 4 ký tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaKHtextBox.Text = string.Empty;
                return true;
            }


            if (HotenKHtextBox.Text.Length < 3)
            {
                MessageBox.Show("Lỗi: 'Họ Tên NV' ít nhất 3 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HotenKHtextBox.Text = string.Empty;
                return true;
            }
            if (NgaysinhKHtextBox.Text.Length < 8)
            {
                MessageBox.Show("Lỗi: 'Ngày Sinh' ít nhất 8 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NgaysinhKHtextBox.Text = string.Empty;
                return true;
            }
           
            return false;
        }

        #endregion ===================================

        private void Form18_Load(object sender, EventArgs e)
        {

        }
    }
}
