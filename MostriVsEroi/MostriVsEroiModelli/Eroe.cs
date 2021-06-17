using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Modelli
{
    public class Eroe
    {
        public static int count = 1;
        public int IdEroe { get; set; }
        public string NomeEroe { get; set; }
        public string CategoriaEroe { get; set; }
        public Arma Arma { get; set; }
        public Livello Livello { get; set; } = new Livello(1);
        public int PuntiAccumulati { get; set; }


        public Eroe(string nomeEroe, string categoriaEroe, Arma arma)
        {
            IdEroe = count ++;
            NomeEroe = nomeEroe;
            CategoriaEroe = categoriaEroe;
            Arma = arma;
           
        }

        public Eroe(int idEroe, string nomeEroe, string categoriaEroe, Arma arma)
        {
            IdEroe = idEroe;
            NomeEroe = nomeEroe;
            CategoriaEroe = categoriaEroe;
            Arma = arma;

        }



        public int EroeAttacca(Eroe eroe)
        {

            return eroe.Arma.PuntiDanno;
        }

        public Livello getLivello(int puntiAccumulati)
        {
            var livello = new Livello();
            if (puntiAccumulati <  29)
            {
               return livello = new Livello(1);
            }
            if (puntiAccumulati > 29 && puntiAccumulati< 60)
            {
               return livello = new Livello(2);
            }
            if (puntiAccumulati > 59 && puntiAccumulati < 90)
            {
                return livello = new Livello(3);
            }
            if (puntiAccumulati > 89 && puntiAccumulati < 120)
            {
                return livello = new Livello(4);
            }
            if (puntiAccumulati >= 120)
            {
                return livello = new Livello(5);
            }

            return livello;
        }

        public Eroe()
        {

        }
    }


}

public enum CategoriaEroe
{
    Guerriero,
    Mago
}


