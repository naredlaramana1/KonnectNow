﻿using KonnectNow.Entity.Entities;
using KonnectNow.Repository.EF;
using KonnectNow.Repository.Repositories.Interfaces;

namespace KonnectNow.Repository.Repositories
{
   public class UserRepository : DomainRepository<User>, IUserRepository
    {

        public UserRepository(KonnectNowContext session)
            : base(session)
        {

        }
    }
}

