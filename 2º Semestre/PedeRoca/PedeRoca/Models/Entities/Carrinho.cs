namespace PedeRoca.Models.Entities
{
    class Carrinho
    {
        public int Id_Carrinho { get; set; }
<<<<<<< HEAD

        public Pessoa pessoa { get; set; } = new Pessoa();
=======
        public decimal ValorTotal
        {
            get
            {
                // Calcula o ValorTotal somando os PrecoSubTotal de todos os itens na lista
                return Item.Sum(item => item.PrecoSubTotal);
            }
        }
>>>>>>> parent of b596196 (Carrinho de Compras)
        public List<ItemDoCarrinho> Item { get; set; } = new List<ItemDoCarrinho>();

        public Carrinho()
        {
        }
    }
}
