using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using MostriVsEroi.DbRepository;
 using System;
using System.Collections.Generic;
using MostriVsEroi.SchermataServices;

namespace MostriVsEroi.Services
{
    public static class UtenteServices
    {
        //static UtenteMockRepository umr = new UtenteMockRepository();
        static UtenteDbRepository umr = new UtenteDbRepository();
        public static  Utente VerifyAuthentication(Utente utente)
        {
            return umr.Accedi(utente);
        }

        public static List<Utente> FetchUtenti()
        {
            return UtenteDbRepository.FetchUtenti();
        }

        public static Utente AddUtente(Utente utente)
        {
           UtenteDbRepository.AddUtente(utente);

            return utente;
        }

        public static void UtenteIsAdmin(Utente utente)
        {
            UtenteDbRepository.UpdateIsAdminUtente(utente);
        }
    }
}
