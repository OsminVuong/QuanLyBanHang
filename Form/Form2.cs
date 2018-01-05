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
using System.IO;

namespace Quanlybanhang
{
    public partial class Form2 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        DataTable T1 = new DataTable();
        private SqlCommand Cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        #endregion=============================
        public Form2(string inputs)
        {

            InitializeComponent();
            IDtext.Text = inputs;
        }

        #region==== Biến toàn cục =====
        // Biến tham số
        
        string bientam;
        
        #endregion=====================


        //--- Show GridView và Tên NV--------------------------
        private void Form2_Load(object sender, EventArgs e)
        {
            _Ngaythang.Text = year + "-" + month + "-" + day;
            ShowNV();
            ShowMaHD();

        }

        #region==== Ngày và giờ ====
        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        int hour = DateTime.Now.Hour;
        int Minute = DateTime.Now.Minute;
        int second = DateTime.Now.Second;
        #endregion


        #region========== Các nút lệnh =============
        // ----------- Thoát Form 2 và Khởi tạo Form 1-------
        private void button1_Click(object sender, EventArgs e)
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
                Application.Exit();

            }


        }
        //---------- Thêm dữ liệu------------
        private void button2_Click(object sender, EventArgs e)
        {
           

        }
        // Xuất Hóa đơn
        private void button5_Click(object sender, EventArgs e)
        {
            

        }
        #endregion=============================================

        #region======== Truy cập thông tin nhân viên ===========
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
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "select HotenNV from NHANVIEN WHERE MaNV = '" + IDtext.Text + "' ";
                Cmd = new SqlCommand(tamp, Cnn);
                SqlDataReader dr = Cmd.ExecuteReader();
                TenNVtext.Text = Xuat_kq(dr);
                Cnn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ++!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion===========================================================

       


        // Xem thông tin khách hàng
        private void TTKH_Click(object sender, EventArgs e)
        {
            
        }

        // Báo lỗi Hóa đơn
        private void Error_Button_Click(object sender, EventArgs e)
        {
           
          
        
        }
        // làm mới textbox mã KH
        private void Ref_button_Click(object sender, EventArgs e)
        {
            MakHtext.Text = string.Empty;
        }

        // xem thống kê
        private void Thongkef2_Click(object sender, EventArgs e)
        {
            
        }

        private void IDtext_Click(object sender, EventArgs e)
        {

        }

        #region====== Truy Cập Hóa Đơn ==================

        private void ShowMaHD()
        {

            if (DemHD() == false)
            {
                MaHDtext.Text = "1";
            }
            else
            {
                SqlConnection Cnn = db._DbContext();
                try
                {
                    Cnn.Open();
                    string tamp = "SELECT TOP(1) WITH TIES MaHD FROM Hoadon ORDER BY MaHD DESC";
                    Cmd = new SqlCommand(tamp, Cnn);
                    SqlDataReader dr = Cmd.ExecuteReader();
                    bientam = Xuat_kq(dr);
                    Cnn.Close();


                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi ShowMaHD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                int bt = int.Parse(bientam) + 1;
                MaHDtext.Text = bt.ToString();
            }
        }
        #endregion=======================================
        #region========== Hệ Đếm - Kiểm tra sự tồn tại ================

        //kiem tra Hoa don
        private bool DemHD()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(*) FROM [dbo].[Hoadon]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                if (ct >= 1)
                {
                    return true;
                }
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedemx1", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return false;
        }
        private bool DemKH(string _MaKH)
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(*) FROM [dbo].[ChitietKH] WHERE MaKH=@Ma";
                Cmd = new SqlCommand(tamp, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@Ma", _MaKH));
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                if (ct == 1)
                {
                    return true;
                }
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedemx3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return false;
        }
        private bool DemSP(string _Masp)
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(*) FROM [dbo].[Sanpham] WHERE Masp=@Ma";
                Cmd = new SqlCommand(tamp, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@Ma", _Masp));
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                if (ct == 1)
                {
                    return true;
                }
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedemx2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return false;
        }
        #endregion=======================================

        #region==== Bắt lỗi Dự Liệu ============
        public bool KiemTraTextbox()
        {
            if (MakHtext.Text.Length > 3 && DemKH(MakHtext.Text) == false)
            {
                MessageBox.Show("Mã Khách Hàng không Tồn tại!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MakHtext.Text = string.Empty;
                return true;
            }
            else
            {
                if (MakHtext.Text.Length < 4)
                {
                    MessageBox.Show("Lỗi: 'Mã Khách Hàng' ít nhất 4 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            if (Masptext.Text.Length > 3 && DemSP(Masptext.Text) == false)
            {
                MessageBox.Show("Mã Sản Phảm không Tồn tại", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Masptext.Text = string.Empty;
                return true;
            }
            else
            {
                if (Masptext.Text.Length < 4)
                {
                    MessageBox.Show("Lỗi: 'Mã Sản Phẩm' ít nhất 4 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            if (int.Parse(SLtext.Text) < 1)
            {
                MessageBox.Show("Lỗi: 'Số Lượng' phải lớn hơn 0!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        #endregion ===================================
        private void LoadGrid(string _maHD)
        {
            SqlConnection Cnn = db._DbContext();
            Cnn.Open();
            string sql = "select * From ChitietHD where MAHD=@MaHD ORDER BY MaHD DESC";
            Cmd = new SqlCommand(sql, Cnn);
            SqlDataAdapter alap = new SqlDataAdapter(Cmd);
            Cmd.Parameters.Add(new SqlParameter("@MaHD", _maHD));
            DataTable Table = new DataTable();
            alap.Fill(Table);
            DataGView.AutoGenerateColumns = false;
            DataGView.DataSource = Table;
        }

        private void LoadTable(string _Ma)
        {
            SqlConnection Cnn = db._DbContext();
            Cnn.Open();
            string sql = "select TenSP, SLmua, Giaban, Thanhtien From ChitietHD C INNER Join SanPham ON  C.MaSP = Sanpham.MaSP Where C.MaHD = @MaHD";
            Cmd = new SqlCommand(sql, Cnn);
            Cmd.Parameters.Add(new SqlParameter("@MaHD", _Ma));
            SqlDataAdapter alap = new SqlDataAdapter(Cmd);
            T1 = new DataTable();
            alap.Fill(T1);
        }

    }

}
