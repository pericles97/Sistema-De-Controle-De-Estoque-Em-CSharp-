using Controllers.Base;
using Controllers.DAL;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers {
    public class ProdutoController : IBaseController<Produto> {

        private Contexto contexto = new Contexto();

        public void Adicionar(Produto entity) {
            contexto.Produtos.Add(entity);
            contexto.SaveChanges();
        }

        public void Atualizar(Produto entity) {
            contexto.Entry(entity).State =
                System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public Produto BuscarPorID(int id) {
            return contexto.Produtos.Find(id);

        }

        public Produto BuscarPorCOD(string cod) {
            return contexto.Produtos.Find(cod);
        }

        public void Excluir(int id) {
            Produto p = BuscarPorID(id);

            if (p != null) {
                // forma 1
                contexto.Produtos.Remove(p);

                // forma 2
                //contexto.Entry(a).State = System.Data.Entity.EntityState.Deleted;

                contexto.SaveChanges();
            }
        }

        public IList<Produto> ListarPorCod(string cod) {
            // LINQ
            //var ClientesComNome = from a in contexto.Clientes
            //            where a.Nome.ToLower() == nome.ToLower()
            //            select a;

            //return ClientesComNome.ToList();

            // LAMBDA
            return contexto.Produtos
                .Where(p => p.Codigo.ToLower() == cod.ToLower()).ToList();
        }

        public IList<Produto> ListarPorNome(string nome) {
            // LINQ
            //var ProdutosComNome = from a in contexto.Produtos
            //            where a.Nome.ToLower() == nome.ToLower()
            //            select a;

            //return ProdutosComNome.ToList();

            // LAMBDA
            return contexto.Produtos
                .Where(p => p.Nome.ToLower() == nome.ToLower()).ToList();
        }

        public IList<Produto> ListarTodos() {
            return contexto.Produtos.ToList();
        }

    }
}
