using MostriVsEroi.Modelli;
using MostriVsEroi.Services;
using MostriVsEroi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.View
{
    static class AccediView
    {
        public static void Accedi()
        {
            Utente utente = RichiestaDati.InserisciUsernamePassword();
            utente = UtenteServices.VerifyAuthentication(utente);
            if (utente.IsAuthenticated && utente.IsAdmin)
            {
                Menu.MenuAdmin(utente);
            }
            else if (utente.IsAuthenticated && !utente.IsAdmin)
            {
                Menu.MenuNonAdmin(utente);
            }
            else
            {
                Console.WriteLine("Devi prima registrarti");
            }
        }
    }
}
