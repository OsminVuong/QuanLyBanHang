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
            Show_Load();
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
        #region========== Load Grid of Combobox ===========
        private void Load_Grid_Combobox1(string ngay)
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT MaSP as [Mã SP],Tensp as [Tên SP],HSD,Giaban as [Giá bán],Gianhap as [Giá Nhập],SLsp [Số Lượng],MaNCC as [Mã NHà CC] FROM Sanpham  where Ngaynhap=@Ngaynhap ORDER BY MaSp ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@Ngaynhap", ngay));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                Nhapkho_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidViewCombobox.1xf4");
            }
        }
        private void Load_Grid_Combobox2(string ngay)
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã HD],[TenSP] as [Tên SP],[SLmua] as [SL],[Thanhtien] as [Thành Tiền] FROM [dbo].[ChitietHD] C INNER JOIN [dbo].[Sanpham] S On C.MaSP =S.MaSP Where Ngaymua=@Ngaymua ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@Ngaymua", ngay));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                Spdaban_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidViewCombobox.2xf4");
            }
        }
        private void Load_Grid_Combobox3(string _MaNV)
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã Hóa Đơn],[HotenKH] as [Tên Khách Hàng],[Tongtien] as [Tổng Thanh Toán] FROM [dbo].[Hoadon] H INNER JOIN [dbo].[ChitietKH] C ON H.MaKH=C.MaKH Where Tongtien>0 and MaNV=@MaNV ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", _MaNV));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                Hoadon_ok_DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Hoadon_ok_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidViewCombobox.3xf4");
            }
        }
        private void Load_Grid_Combobox4(string _MaNv)
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã Hóa Đơn],[HotenKH] as [Tên Khách Hàng],[Tongtien] as [Tổng Thanh Toán] FROM [dbo].[Hoadon] H INNER JOIN [dbo].[ChitietKH] C ON H.MaKH=C.MaKH Where Tongtien=0 and MaNV=@MaNV ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaNV", _MaNv));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                Hoadon_loi_DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Hoadon_loi_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidViewCombobox.4xf4");
            }
        }
        private void Load_Grid_Combobox4_2()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã Hóa Đơn],[MaNV] as [Mã Nhân Viên],[HotenKH] as [Tên Khách Hàng],[Tongtien] as [Tổng Thanh Toán] FROM [dbo].[Hoadon] H INNER JOIN [dbo].[ChitietKH] C ON H.MaKH=C.MaKH Where Tongtien!=0 ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                Hoadon_ok_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidViewCombobox.4_2xf4");
            }
        }
        private void Load_Grid_Combobox4_3()
        {

            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã Hóa Đơn],[MaNV] as [Mã Nhân Viên],[HotenKH] as [Tên Khách Hàng],[Tongtien] as [Tổng Thanh Toán] FROM [dbo].[Hoadon] H INNER JOIN [dbo].[ChitietKH] C ON H.MaKH=C.MaKH Where Tongtien=0 ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                Hoadon_loi_DGV.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidViewCombobox.4_3xf4");
            }
        }
        #endregion=========================================
        #region===== Sự kiện Combobox ======
        private void Ngay_NKcombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (Ngay_NKcombo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Load_Grid_Combobox1(Ngay_NKcombo.SelectedValue.ToString());
            }
            else
            {
                Load_Grid2();
            }
            if (Ngay_NKcombo.SelectedValue.ToString() == "")
            {
                Load_Grid2();
            }
        }

        private void Ngay_SPcombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Ngay_SPcombo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Load_Grid_Combobox2(Ngay_SPcombo.SelectedValue.ToString());
            }
            else
            {
                Load_Grid6();
            }
            if (Ngay_SPcombo.SelectedValue.ToString() == "")
            {
                Load_Grid6();
            }
        }

        private void Nhanvien_HDcombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (Nhanvien_HDcombo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Load_Grid_Combobox3(Nhanvien_HDcombo.SelectedValue.ToString());
                Load_Grid_Combobox4(Nhanvien_HDcombo.SelectedValue.ToString());
            }
            else
            {
                Load_Grid_Combobox4_2();
                Load_Grid_Combobox4_3();
            }
            if (Nhanvien_HDcombo.SelectedValue.ToString() == "")
            {
                Load_Grid_Combobox4_2();
                Load_Grid_Combobox4_3();
            }
        }
        #endregion==========================
        
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

        #region============== Bộ Đếm ========================
        private void Show_Load()
        {
            DemHD();
            DemHDLoi();
            DemHDOK();
            DemKHCOK();
            DemKHDK();
            DemLSP();
            DemNV();
            DemDanhThu();
            DemNCC();
            DemSLdaban();
            DemTiennhap();
            DemSLHientai();
            DemSLSP();
            // NhaCCitnhat();
           //  NhaCCnhieunhat();
        }
        private void DemNV()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaNV) FROM [dbo].[Nhanvien]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongNVtext.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.1xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemLSP()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaSP) FROM [dbo].[Sanpham]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongSPtext.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.2xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void DemKHDK()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaKH) FROM [dbo].[ChitietKH] Where MaKH != 'KH00'";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongKHDKtext.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.3xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemKHCOK()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaKH) FROM [dbo].[Hoadon] Where MaKH ='KH00'";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongKHCDKtext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.4xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemHD()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaHD) FROM [dbo].[Hoadon]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongHDtext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.5xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemHDOK()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaHD) FROM [dbo].[Hoadon] Where Tongtien!=0";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongHDOKtext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.6xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemHDLoi()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaHD) FROM [dbo].[Hoadon] Where Tongtien=0";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongHDLoitext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.7xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemNCC()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT COUNT(MaNCC) FROM [dbo].[NhaCC]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongNCCtext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.8xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemSLSP()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT SUM(SLnhap) FROM [dbo].[Sanpham]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongSPnhaptext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.9xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemSLHientai()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT SUM(SLsp) FROM [dbo].[Sanpham]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongSLhientaitext.Text = ct.ToString();
                TongSPtontext.Text = ct.ToString();
                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.10xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemSLdaban()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT SUM(SLmua) FROM [dbo].[ChitietHD]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TongSPdabantext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.11xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemTiennhap()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT SUM(Gianhap*SLnhap) FROM [dbo].[Sanpham]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                TiennhapSPtext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.12xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void DemDanhThu()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string tamp = "SELECT SUM(Tongtien) FROM [dbo].[Hoadon]";
                Cmd = new SqlCommand(tamp, Cnn);
                int ct = int.Parse(Cmd.ExecuteScalar().ToString());
                Danhthutext.Text = ct.ToString();

                Cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hedem.13xF4 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion=======================================================

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
            if (MaKH_HD.Text.Length > 3 && DemKH(MaKH_HD.Text) == false)
            {
                MessageBox.Show("'Mã Khách Hàng' không tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MaKH_HD.Text.Length < 4)
                {
                    MessageBox.Show("Lỗi: 'Mã Khách Hàng ' ít nhất 4 Ký Tự!", "Thống Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Load_GridKH();
                }
            }
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



        private bool KiemTraKH(string _MaKH)
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
                MessageBox.Show("Lỗi hedem_kh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return false;
        }

        private void Load_GridKH()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "SELECT [MaHD] as [Mã Hóa Đơn],[HotenKH] as [Tên Khách Hàng],[Tongtien] as [Tổng Thanh Toán] FROM [dbo].[Hoadon] H INNER JOIN [dbo].[ChitietKH] C ON H.MaKH=C.MaKH where C.MaKH=@MaKH ORDER BY MaHD ASC";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaKH", MaKH_HD.Text));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                //DataGView1.AutoGenerateColumns = false;
                Data_View_HDKH.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView.3xf4");
            }
        

    }
        
        private void XoaAc_button_Click(object sender, EventArgs e)
        {
            //xoa accounts
            Form16 f16 = new Form16();
            f16.Show();
        }
    }
}
