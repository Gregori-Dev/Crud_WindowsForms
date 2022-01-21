using Crud.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Crud.Infra
{
    public class RepositorioLista : IRepositorio
    {
        public void Adicionar(DadosUsuario dadosUsuario)
        {
            var aumentarUm = 1;
            listUsuarios.Instance.ListagemCliente.Add(dadosUsuario);
            var maior = listUsuarios.Instance.ListagemCliente.Max(x => x.IdClientes);
            dadosUsuario.IdClientes = maior + aumentarUm;
            
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

          public List<DadosUsuario> ExibirTodos()
        {
            return listUsuarios.Instance.ListagemCliente;
        }

        public DadosUsuario ExibirUsuario(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DadosUsuario dadosUsuario)
        {
            for (int i = 0; i < listUsuarios.Instance.ListagemCliente.Count; i++)
            {
                if (dadosUsuario.IdClientes == listUsuarios.Instance.ListagemCliente[i].IdClientes)
                {
                    listUsuarios.Instance.ListagemCliente[i].IdadeClientes = dadosUsuario.IdadeClientes;
                    listUsuarios.Instance.ListagemCliente[i].NomeClientes = dadosUsuario.NomeClientes;
                    listUsuarios.Instance.ListagemCliente[i].IdClientes = dadosUsuario.IdClientes;
                }
            }         
        }
    }
}
