using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Views
{
    public static class MostraClassificaGlobaleView
    {
        public static void MostraClassifica()
        {
            var eroi = EroeServices.ClassificaGlobale();

            
                foreach (var eroe in eroi)
                {

                     Console.WriteLine($"Utente: {eroe.NomeEroe} Categoria: {eroe.CategoriaEroe} Livello: {eroe.Livello.NumeroLivello} Punti Accumulati: {eroe.PuntiAccumulati}");
                }
            
            
        }
    }
}
