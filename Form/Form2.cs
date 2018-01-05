﻿using System;
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

        
        //--- Show GridView và Tên NV--------------------------
        private void Form2_Load(object sender, EventArgs e)
        {
            
            ShowNV();
            

        }

     
      

        #region========== Các nút lệnh =============
        // ----------- Thoát Form 2 và Khởi tạo Form 1-------
        private void button1_Click(object sender, EventArgs e)
        {
            


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
    }
}
