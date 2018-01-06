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
            Show_Grid();
           
            Load_Combobox();
        }
        #region============ List Grid ===============================
        private void Show_Grid()
        {
            Load_Grid1();
            Load_Grid2();
            Load_Grid3();
            Load_Grid4();
            Load_Grid5();
            Load_Grid6();
            Acc_Grid();

        }
        private void Load_Grid1()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT N.[MaNV] as [Mã NV],[HotenNV] as [Tên NV],[Chucvu] as [Chức Vụ],[Ngaysinh] as [Ngày Sinh],[SDT],[Diachi] as [Địa Chỉ] FROM[dbo].[Nhanvien] N INNER JOIN [dbo].[ChitietNV] C ON N.MaNV=C.MaNV  ORDER BY N.MaNV ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = Table;
                Data_Grid_NV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView.1xf4");
            }
        }
        private void Load_Grid2()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT MaSP as [Mã SP],Tensp as [Tên SP],HSD,Giaban as [Giá bán],Gianhap as [Giá Nhập],SLsp [Số Lượng], Ngaynhap as [Ngày Nhập],MaNCC as [Mã NHà CC] FROM Sanpham  ORDER BY MaSp ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                dataGridView2.DataSource = Table;
                Nhapkho_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView.2xf4");
            }
        }
        private void Load_Grid3()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã Hóa Đơn],[MaNV] as [Mã Nhân Viên],[HotenKH] as [Tên Khách Hàng],[Tongtien] as [Tổng Thanh Toán] FROM [dbo].[Hoadon] H INNER JOIN [dbo].[ChitietKH] C ON H.MaKH=C.MaKH  ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                dataGridView3.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView.3xf4");
            }
        }
        private void Load_Grid6()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã HD],[TenSP] as [Tên SP],[SLmua] as [SL],[Ngaymua] as [Ngày mua],[Thanhtien] as [Thành Tiền] FROM [dbo].[ChitietHD] C INNER JOIN [dbo].[Sanpham] S On C.MaSP =S.MaSP ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                dataGridView6.DataSource = Table;
                Spdaban_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView.6xf4");
            }
        }
        private void Load_Grid4()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaKH] as [Mã Khách Hàng],[HotenKH] as [Tên Khách Hàng],[Ngaysinh] as [Ngày Sinh],[SDT],[Diachi] as [Địa Chỉ],[Mail] FROM [dbo].[ChitietKH]  ORDER BY MaKH ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                dataGridView4.DataSource = Table;
                Data_View_KH.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView.4xf4");
            }
        }
        private void Load_Grid5()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaNCC] as [Mã Nhà CC],[Tenncc] as [Tên Nhà CC],[DiaChi] as [Địa Chỉ] FROM [dbo].[NhaCC]  ORDER BY MaNCC ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                dataGridView5.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView.5xf4");
            }
        }

        private void Acc_Grid()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [ID],[Password],[Quyenhan] as [Loại Quyền],A.[MaNV] as [Mã NV],[HotenNV] as [Tên NV],[Chucvu] as [Chức Vụ] FROM [dbo].[Accounts] A INNER JOIN [dbo].[Nhanvien] N ON A.MaNV=N.MaNV ORDER BY A.MaNV ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                Data_GridviewACC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Data_GridviewACC.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Acc_Gird.f4");
            }
        }


        #endregion================================================================

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
        #region========= Combobox =========================
        private void Load_Combobox()
        {
            Load_ComboBox1();
            Load_ComboBox2();
            Load_ComboBox3();
        }
        private void Load_ComboBox1()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string str = "Select Ngaynhap from Sanpham Group By Ngaynhap";
                Cmd = new SqlCommand(str, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    DataRow row = dt.NewRow();
                    dt.Rows.InsertAt(row, 0);
                    Ngay_NKcombo.DataSource = dt;
                    Ngay_NKcombo.DisplayMember = "Ngaynhap";
                    Ngay_NKcombo.ValueMember = "Ngaynhap";
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Combobox.1xF4");
            }
        }
        private void Load_ComboBox2()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string str = "Select Ngaymua from ChitietHD Group By Ngaymua";
                Cmd = new SqlCommand(str, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();
                    dt.Rows.InsertAt(row, 0);
                    Ngay_SPcombo.DataSource = dt;
                    Ngay_SPcombo.DisplayMember = "Ngaymua";
                    Ngay_SPcombo.ValueMember = "Ngaymua";
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Combobox.2xF4");
            }
        }
        private void Load_ComboBox3()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string str = "Select HotenNV, A.MaNV from Nhanvien N INNER JOIN Accounts A On A.MaNV=N.MaNV where Quyenhan=3";
                Cmd = new SqlCommand(str, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();
                    row["HotenNV"] = "--- Chọn tên Nhân Viên ---";
                    dt.Rows.InsertAt(row, 0);
                    Nhanvien_HDcombo.DataSource = dt;
                    Nhanvien_HDcombo.DisplayMember = "HotenNV";
                    Nhanvien_HDcombo.ValueMember = "MaNV";
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Combobox.3xF4");
            }
        }
        #endregion=========================================







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
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void XoaNV_button_Click_1(object sender, EventArgs e)
        {
            // xoa nhan vien
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void ThemAc_button_Click(object sender, EventArgs e)
        {
            // Them acc
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void SetAc_button_Click_1(object sender, EventArgs e)
        {
            // cai dat acc 
            Form17 f17 = new Form17();
            f17.Show();

        }
        private void Them_KH_Click(object sender, EventArgs e)
        {
            // thêm khach hang
            Form18 f18 = new Form18();
            f18.Show();
        }

        private void Xoa_KH_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            f19.Show();
        }

        private void TTHD_Click_Click(object sender, EventArgs e)
        {
            
        }
        
        private void XoaAc_button_Click(object sender, EventArgs e)
        {
            //xoa accounts
            Form16 f16 = new Form16();
            f16.Show();
        }
    }
}
