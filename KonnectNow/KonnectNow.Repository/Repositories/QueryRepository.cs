using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Repository.Repositories
{
  public  class QueryRepository : DomainRepository<Query>, IQueryRepository
    {

      public QueryRepository(KonnectNowContext session)
            : base(session)
        {

        }
    }
}
