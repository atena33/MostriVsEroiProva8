using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Modelli
{
    public class Mostro
    {
        int count = 0;
        public int IdMostro { get; set; }
        public string NomeMostro { get; set; }
        public string CategoriaMostro { get; set; }
        public Arma Arma { get; set; }
        public Livello Livello { get; set; }

        public Mostro(string nomeMostro, string categoriaMostro, Arma arma, Livello livello)
        {
            IdMostro = count++;
            NomeMostro = nomeMostro;
            CategoriaMostro = categoriaMostro;
            Arma = arma;
            Livello = livello;
        }

        public Mostro()
        {

        }

        public int MostroAttacca()
        {

            var armaPuntiDanno = Arma.PuntiDanno;
            return armaPuntiDanno;
        }
    }
}
