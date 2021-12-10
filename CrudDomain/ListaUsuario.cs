using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain
{
   public sealed class listUsuarios
    {
        public List<Usuario> ListagemCliente { get; set; }

        private static readonly Lazy<listUsuarios>
            lazy = new Lazy<listUsuarios>(() => new listUsuarios());

        public static listUsuarios Instance { get { return lazy.Value; } }
        public listUsuarios()
        {
            ListagemCliente = new List<Usuario>();
        }
    }
}