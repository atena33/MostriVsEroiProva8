using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Views
{
    public static class RegistratiView
    {
        public static Utente RegistraUtente()
        {
            var utenti = UtenteMockRepository.FetchUtenti();
            Console.WriteLine("Inserisci username");
            var username = Console.ReadLine();
            foreach (var utente in utenti)
            {
                if (username == utente.Username)
                {
                    Console.WriteLine("Username già in uso. Scegline un altro");
                }
            }
            Console.WriteLine("Inserisci la password");
            var password = Console.ReadLine();

            Utente u = new Utente(username, password);
            utenti.Add(u);
            Console.WriteLine("Ti sei registrato con successo");
            Menu.MenuNonAdmin(u);

            return u;
        }
    }
}
