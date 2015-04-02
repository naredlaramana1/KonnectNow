using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Repository.EF
{
    public class UnitOfWorkAttribute : HandlerAttribute
    {
        /// <summary>
        ///  When called, it creates a new call handler as specified in the attribute configuration.
        /// </summary>
        /// <param name="container">The Microsoft.Practices.Unity.IUnityContainer to use when creating handlers,if necessary.</param>
        /// <returns> A new call handler object.</returns>
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return (UnitOfWorkCallHandler)container.Resolve(typeof(UnitOfWorkCallHandler));
        }

    }
}