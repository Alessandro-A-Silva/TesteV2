using Autofac;
using TesteV2.Data.Repositories;
using TesteV2.Interfaces.Repositories;
using TesteV2.Interfaces.Services;
using TesteV2.Services;

namespace TesteV2.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<UsuariosRepository>().As<IUsuariosRepository>();
            builder.RegisterType<UsuariosService>().As<IUsuariosService>(); 
            builder.RegisterType<PessoasFisicasRepository>().As<IPessoasFisicasRepository>();
            builder.RegisterType<PessoasFisicasService>().As<IPessoasFisicasService>();

            #endregion
        }
    }
}
