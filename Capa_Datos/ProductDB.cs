using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Enitdad;

namespace Capa_Datos
{
    public class ProductDB:InterfaceCRU<Product>,InterfaceDelete
    {
        private Connection conexion = new Connection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        List<Product> listProduct = new List<Product>();
        public List<Product> show()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "showProduct";
            comando.CommandType = CommandType.StoredProcedure;
            read = comando.ExecuteReader();
            table.Load(read);
            conexion.CloseConnection();


            foreach (DataRow row in table.Rows)
            {
                var prod = new Product();
                prod.productId = Convert.ToInt32(row["productId"]);
                prod.productName = row["productName"].ToString();
                prod.productPrice = Convert.ToInt32(row["productPrice"]);
                prod.categoryId = Convert.ToInt32(row["categoryId"]);

                listProduct.Add(prod);
            }

            return listProduct;
        }

        public void Insert(Product product)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "insertProduct";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@productName", product.productName);
            comando.Parameters.AddWithValue("@productPrice", product.productPrice);
            comando.Parameters.AddWithValue("@categoryId", product.categoryId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CloseConnection();
        }

        public void Update(Product product)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "editProduct";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@productName", product.productName);
            comando.Parameters.AddWithValue("@productPrice", product.productPrice);
            comando.Parameters.AddWithValue("@categoryId", product.categoryId);
            comando.Parameters.AddWithValue("@id", product.productId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CloseConnection();
        }  

        public Product Edit(int? id)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "editProductId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            read = comando.ExecuteReader();
            table.Load(read);
            comando.Parameters.Clear();
            conexion.CloseConnection();

            Product prod = new Product();
            foreach (DataRow row in table.Rows)
            {
                prod.productId = Convert.ToInt32(row["productId"]);
                prod.productName = row["productName"].ToString();
                prod.productPrice = Convert.ToInt32(row["productPrice"]);
                prod.categoryId = Convert.ToInt32(row["categoryId"]);
            }
            return prod;
        }

        public void Delete(int? id)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "deleteProduct";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CloseConnection();
        }
    }
}
