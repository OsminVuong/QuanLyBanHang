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




    public partial class Form1SplashCreen : Form
    {

        public string xy;
        public Form1SplashCreen()
        {
            InitializeComponent();
        }

        private void Form1SplashCreen_Load(object sender, EventArgs e)
        {
            

        }

        //--------------------- Chỉnh Size Form ---------------------------------------------
        public void SetSize(System.Windows.Forms.Form frm)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(frm.Name);
                frm.Height = (int)key.GetValue("Height", frm.Height);
                frm.Width = (int)key.GetValue("Width", frm.Width);
                frm.Left = (int)key.GetValue("Left", frm.Left);
                frm.Top = (int)key.GetValue("Top", frm.Top);
            }
            catch
            {
            }
        }
    }
}
