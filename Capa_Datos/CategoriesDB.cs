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
    public class CategoriesDB:InterfaceCRU<Categories>,InterfaceDelete
    {
        private Connection connection = new Connection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        List<Categories> listCategories = new List<Categories>();
        public List<Categories> show()
        {
            comando.Connection = connection.OpenConnection();
            comando.CommandText = "showCategories";
            comando.CommandType = CommandType.StoredProcedure;
            read = comando.ExecuteReader();
            table.Load(read);
            connection.CloseConnection();

            foreach (DataRow row in table.Rows)
            {
                var cate = new Categories();
                cate.categoryId = Convert.ToInt32(row["categoryId"]);
                cate.categoryName = row["categoryName"].ToString();
                cate.categoryDescription = row["categoryDescription"].ToString();
                listCategories.Add(cate);   
            }

            return listCategories;
        }

        public void Insert(Categories categories)
        {
            comando.Connection = connection.OpenConnection();
            comando.CommandText = "insertCategory";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@categoryName", categories.categoryName);
            comando.Parameters.AddWithValue("@categoryDescription", categories.categoryDescription);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            connection.CloseConnection();
        }

        public void Update(Categories categories)
        {
            comando.Connection = connection.OpenConnection();
            comando.CommandText = "editCategory";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@categoryName", categories.categoryName);
            comando.Parameters.AddWithValue("@categoryDescription", categories.categoryDescription);
            comando.Parameters.AddWithValue("@id", categories.categoryId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            connection.CloseConnection();
        }

        public void Delete(int? id)
        {
            comando.Connection = connection.OpenConnection();
            comando.CommandText = "deleteCategory";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            connection.CloseConnection();
        }

        public Categories Edit(int? id)
        {
            comando.Connection = connection.OpenConnection();
            comando.CommandText = "editCategoriesId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            read = comando.ExecuteReader();
            table.Load(read);
            comando.Parameters.Clear();
            connection.CloseConnection();

            Categories cate = new Categories();
            foreach (DataRow row in table.Rows)
            {
                cate.categoryId = Convert.ToInt32(row["categoryId"]);
                cate.categoryName = row["categoryName"].ToString();
                cate.categoryDescription = row["categoryDescription"].ToString();
            }
            return cate;
        }     
    }
}
