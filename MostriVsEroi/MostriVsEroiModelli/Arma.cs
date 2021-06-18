namespace MostriVsEroi.Modelli
{
    public class Arma
    {
        public int IdArma { get; set; }
        public string Nome { get; set; }
        public int PuntiDanno { get; set; }
        public string CategoriaAppartenenza { get; set; }

        public Arma(string nome, int puntiDanno)
        {
            Nome = nome;
            PuntiDanno = puntiDanno;
        }
        public Arma()
        {

        }
        public Arma(int idArma, string nome, int puntiDanno, string categoriaAppartenenza)
        {
            IdArma = idArma;
            Nome = nome;
            PuntiDanno = puntiDanno;
            CategoriaAppartenenza = categoriaAppartenenza;

        }

        public Arma(int idArma)
        {
            IdArma = idArma;
        }
        
    }
}