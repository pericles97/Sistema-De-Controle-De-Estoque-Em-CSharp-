//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirst {
    using System;
    using System.Collections.Generic;

    public partial class Produto {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }

        public virtual ItemVenda ItemVenda { get; set; }
    }
}
