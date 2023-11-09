using System.ComponentModel;

namespace PedeRoca.Models.Entities
{
    public class ItemDoCarrinho
    {
        [DisplayName("ID")]
        public int Id_itemCarrinho { get; set; }
        public Produto Produto { get; set; }  = new Produto();
        [DisplayName("QTD")]
        public int Quantidade { get; set; }

        [DisplayName("Valor")]
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
            Id_itemCarrinho = 0;
            Quantidade = 0;
            Produto = new Produto();
        }
    }
}
