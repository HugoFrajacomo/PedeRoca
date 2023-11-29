using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
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
