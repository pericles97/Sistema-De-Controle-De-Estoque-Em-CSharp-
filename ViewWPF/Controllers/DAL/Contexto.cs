using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DAL {
    class Contexto : DbContext {
        public Contexto() : base("strConn") {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<ItemVenda> ItemVendas { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Venda> Vendas { get; set; }
    }
}
