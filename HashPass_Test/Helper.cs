using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashPass_Test.Models;
using HashPasswords;

namespace HashPass_Test
{
    public class Helper
    {
        private static CadrAgencyDBEntities1 _context;

        public static CadrAgencyDBEntities1 GetContext()
        {
            if(_context == null )
            {
                _context = new CadrAgencyDBEntities1();
            }
            return _context;
        }
       
        public void CreateUser(User user)
        {

            user.hashpass = Hash.gethashpass(user.hashpass);
            _context.Users.Add(user); 
            _context.SaveChanges(); 
        }

        public void UpdateUser(User user)
        { 
          
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveUser(int idUser)
        {
            var users = _context.Users.Find(idUser); 
            _context.Users.Remove(users); 
            _context.SaveChanges();
        }

        public List<User> FilterUsers()
        {
            return _context.Users.Where(x => x.roleID == 2).ToList();
        }

        public List<User> SortUsers()
        {
            return _context.Users.OrderBy(x => x.birthday).ToList();
        }

        public string GetRole(User user)
        {
            return user.Role.roletype.ToString();
        }

    }
}
