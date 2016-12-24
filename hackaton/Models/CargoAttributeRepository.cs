using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackaton.Models
{
    public class CargoAttributeRepository
    {
         private ShipmentsContainer cont;

        public CargoAttributeRepository(ShipmentsContainer _cont)
        {
            cont = _cont;
        }
        public IEnumerable<CargoAttribute> CaroAttributes(int _CargoId)
        {
            return cont.CargoAttributeSet.Where(c =>_CargoId== c.Cargo.Id);
        }
        public CargoAttribute GetCargoAttribute(int _id)
        {
            return cont.CargoAttributeSet.Find(_id);
        }

        public void Add(string _Attribute, string _Value)
        {
            CargoAttribute c = new CargoAttribute();
            c.Attribute = _Attribute;
            c.Value = _Value;
            cont.CargoAttributeSet.Add(c);
            cont.SaveChanges();
        }

        public void Edit(int _id, string _Attribute, string _Value)
        {
            CargoAttribute c = new CargoAttribute();
            c.Attribute = _Attribute;
            c.Value = _Value;
            cont.SaveChanges();

        }

        public void Delete(int _id)
        {
            CargoAttribute c = cont.CargoAttributeSet.Find(_id);
            cont.CargoAttributeSet.Remove(c);
            cont.SaveChanges();
        }
    }
}