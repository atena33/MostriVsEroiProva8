using Microsoft.Data.SqlClient;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public class UtenteDbRepository
    {

        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = EroiVsMostriDb;" +
                                          "Integrated Security=true;";

        public Utente Accedi(Utente utente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Utente where Username = @Username AND Password = @Password";
                command.Parameters.AddWithValue("@Username", utente.Username);
                command.Parameters.AddWithValue("@Password", utente.Password);


                SqlDataReader reader = command.ExecuteReader();

                Utente u = new Utente();
                while (reader.Read())
                {
                    int idUtente = (int)reader["IdUtente"];
                    string username1 = (string)reader["Username"];
                    string password1 = (string)reader["Password"];
                    

                     u = new Utente(idUtente, username1, password1, true);
                    
                }
                connection.Close();

                return u;
            }
        }

        public static List<Utente> FetchUtenti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Utente";
                


                SqlDataReader reader = command.ExecuteReader();

                List<Utente> utenti = new List<Utente>();
                while (reader.Read())
                {
                    int idUtente = (int)reader["IdUtente"];
                    string username = (string)reader["Username"];
                    string password = (string)reader["Password"];


                  Utente  u = new Utente(idUtente, username, password);
                    utenti.Add(u);
                }
                connection.Close();

                return utenti;
            }
        }

        public static void AddUtente(Utente utente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Utente values(@Username, @Password, @IsAuthenticated, @IsAdmin)";
                command.Parameters.AddWithValue("@Username", utente.Username);
                command.Parameters.AddWithValue("@Password", utente.Password);
                command.Parameters.AddWithValue("@IsAuthenticated", true);
                command.Parameters.AddWithValue("@IsAdmin", false);



                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
