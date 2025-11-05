using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashPass_Test.Models;
using HashPasswords;


namespace HashPass_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
               
                roleID = 3 ,
                firstname = "Sofya",
                surname = "Nikonorova",
                birthday = new DateTime(2007, 03, 03),
                phone = "+ 7(913) 000-23-88",
                email = "sofianikonorova41@gmail.com",
                hashpass = HashPasswords.Hash.gethashpass("8652fajdjmS!"),
                networkID = 1
            };
            if (user.roleID != 1 && user.roleID != 2)
            {
                throw new Exception("roleID должен быть равен 1 или 2");
            }
            CadrAgencyEntities db = Helper.GetContext();
            Helper helper = new Helper();
            try
            {
                helper.CreateUser(user);
                if (user.roleID == 1)
                {

                    Candidate candidate = new Candidate
                    {
                        User = user,
                        citizenship = "Russian",
                        statusID = 2,
                        livingcity = "Новосибирск",
                        educationID = 3,
                        langID = 1,
                        levelID = 4
                    };

                    helper.CreateCandidate(candidate);
                }
                else if (user.roleID == 2)
                {
                    Employer emp = new Employer
                    {
                        User = user,
                        companyname = "Газпром",
                        estdate = new DateTime(2015, 09, 08),
                        city = "Новосибирск",
                        adres = "ул. Фрунзе, 72"

                    };

                    helper.CreateEmployer(emp);

                }
                db.SaveChanges();
                Console.WriteLine("Пользователь успешно добавлен в базу данных!");
            }
            
            catch (DbEntityValidationException ex)
             {
                    foreach (var e in ex.EntityValidationErrors)
                        foreach (var ve in e.ValidationErrors)
                            Console.WriteLine($"{ve.PropertyName}: {ve.ErrorMessage}");
                    throw;
             }
             catch (DbUpdateException ex)
             {
                    Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                    throw;
             }

        }
    }
}
