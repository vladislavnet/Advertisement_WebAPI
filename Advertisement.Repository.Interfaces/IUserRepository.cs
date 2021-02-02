using advertisement.models;
using Advertisement.Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advertisement.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetById(int id);
        bool TryGetById(int id, out User user);
    }
}
