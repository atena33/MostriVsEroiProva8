using MostriVsEroi.Modelli;
using System;

namespace MostriVsEroi.SchermataServices
{
    public static class UtenteSchermataServices
    {
        public static Utente GetUtente(string username, string password)
        {
            return new Utente(username, password);
        }
    }
}
