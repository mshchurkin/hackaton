using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackaton.Models
{
    public class UserRepository
    {
        private ShipmentsContainer cont;

        public UserRepository(ShipmentsContainer _cont)
        {
            cont = _cont;
        }
        public IEnumerable<User> Users()
        {
            return cont.UserSet;
        }
        public User GetUser(string _Name, string _Password)
        {
            return cont.UserSet.Where(c => (_Name == c.Name) && (_Password == c.Password)).First();
        }

        public void Add(string _Name, string _Login, string _Password, string _CompanyName, bool _isCustomer)
        {
            User u = new User();
            u.Name = _Name;
            u.Login = _Login;
            u.Password = _Password;
            u.CompanyName = _CompanyName;
            u.isCustomer = _isCustomer;
            cont.UserSet.Add(u);
            cont.SaveChanges();
        }

        public void Edit(int _id, string _Name, string _Login, string _Password, string _CompanyName, bool _isCustomer)
        {
            User u = cont.UserSet.Find(_id);
            u.Name = _Name;
            u.Login = _Login;
            u.Password = _Password;
            u.CompanyName = _CompanyName;
            u.isCustomer = _isCustomer;
            cont.SaveChanges();

        }

        public void Delete(int _id)
        {
            User u = cont.UserSet.Find(_id);
            cont.UserSet.Remove(u);
            cont.SaveChanges();
        }
    }
}