using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;

namespace KonnectNow.Repository.Repositories
{
    public class CountryRepository : DomainRepository<Country>, ICountryRepository
    {

        public CountryRepository(KonnectNowContext session)
            : base(session)
        {

        }
    }
}

