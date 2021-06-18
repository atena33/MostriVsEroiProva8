using Microsoft.Data.SqlClient;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public static class EroeDbRepository
    {
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = EroiVsMostriDb;" +
                                          "Integrated Security=true;";
        public static List<Eroe> FetchEroi(Utente utente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Eroe.IdUtente, dbo.Eroe.IdArma, dbo.Arma.Nome, dbo.Arma.PuntiDanno, dbo.Eroe.NomeEroe, dbo.Eroe.CategoriaEroe, dbo.Eroe.PuntiAccumulati, dbo.Eroe.IdEroe FROM  dbo.Utente INNER JOIN dbo.Eroe ON dbo.Utente.IdUtente = dbo.Eroe.IdUtente INNER JOIN dbo.Arma ON dbo.Eroe.IdArma = dbo.Arma.IdArma WHERE Utente.IdUtente = @IdUtente";
                
                command.Parameters.AddWithValue("@IdUtente", utente.IdUtente);


                SqlDataReader reader = command.ExecuteReader();

                
                List<Eroe> eroi = new List<Eroe>();
                while (reader.Read())
                {
                    int idEroe = (int)reader["IdEroe"];
                    string nomeEroe = (string)reader["NomeEroe"];
                    string categoriaEroe =(string) reader["CategoriaEroe"];
                    string nomeArma = (string)reader["Nome"];
                    int puntiDanno = (int)reader["PuntiDanno"];

                    Eroe e = new Eroe(idEroe, nomeEroe, categoriaEroe, new Arma(nomeArma, puntiDanno) );
                    eroi.Add(e);
                }
                connection.Close();

                return eroi;
            }
        }

        public static void AddEroe(Eroe eroe, Utente utente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Eroe values(@NomeEroe, @CategoriaEroe, @PuntiAccumulati,  @IdArma, @IdLivello, @IdUtente)";
                command.Parameters.AddWithValue("@NomeEroe", eroe.NomeEroe);
                command.Parameters.AddWithValue("@CategoriaEroe", eroe.CategoriaEroe);
                command.Parameters.AddWithValue("@PuntiAccumulati", 0);
                command.Parameters.AddWithValue("@IdArma", eroe.Arma.IdArma);
                command.Parameters.AddWithValue("@IdLivello", 1);
                command.Parameters.AddWithValue("@IdUtente", utente.IdUtente);


                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void DeleteEroe(Eroe eroe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete dbo.Eroe where IdEroe = @IdEroe";
                command.Parameters.AddWithValue("@IdEroe", eroe.IdEroe);



                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        

        public static Eroe GetEroeById(Eroe eroe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.Eroe WHERE IdEroe = @IdEroe";

                command.Parameters.AddWithValue("@IdEroe", eroe.IdEroe);


                SqlDataReader reader = command.ExecuteReader();

                Eroe e = new Eroe();
               
                while (reader.Read())
                {
                    int idEroe = (int)reader["IdEroe"];
                    string nomeEroe = (string)reader["NomeEroe"];
                    string categoriaEroe = (string)reader["CategoriaEroe"];
                    int puntiAccumulati = (int)reader["PuntiAccumulati"];
                    int idLivello = (int)reader["IdLivello"];



                     e = new Eroe(idEroe, nomeEroe, categoriaEroe, puntiAccumulati, new Livello(idLivello));
                    
                }
                connection.Close();

                return e;
            }
        }

        public static void UpdateEroe(Eroe eroe, int punti)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update dbo.Eroe set PuntiAccumulati = @PuntiAccumulati where IdEroe = @IdEroe";
                command.Parameters.AddWithValue("@PuntiAccumulati", punti);
                command.Parameters.AddWithValue("@IdEroe", eroe.IdEroe);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void UpdateLivelloEroe(Eroe eroe, int newLivello)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update dbo.Eroe set IdLivello = @Livello, PuntiAccumulati = @PuntiAccumulati where IdEroe = @IdEroe";
                command.Parameters.AddWithValue("@Livello", newLivello);
                command.Parameters.AddWithValue("@PuntiAccumulati", 0);
                command.Parameters.AddWithValue("@IdEroe", eroe.IdEroe);


                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        //select* from dbo.Eroe ORDER by IdLivello  dESC

        public static List<Eroe> ClassificaGlobale()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT TOP 10 dbo.Eroe.NomeEroe, dbo.Eroe.CategoriaEroe, dbo.Eroe.PuntiAccumulati, dbo.Utente.Username, dbo.Eroe.IdLivello FROM dbo.Eroe INNER JOIN dbo.Utente ON dbo.Eroe.IdUtente = dbo.Utente.IdUtente ORDER by IdLivello desc";



                SqlDataReader reader = command.ExecuteReader();


                List<Eroe> eroi = new List<Eroe>();
                while (reader.Read())
                {
                    int idLivello = (int)reader["IdLivello"];
                    string nomeUtente = (string)reader["Username"];
                    string categoriaEroe = (string)reader["CategoriaEroe"];
                    int puntiAccumulati = (int)reader["PuntiAccumulati"];

                    Eroe e = new Eroe(nomeUtente, categoriaEroe, puntiAccumulati, new Livello(idLivello));
                    eroi.Add(e);
                }
                connection.Close();

                return eroi;
            }
        }
    }
}
