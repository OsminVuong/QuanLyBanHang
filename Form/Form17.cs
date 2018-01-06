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
    public partial class Form17 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        private SqlCommand Cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        #endregion=============================
        public Form17()
        {
            InitializeComponent();
        }

        private void Hoantat_button_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT?\n(Dữ liệu trên 'Textbox' sẽ mất)", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) this.Close();
        }

        private void Update_Pass()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "UPDATE [dbo].[Accounts] SET [Password]=@Pass Where [ID]=@ID";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@ID", ID_text.Text));
                Cmd.Parameters.Add(new SqlParameter("@Pass", Pass_text.Text));
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi Dữ Liệu !");

            }
        }
        private void Update_Quyen()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string trs = "UPDATE [dbo].[Accounts] SET [Quyenhan]=@Quyen Where [ID]=@ID";
                Cmd = new SqlCommand(trs, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@ID", ID_textBox.Text));
                Cmd.Parameters.Add(new SqlParameter("@Quyen", QuyentextBox.Text));
                Cmd.ExecuteNonQuery();
                Cnn.Close();
            }
            catch (SqlException)

            {
                MessageBox.Show("Lỗi Dữ Liệu !");

            }
        }
        #region==== Bắt lỗi Dự Liệu ============
        public bool KiemTraTextbox1()
        {
            if (ID_text.Text.Length < 4)
            {
                MessageBox.Show("'ID' Ít nhất 4 ký tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ID_text.Text = string.Empty;
                return true;
            }
            if (Pass_text.Text.Length < 4)
            {
                MessageBox.Show("'Password' Ít nhất 4 ký tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Pass_text.Text = string.Empty;
                return true;
            }

            return false;
        }
        public bool KiemTraTextbox2()
        {
            if (ID_textBox.Text.Length < 4)
            {
                MessageBox.Show("'ID' Ít nhất 4 ký tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ID_textBox.Text = string.Empty;
                return true;
            }
            if (int.Parse(QuyentextBox.Text) > 3)
            {
                MessageBox.Show("'Quyền' nhở hơn 4!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QuyentextBox.Text = string.Empty;
                return true;
            }

            return false;
        }
        #endregion ===================================

        private void UpdatePass_button_Click(object sender, EventArgs e)
        {
            if (KiemTraTextbox1() == false)
            {
                DialogResult Xacnhan;
                Xacnhan = MessageBox.Show("Bạn có muốn Update?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Xacnhan == DialogResult.Yes) Update_Pass();
            }
        }

        private void UpdateQuyentext_Click(object sender, EventArgs e)
        {
            if (KiemTraTextbox2() == false)
            {
                DialogResult Xacnhan;
                Xacnhan = MessageBox.Show("Bạn có muốn Update?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Xacnhan == DialogResult.Yes) Update_Quyen();
                MessageBox.Show(ID_text.Text+"-"+Pass_text.Text+"->"+QuyentextBox.Text);
            }
        }

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
