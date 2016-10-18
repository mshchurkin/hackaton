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
            IEnumerable<Cargo> result = cont.UserSet.Find(_UserId).Cargo.Select<Cargo,Cargo>(cargo => new Cargo
            {
                Name=cargo.Name,
                GeoLat=cargo.GeoLat,
                GeoLong=cargo.GeoLong,
            });
            return result;
        }
        public Cargo GetCargo(int _id)
        {
            return cont.CargoSet.Find(_id);
        }

        public void Add(string _Name, double _GeoLat, double _GeoLong)
        {
            Cargo c = new Cargo();
            c.Name = _Name;
            c.GeoLat = _GeoLat;
            c.GeoLong = _GeoLong;
            cont.CargoSet.Add(c);
            cont.SaveChanges();
        }

        public void Edit(int _id, string _Name, double _GeoLat, double _GeoLong)
        {
            Cargo c = cont.CargoSet.Find(_id);
            c.Name = _Name;
            c.GeoLat = _GeoLat;
            c.GeoLong = _GeoLong;
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