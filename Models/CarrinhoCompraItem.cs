using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lancheria.Models
{
    [Table("CarrinhoCompraItems")]
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemID { get; set; }
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
