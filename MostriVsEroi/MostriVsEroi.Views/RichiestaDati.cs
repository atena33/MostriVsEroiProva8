using MostriVsEroi.Modelli;
using MostriVsEroi.SchermataServices;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.View
{
    class RichiestaDati
    {
        internal static Utente InserisciUsernamePassword()
        {
            Console.WriteLine("Inserisci il tuo username");
            string username = Console.ReadLine();

            Console.WriteLine("Inserisci la password");
            string password = Console.ReadLine();

            return UtenteSchermataServices.GetUtente(username, password);
        }

        public static Utente RegistraUtente()
        {
            //var utenti = UtenteMockRepository.FetchUtenti();
            var utenti = UtenteServices.FetchUtenti();
            Console.WriteLine("Inserisci username");
            var username = Console.ReadLine();
            foreach (var utente in utenti)
            {
                if (username == utente.Username)
                {
                    do
                    {
                        Console.WriteLine("Username già in uso. Scegline un altro");
                        Console.WriteLine("Inserisci username");
                        username = Console.ReadLine();
                    } while (username == utente.Username);
                }
            }
            Console.WriteLine("Inserisci la password");
            var password = Console.ReadLine();

;

            return UtenteSchermataServices.AddUtente(username, password);
        }
    }
}
