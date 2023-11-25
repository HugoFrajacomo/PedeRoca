namespace PedeRoca.Models.Entities
{
    class Carrinho
    {
        public int Id_Carrinho { get; set; }
        public decimal ValorTotal
        {
            get
            {
                // Calcula o ValorTotal somando os PrecoSubTotal de todos os itens na lista
                return Item.Sum(item => item.PrecoSubTotal);
            }
        }
        public List<ItemDoCarrinho> Item { get; set; } = new List<ItemDoCarrinho>();

        public Carrinho()
        {
        }
    }
}
