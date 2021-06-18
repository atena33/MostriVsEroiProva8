using Microsoft.Data.SqlClient;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public static class MostroDbRepository
    {
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = EroiVsMostriDb;" +
                                          "Integrated Security=true;";

        public static List<Mostro> FetchMostri()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Mostro.NomeMostro, dbo.Mostro.CategoriaMostro, dbo.Livello.NumeroLivello, dbo.Arma.Nome, dbo.Arma.PuntiDanno FROM dbo.Mostro INNER JOIN dbo.Livello ON dbo.Mostro.IdLivello = dbo.Livello.IdLivello INNER JOIN dbo.Arma ON dbo.Mostro.IdArma = dbo.Arma.IdArma";



                SqlDataReader reader = command.ExecuteReader();


                List<Mostro> mostri = new List<Mostro>();
                while (reader.Read())
                {
                    string nomeMostro = (string)reader["NomeMostro"];
                    string categoriaMostro = (string)reader["CategoriaMostro"];
                    int numeroLivello = (int)reader["NumeroLivello"];
                    string nomeArma = (string)reader["Nome"];
                    int puntiDanno = (int)reader["PuntiDanno"];

                    Mostro m = new Mostro(nomeMostro, categoriaMostro, new Arma(nomeArma, puntiDanno), new Livello(numeroLivello));
                    mostri.Add(m);
                }
                connection.Close();

                return mostri;
            }
        }

        public static void AddMostro(Mostro mostro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Mostro values(@NomeMostro, @CategoriaMostro, @IdArma, @IdLivello)";
                command.Parameters.AddWithValue("@NomeMostro", mostro.NomeMostro);
                command.Parameters.AddWithValue("@CategoriaMostro", mostro.CategoriaMostro);
                command.Parameters.AddWithValue("@IdArma", mostro.Arma.IdArma);
                command.Parameters.AddWithValue("@IdLivello", mostro.Livello.NumeroLivello);


                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
