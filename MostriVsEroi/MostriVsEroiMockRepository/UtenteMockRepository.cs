using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;

namespace MostriVsEroi.MockRepository
{
    public class UtenteMockRepository : IUtenteRepository
    {
        public Utente GetUser(Utente utente)
        {
            utente.IsAuthenticated = true;
            return utente;
        }

        public static List<Utente> FetchUtenti()
        {
            List<Utente> utenti = new List<Utente>();
            utenti.Add(new Utente("Mario", "1234"));
            utenti.Add(new Utente("Marco", "1234"));

            return utenti;

        }
    }
}
