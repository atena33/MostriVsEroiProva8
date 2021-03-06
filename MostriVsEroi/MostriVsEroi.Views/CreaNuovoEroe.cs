using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using MostriVsEroi.Services;
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

            //var armi = ArmaMockRepository.GetArmi(categoria);
            var armi = ArmaServices.GetArmi();
            Console.WriteLine("Scegli l'arma tra quelle disponibili inserendo l'Id");
            
            foreach (var item in armi)
            {
                if (categoria == item.CategoriaAppartenenza)
                {
                    Console.WriteLine($"{item.IdArma}--{item.Nome}");
                }
            }
            var scelta =int.Parse(Console.ReadLine());
            Arma result = armi.Find(IdArma => IdArma.IdArma == scelta);

            Eroe newEroe = new Eroe(nome, categoria, new Arma(result.IdArma), new Utente(utente.IdUtente));
            //EroeMockRepository.FetchEroi(utente).Add(newEroe);
            EroeServices.AddEroe(newEroe, utente);
           
            Console.WriteLine("Eroe inserito");
            Menu.MenuNonAdmin(utente);
            return newEroe;


        }
    }
}
