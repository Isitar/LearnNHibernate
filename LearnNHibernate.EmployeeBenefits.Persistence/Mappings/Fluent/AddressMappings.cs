using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LearnNHibernate.EmployeeBenefits.Domain;

namespace LearnNHibernate.EmployeeBenefits.Persistence.Mappings.Fluent
{
    public class AddressMappings : ClassMap<Address>
    {
        public AddressMappings()
        {
            Id(a => a.Id).GeneratedBy.HiLo("1000");
            Map(a => a.AddressLine1);
            Map(a => a.AddressLine2);
            Map(a => a.City);
            Map(a => a.Postcode);
            Map(a => a.Country);
            References(a => a.Employee);
        }
    }
}
