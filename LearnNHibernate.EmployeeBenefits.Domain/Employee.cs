﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNHibernate.EmployeeBenefits.Domain
{
    public class Employee : EntityBase
    {
        public virtual string EmployeeNumber { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual DateTime DateOfJoining { get; set; }
        public virtual Address ResidentialAddress { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual string Password { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<Community> Communities { get; set; }
    }
}
