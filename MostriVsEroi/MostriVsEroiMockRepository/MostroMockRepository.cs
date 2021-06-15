using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.MockRepository
{
    public static class MostroMockRepository
    {
        public static List<Mostro> FetchMostri()
        {
            List<Mostro> mostri = new List<Mostro>();
            mostri.Add(new Mostro("Hulk", "Orco", new Arma("Arco", 7), 1));
            mostri.Add(new Mostro("Lucifero", "Signore del male", new Arma("Divinazione", 15), 2));

            return mostri;

        }
    }
}
