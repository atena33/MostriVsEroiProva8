using MostriVsEroi.Modelli;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Views
{
    public static class CreaNuovoMostroView
    {
        internal static Mostro CreaMostro(Utente utente)
        {
            string categoria = "";
            Console.WriteLine("Inserisci il nome del mostro");
            var nome = Console.ReadLine();
            Console.WriteLine($"Inserisci la categoria dell'eroe fra Cultista(1) , Orco (2), o Signore del Male (3)");
            var cat = int.Parse(Console.ReadLine());
            if (cat == 1)
            {
                categoria = "Cultista";
            }
            else if (cat == 2)
            {
                categoria = "Orco";

            }
            else if (cat == 3)
            {
                categoria = "Signore del male";

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
            var scelta = int.Parse(Console.ReadLine());
            Arma result = armi.Find(IdArma => IdArma.IdArma == scelta);
            Console.WriteLine("Scegli un livello da 1 a 5");
            var scelta2 = int.Parse(Console.ReadLine());

            Mostro newMostro = new Mostro(nome, categoria, new Arma(result.IdArma), new Livello(scelta2));
            MostroServices.AddMostro(newMostro);

            Console.WriteLine("Mostro inserito");
            Menu.MenuAdmin(utente);
            return newMostro;


        }
    }
}

