using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class Connection
    {
        private SqlConnection connec = new SqlConnection("Server=DESKTOP-R1E8E6O\\SQLEXPRESS; Database=CalogoOnline; Integrated Security=true;");
    
        public SqlConnection OpenConnection()
        {
            if (connec.State == ConnectionState.Closed)
            {
                connec.Open();   
            }
            return connec;
        }

        public SqlConnection CloseConnection()
        {
            if (connec.State == ConnectionState.Open)
                connec.Close();
            return connec;
        }
    }
}
