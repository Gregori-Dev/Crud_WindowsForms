
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain
{
    public interface IRepositorio
    {
        void Adicionar(Usuario usuario);
        void Delete(int contador);
        void Update(Usuario usuario, int idProcura);

    }
}
