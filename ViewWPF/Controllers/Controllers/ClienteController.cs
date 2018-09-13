using Controllers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers {
    class ClienteController {

        private Contexto contexto = new Contexto();

        public void Adicionar(Cliente entity) {
            contexto.Clientes.Add(entity);
            contexto.SaveChanges();
        }

        public void Atualizar(Cliente entity) {
            contexto.Entry(entity).State =
                System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public Cliente BuscarPorID(int id) {
            return contexto.Clientes.Find(id);
        }

        public void Excluir(int id) {
            Cliente c = BuscarPorID(id);

            if (c != null) {
                // forma 1
                contexto.Clientes.Remove(c);

                // forma 2
                //contexto.Entry(a).State = System.Data.Entity.EntityState.Deleted;

                contexto.SaveChanges();
            }
        }

        public IList<Cliente> ListarPorNome(string nome) {
            // LINQ
            //var ClientesComNome = from a in contexto.Clientes
            //            where a.Nome.ToLower() == nome.ToLower()
            //            select a;

            //return ClientesComNome.ToList();

            // LAMBDA
            return contexto.Clientes
                .Where(c => c.Nome.ToLower() == nome.ToLower()).ToList();
        }

        public IList<Cliente> ListarTodos() {
            return contexto.Clientes.ToList();
        }

    }
}
