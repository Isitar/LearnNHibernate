using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LearnNHibernate.EmployeeBenefits.Domain;

namespace LearnNHibernate.EmployeeBenefits.Persistence.Mappings.Fluent
{
    public class LeaveMappings : SubclassMap<Leave>
    {
        public LeaveMappings()
        {
            DiscriminatorValue("LVE");
            Map(l => l.AvailableEntitlement);
            Map(l => l.RemainingEntitlement);
            Map(l => l.Type);
        }
    }
}
