using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Repository.EF
{
    public sealed class UnitOfWorkBase : IUnitOfWorkBase
    {
        public DbContextTransaction _transaction;

        /// <summary>
        /// Gets NHibernate Session object.
        /// </summary>
        public KonnectNowContext Session { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="session">EF Context object</param>
        public UnitOfWorkBase(KonnectNowContext session)
        {
            Session = session;

        }

        /// <summary>
        /// Begins a new transaction
        /// </summary>
        public void BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = Session.Database.BeginTransaction(IsolationLevel.ReadCommitted);

            }

        }
        /// <summary>
        /// Commits the transaction
        /// </summary>
        public void Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Oops! We don't have an active transaction");
            }

            _transaction.Commit();
        }

        /// <summary>
        /// Rollbacks the transaction
        /// </summary>
        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

        /// <summary>
        /// Disposes the object
        /// </summary>
        public void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
        }
    }
}
