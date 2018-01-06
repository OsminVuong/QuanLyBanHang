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
    public partial class Form5 : Form
    {
        #region======== Chuỗi kết nối =========
        DbContext db = new DbContext();
        DataSet ds = new DataSet();
        private SqlCommand Cmd;
        private SqlDataAdapter da = new SqlDataAdapter();
        #endregion=============================

        public Form5(string input)
        {
            
            InitializeComponent();
            MaKHtext.Text = input;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            Load_Grid();
        }

        private void Load_Grid()
        {
            SqlConnection Cnn = db._DbContext();
            try
            {
                Cnn.Open();
                string sql = "select * From ChitietKH Where MaKH=@MaKh";
                Cmd = new SqlCommand(sql, Cnn);
                Cmd.Parameters.Add(new SqlParameter("@MaKH", MaKHtext.Text));
                da = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                da.Fill(Table);
                DataGView.AutoGenerateColumns = false;
                DataGView.DataSource = Table;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi DataGidView");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Close_Ap;
            Close_Ap = MessageBox.Show("Bạn có muốn THOÁT?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close_Ap == DialogResult.Yes) this.Close();
        }

        

        
    }
}
