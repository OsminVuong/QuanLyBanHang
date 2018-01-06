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
            Load_Grid1();
            Load_Grid2();
            Load_Grid3();
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
        #region======= Load Gridview ===========
        private void Load_Grid1()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT H.MaHD as [Mã KH], HotenKH as [Tên KH], Ngaymua AS [Ngày mua], Tongtien as [Tổng Tiền] FROM Hoadon H INNER JOIN ChitietKH C ON H.MaKH = C.MaKH INNER JOIN ChitietHD A ON H.MaHD=A.MaHD WHERE Tongtien >0 and MaNV= @MaNV Group by H.MaHD,HotenKH,Ngaymua,Tongtien ORDER BY H.MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", IDtext.Text));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                DataGView1.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView1");
            }
        }
        private void Load_Grid2()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT H.MaHD as [Mã HD],Tensp as [Tên SP], Sum(SLmua) AS [SL mua], Thanhtien as [Thành Tiền] FROM Hoadon H INNER JOIN ChitietHD A ON H.MaHD=A.MaHD INNER JOIN Sanpham S ON A.MaSP=S.MaSP WHERE Tongtien >0 and MaNV= @MaNV Group by H.MaHD,Tensp,Thanhtien ORDER BY H.MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", IDtext.Text));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                DataGView2.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView2");
            }
        }
        private void Load_Grid3()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT H.MaHD as [Mã HD], HotenKH as [Tên KH], Ngaymua AS [Ngày mua]FROM Hoadon H INNER JOIN ChitietKH C ON H.MaKH = C.MaKH INNER JOIN ChitietHD A ON H.MaHD=A.MaHD WHERE Tongtien < 1 and MaNV= @MaNV Group by H.MaHD,HotenKH,Ngaymua ORDER BY H.MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", IDtext.Text));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                DataGView3.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView3");
            }
        }

        #endregion===========================================
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
