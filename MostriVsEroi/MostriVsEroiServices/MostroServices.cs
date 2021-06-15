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
            
            var mostri = MostroMockRepository.FetchMostri();
            var random = new Random();
            int index = random.Next(mostri.Count);
            var mostro = mostri[index];
            if (mostro.Livello.NumeroLivello <= eroe.Livello.NumeroLivello)
            {
                return mostro;
            }
            else
            {
                Console.WriteLine("Non esiste un mostro del tuo livello: crealo!");
            }
            return new Mostro();
        }
    }
}
