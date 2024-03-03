using Academy_2024.Data;
using Academy_2024.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2024.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<User> GetAll() { return _context.Users.ToList(); }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);

            /*
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
            */
        }

        public void Create(User data)
        {
            _context.Users.Add(data);
            _context.SaveChanges();
        }

        public User? Update(int id, User data)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                //user.Age = data.Age;

                _context.SaveChanges();
                return user;
            }

            
            return null;
        }
        public bool Delete(int id)
        {

            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                return true;
            }
    
            return false;
        }
        
    }
}
