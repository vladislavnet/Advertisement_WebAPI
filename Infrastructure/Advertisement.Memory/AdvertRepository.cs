using advertisement.models;
using Advertisement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advertisement.Memory
{
    public class AdvertRepository : IAdvertRepository
    {
        private List<Advert> adverts = new List<Advert>
        {
            new Advert 
            { 
                Id = 1, 
                Title = "Продам козу", 
                Description = "Ну хорошая же коза, не бита, не крашена!",
                CreateDateTime = DateTime.Now, 
                OwnerUserId = 1 
            },
        };

        public void Add(Advert value)
        {
            if (value == null)
                throw new ArgumentNullException("Advert is null");
            
            adverts.Add(new Advert
            {
                Id = adverts.Count + 1,
                Title = value.Title,
                Description = value.Description,
                CreateDateTime = DateTime.Now,
                OwnerUserId = value.OwnerUserId,
            });
            
        }

        public void Update(Advert value)
        {
            if (value == null)
                throw new ArgumentNullException("Advert is null");

            var updateAdvert = adverts.SingleOrDefault(a => a.Id == value.Id);

            if (value == null)
                throw new InvalidOperationException("Advert not found");

            updateAdvert.Title = value.Title;
            updateAdvert.Description = value.Description;
        }

        public void Delete(Advert value)
        {
            if (value == null)
                throw new ArgumentNullException("Advert is null");

            adverts.Remove(value);
        }

        public IEnumerable<Advert> GetAll()
        {
            return adverts;
        }

        public Advert GetById(int id)
        {
            return adverts.Single(a => a.Id == id);
        }

        public bool TryGetById(int id, out Advert advert)
        {
            advert = adverts.FirstOrDefault(a => a.Id == id);

            if (advert == null)
                return false;

            return true;
        }
    }
}
