using MostriVsEroi.DbRepository;
using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using MostriVsEroi.Services;
using MostriVsEroi.View;
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
            Utente u = RichiestaDati.RegistraUtente();
            UtenteServices.AddUtente(u);
            Console.WriteLine("Ti sei registrato con successo");
            Menu.MenuNonAdmin(u);

            return u;
        }
    }
}
