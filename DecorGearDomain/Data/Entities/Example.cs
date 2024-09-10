using DecorGearDomain.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearDomain.Data.Entities
{
   public class Example : EntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
