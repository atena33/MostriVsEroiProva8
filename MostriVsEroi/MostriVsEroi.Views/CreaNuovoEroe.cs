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
            CategoriaEroe categoria = CategoriaEroe.Guerriero;
            var puntiDanno = 0;
            Console.WriteLine("Inserisci il nome dell'eroe");
            var nome = Console.ReadLine();
            Console.WriteLine($"Inserisci la categoria dell'eroe fra Guerriero(1) o Mago (2)");
            var cat = int.Parse(Console.ReadLine());
            if (cat == 1)
            {
                categoria = CategoriaEroe.Guerriero;
            }
            else if (cat == 2)
            {
                categoria = CategoriaEroe.Mago;

            }

            Console.WriteLine("Scegli l'arma tra quelle disponibili inserendo il nome");
            Console.WriteLine($"{ArmaMockRepository.GetArmi(categoria)}");
            var nomeArma = Console.ReadLine();
            foreach (var item in ArmaMockRepository.GetArmi(categoria))
            {
                if (item.Nome == nomeArma)
                {
                    puntiDanno = item.PuntiDanno;

                }
            }
            Eroe newEroe = new Eroe(nome, categoria, new Arma(nomeArma, puntiDanno));
            EroeMockRepository.FetchEroi(utente).Add(newEroe);
            Console.WriteLine("Eroe inserito");
            Menu.MenuNonAdmin(utente);
            return newEroe;


        }
    }
}
