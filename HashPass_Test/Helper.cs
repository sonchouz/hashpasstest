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
        private static CadrAgencyDBEntities6 _context;

        public static CadrAgencyDBEntities6 GetContext()
        {
            if(_context == null )
            {
                _context = new CadrAgencyDBEntities6();
            }
            return _context;
        }
       
        public void CreateUser(User user)
        {
            _context.User.Add(user); 
            _context.SaveChanges();
        }
        public void CreateCandidate(Candidate candidate)
        {
            _context.Candidate.Add(candidate);
            _context.SaveChanges();
        }

        public void CreateEmployer(Employer employer)
        {
            _context.Employer.Add(employer);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        { 
          
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveUser(int idUser)
        {
            var users = _context.User.Find(idUser); 
            _context.User.Remove(users); 
            _context.SaveChanges();
        }

        public List<User> FilterUsers()
        {
            return _context.User.Where(x => x.roleID == 2).ToList();
        }

        public List<User> SortUsers()
        {
            return _context.User.OrderBy(x => x.birthday).ToList();
        }

       

    }
}
