using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models {
    public partial class Venda {
        public Venda() {
            this.ItemVenda = new HashSet<ItemVenda>();
        }

        [Key]
        public int VendaID { get; set; }
        //public int ClienteId { get; set; }
        public string Cpf { get; set; }
        public string Codigo { get; set; }
        public string Qtd { get; set; }
        public string TotalVenda { get; set; }

        //public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemVenda> ItemVenda { get; set; }
    }
}
