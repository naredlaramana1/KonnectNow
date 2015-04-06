using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;

namespace KonnectNow.Repository.Repositories
{
    public class CategoryRepository : DomainRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(KonnectNowContext session)
            : base(session)
        {

        }
    }
}

