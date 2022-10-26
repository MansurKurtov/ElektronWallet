using Autofac;
using System.Linq;
using System.Reflection;

namespace EWalletService
{
    /// <summary>
    /// 
    /// </summary>
    public class ServicesStart
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public static void Builder(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
