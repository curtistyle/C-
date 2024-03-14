using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FundamentsOfDB.Models
{
    public class CervezaDB
    {
        public string ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FundamentosDB";


        public string query = "SELECT nombre, marca, alchool, cantidad FROM cerveza";

        


        public List<Cerveza> Conectar()
        {
            List<Cerveza> cervezas = new List<Cerveza>();
            using (SqlConnection connection = new SqlConnection(ConnectionString)){
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();





                while (reader.Read())
                {
                    string Nombre = reader.GetString(0);
                    string Marca = reader.GetString(1);
                    int Alchool = reader.GetInt32(2);
                    int Cantidad = reader.GetInt32(3);
                    cervezas.Add(new Cerveza(Nombre, Marca, Alchool, Cantidad));
                
                }

                connection.Close();

            }
            return cervezas;
        }
    }
}