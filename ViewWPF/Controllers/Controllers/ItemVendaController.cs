using Controllers.Base;
using Controllers.DAL;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers {
    public class ItemVendaVendaController : IBaseController<ItemVenda> {

        private Contexto contexto = new Contexto();

        public void Adicionar(Models.Models.ItemVenda entity) {
            contexto.ItemVendas.Add(entity);
            contexto.SaveChanges();
        }

        public void Atualizar(ItemVenda entity) {
            contexto.Entry(entity).State =
                System.Data.Entity.EntityState.Modified;
            
            contexto.SaveChanges();
        }

        public ItemVenda BuscarPorID(int id) {
            return contexto.ItemVendas.Find(id);
        }

        public void Excluir(int id) {
            ItemVenda i = BuscarPorID(id);

            if (i != null) {
                // forma 1
                contexto.ItemVendas.Remove(i);

                // forma 2
                //contexto.Entry(a).State = System.Data.Entity.EntityState.Deleted;

                contexto.SaveChanges();
            }
        }

        public IList<ItemVenda> ListarPorNome(string nome) {
            // LINQ
            //var ItemVendasComNome = from a in contexto.ItemVendas
            //            where a.Nome.ToLower() == nome.ToLower()
            //            select a;

            //return ItemVendasComNome.ToList();

            // LAMBDA
            return contexto.ItemVendas
                .Where(i => i.Nome.ToLower() == nome.ToLower()).ToList();
        }

        public IList<ItemVenda> ListarTodos() {
            return contexto.ItemVendas.ToList();
        }

    }
}
