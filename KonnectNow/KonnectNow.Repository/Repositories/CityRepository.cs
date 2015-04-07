using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;

namespace KonnectNow.Repository.Repositories
{
    public class CityRepository : DomainRepository<City>, ICityRepository
    {

        public CityRepository(KonnectNowContext session)
            : base(session)
        {

        }
    }
}

