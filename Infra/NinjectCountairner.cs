using Crud.Domain;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Infra
{
    public class FormModule : NinjectModule
    {
        public override void Load()
        {
        Bind<IRepositorio>().To<Repositorio>();
     
        }

        public static FormModule Create()
        {
            return new FormModule();
        }
    }
    public class FormResolve
        {
            private static IKernel _ninjectKernel;

            public static void Wire(INinjectModule module)
            {
                _ninjectKernel = new StandardKernel(module);
            }

            public static IRepositorio Resolve<IRepositorio>()
            {
                return _ninjectKernel.Get<IRepositorio>();
            }

        public static T Resolve<T>(string nomeCliente, string idadeCliente, int idCliente)
        {
            return _ninjectKernel.Get<T>();
        }
    }
}

