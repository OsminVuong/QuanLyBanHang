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
using System.Threading;

namespace Quanlybanhang
{


   


    public partial class Form1 : Form
    {
        DbContext db = new DbContext();
        SqlCommand Cmd;

        public string xy;
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            SqlConnection Cnn = db._DbContext();
            Cnn.Open();
            Thread.Sleep(2000);
            InitializeComponent();
            t.Abort();
        }
        public void StartForm()
        {
            Application.Run(new Form1SplashCreen());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //--------------------- Chỉnh Size Form ---------------------------------------------
        public void SetSize(System.Windows.Forms.Form frm)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey( frm.Name);
                frm.Height = (int)key.GetValue("Height", frm.Height);
                frm.Width = (int)key.GetValue("Width", frm.Width);
                frm.Left = (int)key.GetValue("Left", frm.Left);
                frm.Top = (int)key.GetValue("Top", frm.Top);
                //
    


            }
            catch
            {
            }
        }
        #region======== Truy cập thông tin NV và Accounts===========
        //-- Đọc dữ theo tuần tự từng dòng và truy xuất chỉ số cột
        string bientam;
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
        //--- truy cập và gán vào biến tạm
        private void ShowQuyenhan()
        {
            SqlConnection Cnn = db._DbContext();
            Cnn.Open();
            try
            {
                
                string tamp = "select Quyenhan from Accounts WHERE MaNV = '" + Taikhoan.Text + "' ";
                Cmd = new SqlCommand(tamp, Cnn);
                SqlDataReader dr = Cmd.ExecuteReader();
                bientam= Xuat_kq(dr);
                

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Search Accounts!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

       
        #endregion===========================================================
        //------------------ Nút Login ---------------------------------------
        public void button1_Click(object sender, EventArgs e)
        {
            ShowQuyenhan();
            try
            {
                SqlConnection Cnn = db._DbContext();
                Cnn.Open();

                string login_in = "Select Count(*) from Accounts Where ID=@acc and Password=@pass";
                Cmd = new SqlCommand(login_in, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@acc", Taikhoan.Text));
                Cmd.Parameters.Add(new SqlParameter("@pass", Matkhau.Text));
                int K = (int)Cmd.ExecuteScalar();
                if (K == 1)
                {
                    //string Str = Taikhoan.Text;
                    //Str =Str.Split('0')[1];
                    //Str = Str.Substring(0,1);
                    int x = int.Parse(bientam);
                    if (x == 1)
                    {
                        LoadnewForm4();
                    }
                    if (x == 2)
                    {
                        LoadnewForm3();
                    }
                    if (x == 3)
                    {
                        LoadnewForm2(Taikhoan.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa có quyền Truy Cập Hệ Thống!"+"\nHệ Thống đang cập nhật... Vui lòng liên hệ Quản Trị Viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                else
                {
                    
                    MessageBox.Show("Login Failed !!!"+ "\nError: The account and password that you've entered is incorrect. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối . : . : .' .- ");
                
              
            }
            
            Taikhoan.Text = string.Empty;
            Matkhau.Text = string.Empty;


        }
        //----------------------------- Show Form 2 -----------------------------------
        private void LoadnewForm2(string Texxt)
        {
            //Form2 frm2 = new Form2(Taikhoan.Text);
            //this.Visible = false;
            //if ((new Form2(Taikhoan.Text)).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{ this.Visible = true; }

            //frm2.Show();

        }

        //------------------------- Show Form 3 -----------------------------------
        private void LoadnewForm3()
        {
            //Form3 frm3 = new Form3(Taikhoan.Text);
            //this.Visible = false;
            //if ((new Form3(Taikhoan.Text)).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{ this.Visible = true; }
            //frm3.Show();
            //this.Close();
        }
        //-------------------------------- Show Form 4 -----------------------------
        private void LoadnewForm4()
        {
            //Form4 frm4 = new Form4(Taikhoan.Text);
            //this.Visible = false;
            //if ((new Form4(Taikhoan.Text)).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{ this.Visible = true; }
            //frm4.Show();
            //this.Close();
        }
        //------------------ Button Thoát -----------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT khỏi ứng dụng?","Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) Application.Exit();
        }

        //---------------- Button Logo hutech - xem thông tin ------------------
        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là phầm mềm Quản Lý Siêu Thị Mini\n\nDo nhóm lập trình và thiết kế: Lê Hoàng Vương \n\n Thiết kế nhằm phục vụ cho các shop hoặc các siêu thị nhỏ,\nhằm quản lý nhân viên, sản phẩm, thu ngân, hóa đơn, khách hàng...\n\n [Bài đồ án: Lập trình C trên WINDOWS - Hutech University]\n\n>>Liên Hệ: 01673056729", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
