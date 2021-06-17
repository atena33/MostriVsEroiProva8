using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.MockRepository
{
    public static class ArmaMockRepository
    {
        public static List <Arma> GetArmi(string categoriaEroe)
        {
            Arma a1 = new Arma("Alabarda", 15);
            Arma a2 = new Arma("Ascia", 8);
            Arma a3 = new Arma("Mazza", 5);
            Arma a4 = new Arma("Spada", 10);
            Arma a5 = new Arma("Spadone", 15);

            Arma a6 = new Arma("Arco e frecce", 8);
            Arma a7 = new Arma("Bacchetta", 5);
            Arma a8 = new Arma("Bastone Magico", 10);
            Arma a9 = new Arma("Onda d'urto", 15);
            Arma a10 = new Arma("Pugnale", 3);


            List<Arma> armi = new List<Arma>();
            if (categoriaEroe == "Guerriero")
            {
                armi.Add(a1);
                armi.Add(a2);
                armi.Add(a3);
                armi.Add(a4);
                armi.Add(a5);

                return armi;
            }
            if (categoriaEroe == "Mago")
            {
                armi.Add(a6);
                armi.Add(a7);
                armi.Add(a8);
                armi.Add(a9);
                armi.Add(a10);

                return armi;
            }

            return new List<Arma>();
        }
    }
}
