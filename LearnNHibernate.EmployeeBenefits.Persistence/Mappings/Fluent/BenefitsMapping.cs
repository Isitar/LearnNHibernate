using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LearnNHibernate.EmployeeBenefits.Domain;

namespace LearnNHibernate.EmployeeBenefits.Persistence.Mappings.Fluent
{
    public class BenefitMappings : ClassMap<Benefit>
    {
        public BenefitMappings()
        {
            Id(b => b.Id).GeneratedBy.HiLo("1000");
            Map(b => b.Name);
            Map(b => b.Description);
            References(b => b.Employee);
        }
    }
}
