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
    
    public partial class Venda
    {
        public Venda()
        {
            this.ItemVenda = new HashSet<ItemVenda>();
        }
    
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string TotalVenda { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemVenda> ItemVenda { get; set; }
    }
}
