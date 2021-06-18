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
    public static class EroeServices
    {
        static EroeMockRepository emr = new EroeMockRepository();

        public static List<Eroe> GetEroi(Utente utente)
        {
            return EroeDbRepository.FetchEroi(utente);
        }

        public static int CalcoloPunti(Mostro mostro)
        {
           var calcoloPunti= mostro.Livello.NumeroLivello * 10;
            return calcoloPunti;
        }

        public static void AddEroe(Eroe eroe, Utente utente)
        {
             EroeDbRepository.AddEroe(eroe, utente);
        }

        public static void EliminaEroe(Eroe eroe)
        {
            EroeDbRepository.DeleteEroe(eroe);
        }

        public static void UpdateEroe(Eroe eroe, int punti)
        {
            EroeDbRepository.UpdateEroe(eroe, punti);
        }

        public static Eroe GetEroeById(Eroe eroe)
        {
            return EroeDbRepository.GetEroeById(eroe);
        }

        public static void UpdateEroeLivello(Eroe eroe, int newLivello)
        {
            EroeDbRepository.UpdateLivelloEroe(eroe, newLivello);
        }

        public static List<Eroe> ClassificaGlobale()
        {
            return EroeDbRepository.ClassificaGlobale();
        }
    }
}
