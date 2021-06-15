using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public static class EroeServices
    {
        static EroeMockRepository emr = new EroeMockRepository();

        public static List<Eroe> GetEroi(Utente utente)
        {
            return EroeMockRepository.FetchEroi(utente);
        }

        public static int CalcoloPunti(Mostro mostro)
        {
           var calcoloPunti= mostro.Livello.NumeroLivello * 10;
            return calcoloPunti;
        }
    }
}
