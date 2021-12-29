using Crud.Domain;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;

namespace Crud.Infra
{
    public class FormModule : NinjectModule
    {
        public override void Load()
        {
        Bind <IRepositorio>().To<RepositoroDb>();
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
        public static T Resolve<T>(params IParameter[] parameters)
        {
            return _ninjectKernel.Get<T>(parameters);
        }
    }
}

