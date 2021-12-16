using Crud.Domain;
using System;
using CrudModel;
using LinqToDB;
using System.Linq;
using LinqToDB.Common;

namespace Crud.Infra
{
    class RepositoroDb : IRepositorio
    {


        public void Adicionar(DadosUsuario dadosUsuarios)
        {
            using (var db = new CrudDB())
            {
                db.dadosUsuarios
                .Value(p => p.NomeClientes, dadosUsuarios.NomeClientes)
                .Value(p => p.IdadeClientes, dadosUsuarios.IdadeClientes)
                .Insert();
            }
        }

        public void Delete(DadosUsuario dadosUsuario)
        {
            using (var db = new CrudDB())
            {
                var x = (from y in db.dadosUsuarios
               .Where(p => p.IdClientes == dadosUsuario.IdClientes)
                         orderby y.IdClientes descending
                         select y).FirstOrDefault();
               db.Delete(x);
            }
        }
        public object ExibirTodos(DadosUsuario dadosUsuario)
        {
             
                using (var db = new CrudDB())
                {
                    var query = from p in db.dadosUsuarios
                                where p.IdClientes > -1
                                orderby p.NomeClientes descending
                                select p;
                    return query.ToList();
                }
            
        }

            public void Update(DadosUsuario dadosUsuario, int idProcura)
            {
                using (var db = new CrudDB())
                {
                db.dadosUsuarios
                .Where(p => p.IdClientes == idProcura)
                .Set(p => p.NomeClientes, dadosUsuario.NomeClientes)
                .Set(p => p.IdadeClientes, dadosUsuario.IdadeClientes)
                .Update();
            }
            }
        

    } 
}
