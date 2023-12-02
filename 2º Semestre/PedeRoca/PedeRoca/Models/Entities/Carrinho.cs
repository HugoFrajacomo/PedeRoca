namespace PedeRoca.Models.Entities
{
    public class Carrinho
    {
        public int Id_Carrinho { get; set; }
        public decimal ValorTotal
        {
            get
            {
                return Item.Sum(item => item.PrecoSubTotal);
            }
            set
            {

            }
        }
        public Pessoa pessoa { get; set; } = new Pessoa();
        public List<ItemDoCarrinho> Item { get; set; } = new List<ItemDoCarrinho>();

        public Carrinho()
        {
        }
    }
}
