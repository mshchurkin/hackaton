using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackaton.Models
{
    public class TransportRepository
    {
         private ShipmentsContainer cont;

        public TransportRepository(ShipmentsContainer _cont)
        {
            cont = _cont;
        }
        public IEnumerable<Transport> Transports(int _CargoId)
        {
            return cont.TransportSet.Where(c => c.Cargo.Contains(cont.CargoSet.Find(_CargoId)));
        }
        public Transport GetTransport(int _id)
        {
            return cont.TransportSet.Find(_id);
        }

        public void Add(string _Name, string _Source, string _Target, int _Mileage)
        {
            Transport t = new Transport();
            t.Name = _Name;
            t.Source = _Source;
            t.Target = _Target;
            t.Mileage = _Mileage;
            cont.TransportSet.Add(t);
            cont.SaveChanges();
        }

        public void Edit(int _id, string _Name, string _Source, string _Target, int _Mileage)
        {
            Transport t = new Transport();
            t.Name = _Name;
            t.Source = _Source;
            t.Target = _Target;
            t.Mileage = _Mileage;
            cont.SaveChanges();

        }

        public void Delete(int _id)
        {
            Transport t = cont.TransportSet.Find(_id);
            cont.TransportSet.Remove(t);
            cont.SaveChanges();
        }
    }
}