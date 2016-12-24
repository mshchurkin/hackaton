using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hackaton.Models
{
    public class DataManager
    {
        private ShipmentsContainer cont;
        public UserRepository UR;
        public CargoRepository CR;
        public CargoAttributeRepository CAR;
        public TransportRepository TR;

        public DataManager()
        {
            cont = new ShipmentsContainer();
            UR = new UserRepository(cont);
            CR = new CargoRepository(cont);
            CAR = new CargoAttributeRepository(cont);
            TR = new TransportRepository(cont);

        }
    }
}