using Microsoft.Data.SqlClient;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public static class ArmaDbRepository
    {
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = EroiVsMostriDb;" +
                                         "Integrated Security=true;";

        public static List<Arma> FetchArmi()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * from dbo.Arma ";
                //where CategoriaAppartenenza = 'Guerriero' or CategoriaAppartenenza = 'Mago'

                SqlDataReader reader = command.ExecuteReader();

                
                List<Arma> armi = new List<Arma>();
                while (reader.Read())
                {
                    int idArma = (int)reader["IdArma"];
                    string nome = (string)reader["Nome"];
                    int puntiDanno = (int)reader["PuntiDanno"];
                    string categoriaAppartenenza = (string)reader["CategoriaAppartenenza"];


                    Arma a = new Arma(idArma, nome, puntiDanno, categoriaAppartenenza);
                    armi.Add(a);
                }
                connection.Close();

                return armi;
            }
        }
    }
}
