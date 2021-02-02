using advertisement.models;
using Advertisement.Repository.Interfaces.Common;

namespace Advertisement.Repository.Interfaces
{
    public interface IAdvertRepository : IRepositoryBase<Advert>
    {
        Advert GetById(int id);
        bool TryGetById(int id, out Advert advert);
    }
}
