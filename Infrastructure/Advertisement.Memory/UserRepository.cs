using advertisement.models;
using Advertisement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advertisement.Memory
{
    public static class RolesValues
    {
        public static string ADMIN = "Admin";
        public static string USER = "User";
    }
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Admin", Password = "qwerty", Role=RolesValues.ADMIN },
            new User { Id = 2, Name = "User", Password = "12345", Role = RolesValues.USER },
        };


        public void Add(User value)
        {
            if (value == null)
                throw new ArgumentNullException("User is null");

            if (users.FirstOrDefault(u => u.Name == value.Name) != null)
                throw new InvalidOperationException("A user with the same name already exists");

            users.Add(new User
            {
                Id = users.Count + 1,
                Name = value.Name,
                Password = value.Password,
                Role = RolesValues.USER,
            });           
        }

        public void Update(User value)
        {
            if (value == null)
                throw new ArgumentNullException("User is null");

            var user = users.SingleOrDefault(u => u.Id == value.Id);

            if (user == null)
                throw new InvalidOperationException("User not found");
            
            user.Name = value.Name;
            user.Password = value.Password;
        }

        public void Delete(User value)
        {
            if (value == null)
                throw new ArgumentNullException("User is null");

            users.Remove(value);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                throw new NullReferenceException("User not Found");

            return user;
        }

        public bool TryGetById(int id, out User user)
        {
            user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return false;

            return true;
        }
    }
}
