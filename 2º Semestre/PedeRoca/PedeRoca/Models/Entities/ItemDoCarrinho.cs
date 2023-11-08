namespace PedeRoca.Models.Entities
{
    class ItemDoCarrinho
    {
        public int Id_Carrinho { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }

        public decimal PrecoSubTotal
        {
            get
            {
                if (Produto != null)
                {
                    return Quantidade * Produto.PrecoUnitario;
                }
                else
                {
                    return 0;
                }
            }
        }

        public ItemDoCarrinho()
        {
            Id_Carrinho = 0;
            Quantidade = 0;
            Produto = new Produto();
        }
    }
}
