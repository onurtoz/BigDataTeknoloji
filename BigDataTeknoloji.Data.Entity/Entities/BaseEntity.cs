using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Data.Entity.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
