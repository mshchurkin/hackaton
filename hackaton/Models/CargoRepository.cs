using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackaton.Models
{
    public class CargoRepository
    {
        private ShipmentsContainer cont;

        public CargoRepository(ShipmentsContainer _cont)
        {
            cont = _cont;
        }
        public IEnumerable<Cargo> Cargos(int _UserId)
        {
            return cont.CargoSet.Where(c => c.User.Contains(cont.UserSet.Find(_UserId)));
        }
        public Cargo GetCargo(int _id)
        {
            return cont.CargoSet.Find(_id);
        }

        public void Add(string _Name, string _Location)
        {
            Cargo c = new Cargo();
            c.Name = _Name;
            c.Location = _Location;
            cont.CargoSet.Add(c);
            cont.SaveChanges();
        }

        public void Edit(int _id, string _Name, string _Location)
        {
            Cargo c = cont.CargoSet.Find(_id);
            c.Name = _Name;
            c.Location = _Location;
            cont.SaveChanges();

        }

        public void Delete(int _id)
        {
            Cargo c = cont.CargoSet.Find(_id);
            cont.CargoSet.Remove(c);
            cont.SaveChanges();
        }
    }
}