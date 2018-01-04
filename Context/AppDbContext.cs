using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlybanhang
{
    class DbContext
    {
        public static SqlConnection Cnn = null;
        public SqlConnection _DbContext()
        {
            Cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;;AttachDbFilename=|DataDirectory|\QL_Sieuthimini.mdf;Initial Catalog=QL_Sieuthimini;Integrated Security=True");
            return Cnn;
        }
    }
}
