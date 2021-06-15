using MostriVsEroi.MockRepository;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Views
{
    class EliminaEroeView
    {
        internal static List<Eroe> EliminaEroe(Utente utente)
        {
           var eroi = EroeMockRepository.FetchEroi(utente);

            Console.WriteLine("Scegli l'id dell'eroe da eliminare");
            foreach (var eroe in eroi)
            {
                Console.WriteLine($"Id: {eroe.IdEroe} - Nome: {eroe.NomeEroe} - Categoria: {eroe.CategoriaEroe}");
                var id = int.Parse(Console.ReadLine());

                if (eroe.IdEroe == id)
                {
                    eroi.Remove(eroe);
                    Console.WriteLine($"L'eroe {eroe.NomeEroe} è stato eliminato");
                    return eroi;
                } 
            }
            return eroi;
        }
    }
}
