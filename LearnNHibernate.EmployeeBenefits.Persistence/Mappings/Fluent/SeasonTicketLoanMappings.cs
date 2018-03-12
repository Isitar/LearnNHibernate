using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LearnNHibernate.EmployeeBenefits.Domain;

namespace LearnNHibernate.EmployeeBenefits.Persistence.Mappings.Fluent
{
    public class SeasonTicketLoanMappings : SubclassMap<SeasonTicketLoan>
    {
        public SeasonTicketLoanMappings()
        {
            DiscriminatorValue("STL");
            Map(s => s.Amount);
            Map(s => s.MonthlyInstalment);
            Map(s => s.StartDate);
            Map(s => s.EndDate);
        }
    }
}
