namespace MostriVsEroi.Modelli
{
    public class Arma
    {
        public string Nome { get; set; }
        public int PuntiDanno { get; set; }

        public Arma(string nome, int puntiDanno)
        {
            Nome = nome;
            PuntiDanno = puntiDanno;
        }

        
    }
}