//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRent.dbEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent
    {
        public int ID { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime End { get; set; }
        public int Car { get; set; }
        public int Renter { get; set; }
        public int Rent_type { get; set; }
        public int Agent { get; set; }
    
        public virtual Agent Agent1 { get; set; }
        public virtual Car Car1 { get; set; }
        public virtual Rent_type Rent_type1 { get; set; }
        public virtual Renter Renter1 { get; set; }
    }
}
