using Crud.Domain;
using System;
using CrudModel;
using LinqToDB;
using System.Linq;

namespace Crud.Infra
{
    class RepositoroDb : IRepositorio
    {
        public void Adicionar(Usuario _Usuario)
        {
            using (var db = new DbNorthwind())
            {
                var statement = db.Product
                                  .Value(p => p.Name, product.Name)
                                  .Value(p => p.UnitPrice, 10.2m);

                if (storeAdded) statement.Value(p => p.Added, () => Sql.CurrentTimestamp);

                statement.Insert();
            }
        }

        public void Delete(int contador)
        {
            using (var db = new CrudDB())
            {
                db.DadosClienteDbs
                  .Where(p => p.Discontinued)
                  .Delete();
            }
        }

        public void Update(Usuario UsuarioDB, int idProcura)
        {
            

            using (var db = new CrudDB())
            {
                db.Update(UsuarioDB);
            }
        }
    }
}
