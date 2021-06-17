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
                command.CommandText = "SELECT dbo.Eroe.IdUtente, dbo.Eroe.IdArma, dbo.Arma.Nome, dbo.Arma.PuntiDanno, dbo.Eroe.NomeEroe, dbo.Eroe.CategoriaEroe, dbo.Eroe.PuntiAccumulati FROM  dbo.Utente INNER JOIN dbo.Eroe ON dbo.Utente.IdUtente = dbo.Eroe.IdUtente INNER JOIN dbo.Arma ON dbo.Eroe.IdArma = dbo.Arma.IdArma WHERE Utente.IdUtente = @IdUtente";
                //command.CommandText = "FROM  dbo.Utente INNER JOIN dbo.Eroe ON dbo.Utente.IdUtente = dbo.Eroe.IdUtente";
                ////command.CommandText = "INNER JOIN dbo.Eroe ON dbo.Utente.IdUtente = dbo.Eroe.IdUtente";
                //command.CommandText = "INNER JOIN dbo.Arma ON dbo.Eroe.IdArma = dbo.Arma.IdArma WHERE Utente.IdUtente = @IdUtente";
                ////command.CommandText =  "WHERE Utente.IdUtente = @IdUtente";
                command.Parameters.AddWithValue("@IdUtente", utente.IdUtente);


                SqlDataReader reader = command.ExecuteReader();

                //SELECT dbo.Eroe.IdUtente, dbo.Eroe.IdArma, dbo.Arma.Nome, dbo.Arma.PuntiDanno, dbo.Eroe.NomeEroe, dbo.Eroe.CategoriaEroe, dbo.Eroe.PuntiAccumulati
                //FROM            dbo.Utente INNER JOIN
                //         dbo.Eroe ON dbo.Utente.IdUtente = dbo.Eroe.IdUtente INNER JOIN
                //         dbo.Arma ON dbo.Eroe.IdArma = dbo.Arma.IdArma
                //WHERE Utente.IdUtente = 2
                List<Eroe> eroi = new List<Eroe>();
                while (reader.Read())
                {
                    int idEroe = (int)reader["IdEroe"];
                    string nomeEroe = (string)reader["NomeEroe"];
                    CategoriaEroe categoriaEroe =(CategoriaEroe) reader["CategoriaEroe"];
                    string nomeArma = (string)reader["NomeArma"];
                    int puntiDanno = (int)reader["PuntiDanno"];

                    Eroe e = new Eroe(idEroe, nomeEroe, categoriaEroe, new Arma(nomeArma, puntiDanno) );
                    eroi.Add(e);
                }
                connection.Close();

                return eroi;
            }
        }
    }
}
