using System.Collections.Generic;

namespace Crud.Domain
{
    public interface IRepositorio
    {
        void Adicionar(DadosUsuario dadosUsuario);
        void Delete(DadosUsuario dadosUsuario);
        void Update(DadosUsuario dadosUsuario);

       public List<DadosUsuario> ExibirTodos();

        public DadosUsuario ExibirUsuario(int id);

    }
}
