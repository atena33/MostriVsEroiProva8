using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Views
{
    public static class CreaNuovoEroe
    {
        

        internal static Eroe CreaEroe(Utente utente)
        {
            string categoria = "";
            Console.WriteLine("Inserisci il nome dell'eroe");
            var nome = Console.ReadLine();
            Console.WriteLine($"Inserisci la categoria dell'eroe fra Guerriero(1) o Mago (2)");
            var cat = int.Parse(Console.ReadLine());
            if (cat == 1)
            {
                categoria = "Guerriero";
            }
            else if (cat == 2)
            {
                categoria = "Mago";

            }

            var armi = ArmaMockRepository.GetArmi(categoria);
            Console.WriteLine("Scegli l'arma tra quelle disponibili inserendo il nome");
            
            foreach (var item in armi)
            {
                Console.WriteLine($"{item.Nome}");

                
            }
            var scelta = Console.ReadLine();
            Arma result = armi.Find(NomeArma => NomeArma.Nome == scelta);

            Eroe newEroe = new Eroe(nome, categoria, new Arma(result.Nome, result.PuntiDanno));
            EroeMockRepository.FetchEroi(utente).Add(newEroe);
           
            Console.WriteLine("Eroe inserito");
            Menu.MenuNonAdmin(utente);
            return newEroe;


        }
    }
}
