using Crud.Domain;
using System;
using LinqToDB;
using System.Linq;
using LinqToDB.Common;
using CrudModel;
using System.Collections.Generic;

namespace Crud.Infra
{
   public class RepositoroDb : IRepositorio
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
          public  List<DadosUsuario> ExibirTodos()
        {

            using (var db = new CrudDB())
            {
                var query = from p in db.dadosUsuarios
                            where p.IdClientes > -1
                            orderby p.IdClientes descending
                            select p;
                return query.ToList();
            }

        }

        public DadosUsuario ExibirUsuario(int id)
        {
            DadosUsuario dadosUsuario = null;
            using (var db = new CrudDB())
            {
                dadosUsuario = new DadosUsuario();
                var query = db.dadosUsuarios
                    .Where(c => c.IdClientes == id).ToList();
                foreach (var item in query.ToList())
                {
                    dadosUsuario.IdClientes = item.IdClientes;
                    dadosUsuario.NomeClientes = item.NomeClientes;
                    dadosUsuario.IdadeClientes = item.IdadeClientes.ToString();

                }
                return dadosUsuario;
            }
        }
        public void Update(DadosUsuario dadosUsuario)
            {
                using (var db = new CrudDB())
                {
                db.dadosUsuarios
                .Where(p => p.IdClientes == dadosUsuario.IdClientes)
                .Set(p => p.NomeClientes, dadosUsuario.NomeClientes)
                .Set(p => p.IdadeClientes, dadosUsuario.IdadeClientes)
                .Update();
            }
            }

       
    } 
}
