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
using Quanly_MiniSM.QL_SieuthiminiDataSetTableAdapters;

namespace Quanly_MiniSM
{
    public partial class Form15 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        private SqlCommand Cmd;
        
        #endregion=============================
        public Form15()
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
                { ThemAcc(); }
            }
        }
        private void ThemAcc()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "INSERT INTO [dbo].[Accounts]([ID],[Password],[MaNV],[Quyenhan]) VALUES(@ID,@Pass,@MaNV,@Quyen)";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.AddWithValue("@ID", IDtextBox.Text);
                Cmd.Parameters.AddWithValue("@Pass", PasstextBox.Text);
                Cmd.Parameters.AddWithValue("@MaNV", MaNVtextBox.Text);
                Cmd.Parameters.AddWithValue("@Quyen", QuyentextBox.Text);
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi Dữ Liệu ! ID Account Đã Tồn Tại");

            }
        }

        #region==== Bắt lỗi Dự Liệu ============
        public bool KiemTraTextbox()
        {
            


            if (IDtextBox.Text.Length < 4)
            {
                MessageBox.Show("Lỗi: 'ID' ít nhất 4 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IDtextBox.Text = string.Empty;
                return true;
            }
            if (PasstextBox.Text.Length > 0 && PasstextBox.Text.Length < 4)
            {
                MessageBox.Show("Lỗi: 'Ngày Sinh' ít nhất 4 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasstextBox.Text = string.Empty;
                return true;
            }
            if (PasstextBox.Text.Length== 0)
            {
                MessageBox.Show("Lỗi: Bạn không nhập, sẽ sữ dụng Password mặc định!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PasstextBox.Text = "12345";
                return true;
            }
            if (QuyentextBox.Text == "")
            {
                MessageBox.Show("Lỗi: Bạn không nhập, sẽ sữ dụng quyền mặc định!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                QuyentextBox.Text = "0";
                return true;
            }
            if (int.Parse(QuyentextBox.Text)>3)
            {
                MessageBox.Show("Lỗi: 'Loại quyền' nhỏ hơn 4 !", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QuyentextBox.Text = string.Empty;
                return true;
            }
            
            if (MaNVtextBox.Text.Length < 4)
            {
                MessageBox.Show("'Mã NV' Ít nhất 4 ký tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaNVtextBox.Text = string.Empty;
                return true;
            }
            return false;
        }

        #endregion ===================================

        private void QuyentextBox_TextChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(this.QuyentextBox.Text, out n))
            {

            }
            else
                QuyentextBox.Text = "";
        }
    }
}
