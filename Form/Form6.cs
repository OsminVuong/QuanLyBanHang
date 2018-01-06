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
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        private SqlCommand Cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        #endregion=============================
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
            Update_Tongtien_HD(MaHDtext.Text);
            MessageBox.Show("Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Update_Tongtien_HD(string _MaDH)
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string themHD = "UPDATE [dbo].[Hoadon] SET [Tongtien] = @Tongtien WHERE MaHD = @MaHD";
                Cmd = new SqlCommand(themHD, Cnn);
                Cmd.Parameters.AddWithValue("@Tongtien", "0");
                Cmd.Parameters.AddWithValue("@MaHD", _MaDH);
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi CT Hóa Đơn Table !");

            }
        }
    }
}
