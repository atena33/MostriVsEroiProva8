using MostriVsEroi.DbRepository;
using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public static class MostroServices
    {
        public static Mostro GetMostroRandom(Eroe eroe)
        {
            var mostro = new Mostro();
            do
            {
                //var mostri = MostroMockRepository.FetchMostri();
                var mostri = MostroDbRepository.FetchMostri();

                var random = new Random();
                int index = random.Next(mostri.Count);
                mostro = mostri[index];
            } while (mostro.Livello.NumeroLivello > eroe.Livello.NumeroLivello);

            return mostro;
        }

        public static void AddMostro(Mostro mostro)
        {
            MostroDbRepository.AddMostro(mostro);
        }
    }
}
