using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MostriVsEroi.Services;

namespace MostriVsEroi.View
{
    class GiocaView
    {
        internal static void Gioca(Utente utente)
        {
            SceltaEroe(utente);
            SceltaMostro(SceltaEroe(utente));
            Partita(SceltaEroe(utente), SceltaMostro(SceltaEroe(utente)));
            bool haVinto = Partita(SceltaEroe(utente), SceltaMostro(SceltaEroe(utente)));
            CalcoloPunteggioELivello(haVinto, utente );
            GiocareAncora(utente);
        }

        private static void GiocareAncora(Utente utente)
        {
            Console.WriteLine("Vuoi giocare ancora? Premi S se sì o qualsiasi altro carattere per uscire");
            char scelta = Console.ReadKey().KeyChar;
            switch (scelta)
            {
                case 'S':
                    Gioca(utente);
                    break;
                default:
                    return;
                    break;
            }
        }

        private static int CalcoloPunteggioELivello(bool haVinto, Utente utente)
        {
            
            Eroe eroe = SceltaEroe(utente);
            Mostro mostro = SceltaMostro(eroe);
            int punti =eroe.PuntiAccumulati;
            var livello = eroe.Livello.NumeroLivello;
            if (haVinto)
            {
                 punti += EroeServices.CalcoloPunti(mostro);
                
                int newLivello = eroe.getLivello(punti).NumeroLivello;

                if (newLivello > livello)
                {
                    Console.WriteLine($"Complimenti, il tuo nuovo livello è {newLivello}");
                    return punti = 0;
                }
            }
            return punti;
        }

        private static bool Partita(Eroe eroe, Mostro mostro)
        {
            bool haVinto = false;
            var mostroPuntiVita = mostro.Livello.PuntiVita;
            var eroePuntiVita = eroe.Livello.PuntiVita;
            do
            {
                eroe.EroeAttacca();
                
                mostroPuntiVita -= eroe.Arma.PuntiDanno;
                mostro.MostroAttacca();
                eroePuntiVita -= mostro.Arma.PuntiDanno;
            } while (mostroPuntiVita <=0 || eroePuntiVita <= 0 );
            if (mostroPuntiVita <= 0)
            {
                return haVinto = true;
            }
            return haVinto;
        }

        private static Mostro SceltaMostro(Eroe eroe)
        {
            var mostro = MostroServices.GetMostroRandom(eroe);
            Console.WriteLine($"Il tuo mostro è {mostro.NomeMostro} di tipo {mostro.CategoriaMostro} con arma {mostro.Arma}");
            return mostro;
        }

        private static Eroe SceltaEroe(Utente utente)
        {
            Console.WriteLine("Scegli il tuo eroe inserendo il suo nome");

            List<Eroe> eroi = EroeServices.GetEroi(utente);
            foreach (var eroe in eroi)
            {
                Console.WriteLine($"Id : {eroe.IdEroe} - Nome: {eroe.NomeEroe} - Categoria: {eroe.CategoriaEroe} - Arma: {eroe.Arma.Nome}- Punti danno dell'arma: {eroe.Arma.PuntiDanno} ");
                int scelta = int.Parse(Console.ReadLine());
                if (scelta == eroe.IdEroe)
                {
                    return eroe;
                }
            }
            if (eroi.Count == 0)
            {
                Console.WriteLine("Non hai ancora nessun eroe. Creane uno!");
            }
            return new Eroe();
        }
    }
}
