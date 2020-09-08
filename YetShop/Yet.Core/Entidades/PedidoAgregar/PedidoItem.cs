namespace Yet.Core.Entidades.PedidoAgregar
{
    public class PedidoItem : EntidadeBase
    {
        #region Campoos
        public CatalogoItemPedido ItemPedido { get; private set; }
        public decimal PrecoUnit { get; private set; }
        public int Unidades { get; private set; }
        #endregion

        #region Ctor
        public PedidoItem() { }

        public PedidoItem(CatalogoItemPedido itemPedido, decimal precoUnit, int units)
        {
            ItemPedido = itemPedido;
            PrecoUnit = precoUnit;
            Unidades = units;
        }
        #endregion
    }
}
