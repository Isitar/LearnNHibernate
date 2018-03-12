using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LearnNHibernate.EmployeeBenefits.Domain;

namespace LearnNHibernate.EmployeeBenefits.Persistence.Mappings.Fluent
{
    public class SkillsEnhancementAllowanceMappings : SubclassMap<SkillsEnhancementAllowance>
    {
        public SkillsEnhancementAllowanceMappings()
        {
            DiscriminatorValue("SEA");
            Map(s => s.Entitlement);
            Map(s => s.RemainingEntitlement);
        }
    }
}
