namespace PedeRoca.Models.Entities
{
    class Carrinho
    {
        public int Id_Carrinho { get; set; }
        public List<ItemDoCarrinho> MyProperty { get; set; } = new List<ItemDoCarrinho>();
    }
}
