using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models {
    public partial class Cliente {
        public Cliente() {
            this.Venda = new HashSet<Venda>();
        }

        [Key]
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
