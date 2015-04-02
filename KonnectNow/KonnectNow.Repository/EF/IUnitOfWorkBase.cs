using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Repository.EF
{

    /// <summary>
    /// Base Unit of work interface
    /// </summary>
    public interface IUnitOfWorkBase : IDisposable
    {
        /// <summary>
        /// Begin transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits the transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks the transaction
        /// </summary>
        void Rollback();
    }
}
