using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Modelli
{
    public class Livello
    {
        public int NumeroLivello { get; set; }
        public int PuntiVita { get; set; }

        public Livello(int numeroLivello)
        {
            NumeroLivello = numeroLivello;
            PuntiVita = GetPuntiVita(numeroLivello);
        }

        public Livello()
        {

        }

        public int GetPuntiVita(int numeroLivello)
        {
            int puntiVita = 0;
            switch (numeroLivello)
            {
                case 1:
                    return puntiVita = 20;
                   
                case 2:
                    return puntiVita = 40;

                case 3:
                    return puntiVita = 60;
                case 4:
                    return puntiVita = 80;
                case 5:
                    return puntiVita = 100;

                default:

                    return puntiVita;
                   
            }
        }
    }
}
