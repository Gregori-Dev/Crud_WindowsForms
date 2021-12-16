using Crud.Domain;
using System.Linq;

namespace Crud.Infra
{
    public class RepositorioLista : IRepositorio
    {
        public void Adicionar(DadosUsuario dadosUsuario)
        {
            listUsuarios.Instance.ListagemCliente.Add(dadosUsuario);
            var maior = listUsuarios.Instance.ListagemCliente.Max(x => x.IdClientes);
            dadosUsuario.IdClientes = maior + 1;
            
        }
        public void Delete(DadosUsuario dadosUsuario)
        {
            
            for (int i = 0; i < listUsuarios.Instance.ListagemCliente.Count; i++)
            {
                if (dadosUsuario.IdClientes == listUsuarios.Instance.ListagemCliente[i].IdClientes)
                {
                    listUsuarios.Instance.ListagemCliente.RemoveAt(i);
                }
            }

        }

        public object ExibirTodos(DadosUsuario dadosUsuario)
        {
            return listUsuarios.Instance.ListagemCliente;
        }

        public void Update(DadosUsuario dadosUsuario, int idProcura )
        {
            for (int i = 0; i < listUsuarios.Instance.ListagemCliente.Count; i++)
            {
                if (idProcura == listUsuarios.Instance.ListagemCliente[i].IdClientes)
                {
                    listUsuarios.Instance.ListagemCliente[i].IdadeClientes = dadosUsuario.IdadeClientes;
                    listUsuarios.Instance.ListagemCliente[i].NomeClientes = dadosUsuario.NomeClientes;
                    listUsuarios.Instance.ListagemCliente[i].IdClientes = dadosUsuario.IdClientes;
                }
            }         
        }
    }
}
