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
            var eroe = SceltaEroe(utente);
            var mostro = SceltaMostro(eroe);
            bool partita = Partita(eroe, mostro);
            CalcoloPunteggioELivello(partita, utente, eroe, mostro );
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

        private static int CalcoloPunteggioELivello(bool haVinto, Utente utente, Eroe eroe, Mostro mostro)
        {
            
            
            int punti =eroe.PuntiAccumulati;
            int livello = eroe.Livello.NumeroLivello;
            if (haVinto)
            {
                 punti += EroeServices.CalcoloPunti(mostro);
                int puntiAccumulati = eroe.PuntiAccumulati;
                int newLivello = eroe.getLivello(punti).NumeroLivello;

                if (newLivello > livello)
                {
                    Console.WriteLine($"Complimenti, il tuo nuovo livello è {newLivello}");
                    return punti = 0;
                    
                }
                else
                {
                    puntiAccumulati += punti;
                    Console.WriteLine($"Hai fatto {punti} punti e hai accumulato {puntiAccumulati} punti. Il tuo livello è {livello}");

                    return puntiAccumulati;
                }
            }
            return punti;
        }

        private static bool Partita(Eroe eroe, Mostro mostro)
        {
            bool haVinto = false;
            int mostroPuntiVita = mostro.Livello.PuntiVita;
            int eroePuntiVita = eroe.Livello.PuntiVita;
            do
            {
                int eroePuntiDanno = eroe.EroeAttacca(eroe);
                
                mostroPuntiVita -= eroePuntiDanno;
                Console.WriteLine($"Hai attaccato:il mostro ha ancora {mostroPuntiVita} punti vita ");
                if (mostroPuntiVita <= 0)
                {
                    break;
                }
                mostro.MostroAttacca();
                eroePuntiVita -= mostro.Arma.PuntiDanno;
                Console.WriteLine($"Il mostro ha attaccato: hai ancora {eroePuntiVita} punti vita ");

            } while (mostroPuntiVita > 0 && eroePuntiVita > 0 );
            if (mostroPuntiVita <= 0)
            {
                Console.WriteLine("Hai vinto!");
                return haVinto = true;
            }
            else if (eroePuntiVita <= 0)
            {
                Console.WriteLine("Hai perso!");

                return haVinto = false;
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
            Console.WriteLine("Scegli il tuo eroe inserendo il suo id");
            
            
            List<Eroe> eroi = EroeServices.GetEroi(utente);
            foreach (Eroe eroe in eroi)
            {
                Console.WriteLine($"Id : {eroe.IdEroe} - Nome: {eroe.NomeEroe} - Categoria: {eroe.CategoriaEroe} - Arma: {eroe.Arma.Nome}- Punti danno dell'arma: {eroe.Arma.PuntiDanno} ");
                
            }
            int scelta = int.Parse(Console.ReadLine());
            Eroe result = eroi.Find(IdEroe => IdEroe.IdEroe == scelta);

            
            Console.WriteLine($"Eroe scelto: {result.NomeEroe}");
            return result;
            
            if (eroi.Count == 0)
            {
                Console.WriteLine("Non hai ancora nessun eroe. Creane uno!");
            }
            return new Eroe();
        }
    }
}
