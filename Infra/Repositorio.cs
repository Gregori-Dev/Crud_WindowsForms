using Crud.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Infra
{
    public class Repositorio : IRepositorio
    {
        public void Adicionar(Usuario usuario)
        {
            listUsuarios.Instance.ListagemCliente.Add(usuario);
        }
        public void Delete(int contador)
        {
            listUsuarios.Instance.ListagemCliente.RemoveAt(contador);
        }

        public void Update(Usuario usuario, int idProcura )
        {
            for (int i = 0; i < listUsuarios.Instance.ListagemCliente.Count; i++)
            {
                if (idProcura == listUsuarios.Instance.ListagemCliente[i].IdCliente)
                {
                    listUsuarios.Instance.ListagemCliente[i].IdadeCliente = usuario.IdadeCliente;
                    listUsuarios.Instance.ListagemCliente[i].NomeCliente = usuario.NomeCliente;
                    listUsuarios.Instance.ListagemCliente[i].IdCliente = usuario.IdCliente;
                }
            }         
        }
    }
}
