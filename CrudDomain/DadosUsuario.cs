using System;
using System.Collections.Generic;
using System.Linq;

namespace Crud.Domain
{
    public class Usuario
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string IdadeCliente { get; set; } 
        public Usuario(string NomeList, string IdadeList)
        {
            this.NomeCliente = NomeList;
            this.IdadeCliente = IdadeList;
        }
        public Usuario() { }
    }
}

