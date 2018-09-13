using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models {

    public partial class ItemVenda {
        public ItemVenda() {
            this.Produto = new HashSet<Produto>();
        }

        [Key]
        public int ItemVendaID { get; set; }
        public int VendaId { get; set; }

        public virtual Venda Venda { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
