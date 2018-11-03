using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection _SqlConn;

        public SqlConnection SqlConn
        {
            get
            {
                return _SqlConn;
            }

            set
            {
                _SqlConn = value;
            }
        }

        protected void OpenConnection()
        {
            String stringConn = "Server=localhost\\SQLEXPRESS;Database=EmpresaDeViajes;Integrated Security=true";
            SqlConn = new SqlConnection(stringConn);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }
    }
}
