using Controllers.Base;
using Controllers.DAL;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers {
    public class VendaController {

        private Contexto contexto = new Contexto();

        public void Adicionar(Venda entity) {
            contexto.Vendas.Add(entity);
            contexto.SaveChanges();
        }

        public void Atualizar(Venda entity) {
            contexto.Entry(entity).State =
                System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public Venda BuscarPorID(int id) {
            return contexto.Vendas.Find(id);
        }

        public void Excluir(int id) {
            Venda v = BuscarPorID(id);

            if (v != null) {
                // forma 1
                contexto.Vendas.Remove(v);

                // forma 2
                //contexto.Entry(a).State = System.Data.Entity.EntityState.Deleted;

                contexto.SaveChanges();
            }
        }

        /*public IList<Venda> ListarPorNome(string nome) {
            // LINQ
            //var VendasComNome = from a in contexto.Vendas
            //            where a.Nome.ToLower() == nome.ToLower()
            //            select a;

            //return VendasComNome.ToList();

            // LAMBDA
            return contexto.Vendas
                .Where(v => v.Cliente.Nome.ToLower() == nome.ToLower()).ToList();
        }*/

        public IList<Venda> ListarTodos() {
            return contexto.Vendas.ToList();
        }

    }
}
