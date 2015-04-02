using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Repository.EF
{
    /// <summary>
    /// Handler for Unit of work task
    /// </summary>
    public class UnitOfWorkCallHandler : ICallHandler
    {
        private readonly IUnitOfWorkBase _unitOfWork;

        /// <summary>
        /// Constructor which takes IUnitOfWorkBase object as input parameter
        /// </summary>
        /// <param name="uow">IUnitOfWorkBase object</param>
        public UnitOfWorkCallHandler(IUnitOfWorkBase uow)
        {
            _unitOfWork = uow;
        }

        /// <summary>
        /// Begins Transaction and calls actual method and commits transaction.
        /// </summary>
        /// <param name="input"> Inputs to the current call to the target.</param>
        /// <param name="getNext">Delegate to execute to get the next delegate in the handler chain.</param>
        /// <returns>Return value from the target.</returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //Begin Transaction
            _unitOfWork.BeginTransaction();

            //Execute method
            IMethodReturn result = getNext()(input, getNext);

            if (result.Exception == null)
            {

                //Commit transaction
                _unitOfWork.Commit();

            }
            else
            {
                //Rollback transaction
                _unitOfWork.Rollback();
            }

            return result;
        }

        /// <summary>
        /// Order
        /// </summary>
        public int Order { get; set; }
    }
}
