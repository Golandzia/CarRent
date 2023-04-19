using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.dbEntities
{
    public static class DBStorage
    {
        public static CarRentEntities1 DB_s { get; set; } = new CarRentEntities1();
    }
}
