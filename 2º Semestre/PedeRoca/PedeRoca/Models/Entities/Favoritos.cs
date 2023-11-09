namespace PedeRoca.Models.Entities
{
    public class Favoritos
    {
        public int Id_favorito { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public Favoritos() 
        { 
            Id_favorito = 0;
        }

    }
}
    