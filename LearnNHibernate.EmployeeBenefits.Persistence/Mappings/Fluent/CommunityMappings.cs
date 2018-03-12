using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LearnNHibernate.EmployeeBenefits.Domain;

namespace LearnNHibernate.EmployeeBenefits.Persistence.Mappings.Fluent
{
    public class CommunityMappings : ClassMap<Community>
    {
        public CommunityMappings()
        {
            Id(c => c.Id).GeneratedBy.HiLo("1000");
            Map(c => c.Name);
            Map(c => c.Description);
            HasManyToMany(e => e.Members)
                .Table("Employee_Community")
                .ParentKeyColumn("Community_Id")
                .ChildKeyColumn("Employee_Id")
                .Cascade.AllDeleteOrphan();
        }
    }
}
