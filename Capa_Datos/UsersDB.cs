using Capa_Enitdad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class UsersDB:InterfaceCRU<Users>
    {
        private Connection conexion = new Connection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        List<Users> listUsers = new List<Users>();
        public List<Users> show()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "showUsers";
            comando.CommandType = CommandType.StoredProcedure;
            read = comando.ExecuteReader();
            table.Load(read);
            conexion.CloseConnection();

           
            foreach (DataRow row in table.Rows)
            {
                var user = new Users();
                user.id  =Convert.ToInt32(row["id"]);
                user.email = row["email"].ToString();
                user._password = row["_password"].ToString();
                listUsers.Add(user);
            }
            
            return listUsers;
        }

        public void Insert(Users user)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "insertUsers";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@email", user.email);
            comando.Parameters.AddWithValue("@_password", user._password);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CloseConnection();
        }

        public void Update(Users user)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "editUsers";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@email", user.email);
            comando.Parameters.AddWithValue("@_password", user._password);
            comando.Parameters.AddWithValue("@id", user.id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CloseConnection();
        }

        public Users Edit(int? id)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "editUsersId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            read = comando.ExecuteReader();
            table.Load(read);
            comando.Parameters.Clear();
            conexion.CloseConnection();

            Users user = new Users();
            foreach (DataRow row in table.Rows)
            {
                user.id = Convert.ToInt32(row["id"]);
                user.email = row["email"].ToString();
                user._password = row["_password"].ToString();
            }
            return user;
        }

        public Users compare(string email, string _password)
        {
            UsersDB db = new UsersDB();
            List<Users> list1 = db.show();
            var user = list1.FirstOrDefault(a => a.email == email && a._password == _password);
            return user;
        }
    }
}
