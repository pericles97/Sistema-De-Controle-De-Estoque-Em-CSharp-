//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemVenda
    {
        public ItemVenda()
        {
            this.Produto = new HashSet<Produto>();
        }
    
        public int Id { get; set; }
        public int VendaId { get; set; }
    
        public virtual Venda Venda { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
