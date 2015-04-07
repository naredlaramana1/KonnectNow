using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;

namespace KonnectNow.Repository.Repositories
{
    public class LocationRepository : DomainRepository<Location>, ILocationRepository
    {

        public LocationRepository(KonnectNowContext session)
            : base(session)
        {

        }
    }
}

