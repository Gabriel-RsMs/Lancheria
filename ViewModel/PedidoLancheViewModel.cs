using Lancheria.Models;

namespace Lancheria.ViewModel
{
    public class PedidoLancheViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> Detalhe { get; set;}
    }
}
