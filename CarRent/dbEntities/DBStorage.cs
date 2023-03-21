using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.dbEntities
{
    public static class DbStorage
    {
        public static CarRentDbEntities DB_s { get; set; } = new CarRentDbEntities();
    }
}
