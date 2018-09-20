using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public partial class Produto {

        [Key]
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }

        public virtual ItemVenda ItemVenda { get; set; }
    }
}