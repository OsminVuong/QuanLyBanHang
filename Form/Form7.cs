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
    public partial class Form7 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        DataTable T1 = new DataTable();
        private SqlCommand Cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        #endregion=============================
        public Form7(string input)
        {
            InitializeComponent();
            IDtext.Text = input;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Showtextbox();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) this.Close();
        }

        private void Showtextbox()
        {
            DemHD();
            DemHDER();
            DemSP();
            TongDT();
        }

        #region====== Đếm ========
        private void DemHD()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(*) FROM [dbo].[Hoadon] Where Tongtien >0 and MaNV=@MaNV";
                Cmd = new SqlCommand(tamp, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", IDtext.Text));
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                SLHD.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedemx1 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemHDER()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(*) FROM [dbo].[Hoadon] Where Tongtien <1 and MaNV=@MaNV";
                Cmd = new SqlCommand(tamp, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", IDtext.Text));
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                SLHDError.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedemx2 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void TongDT()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT sum(Tongtien) FROM [dbo].[Hoadon] Where Tongtien >0 and MaNV=@MaNV";
                Cmd = new SqlCommand(tamp, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", IDtext.Text));
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                DTtext.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedemx2 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemSP()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(DISTINCT C.MaSP) FROM Hoadon H INNER JOIN ChitietHD C ON H.MaHD = C.MaHD  Where H.Tongtien >0 and MaNV=@MaNV";
                Cmd = new SqlCommand(tamp, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", IDtext.Text));
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                SLSP.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedemx3 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion===================================================
    }
}
