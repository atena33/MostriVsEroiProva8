using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MostriVsEroi.Modelli;

namespace MostriVsEroi.MockRepository
{
    public class EroeMockRepository
    {
        public static List<Eroe> FetchEroi(Utente utente)
        {
            List<Eroe> eroi = new List<Eroe>();
            eroi.Add(new Eroe("Attila", "Guerriero", new Arma("Ascia", 8)));
            eroi.Add(new Eroe("Merlino", "Mago", new Arma("Bastone Magico", 10)));

            return eroi;

        }
    }
}
