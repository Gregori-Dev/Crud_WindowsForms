using System;
using System.Collections.Generic;
using System.Linq;

namespace Crud.Domain
{
    public class DadosUsuario
    {
        public int IdClientes { get; set; }
        public string NomeClientes { get; set; }
        public string IdadeClientes { get; set; } 
        public DadosUsuario(string NomeList, string IdadeList)
        {
            this.NomeClientes = NomeList;
            this.IdadeClientes = IdadeList;
        }
        public DadosUsuario()
        {
        }
    }
}

