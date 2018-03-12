using System;
using System.Collections.Generic;
using LearnNHibernate.EmployeeBenefits.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnNHibernate.EmployeeBenefits.Test
{
    [TestClass]
    public class EmployeeTests
    {
        
            [TestMethod]
            public void EmployeeIsEntitledToPaidLeaves()
            {
                //Arrange
                var employee = new Employee();
                //Act
                employee.Leaves = new List<Leave>();
                employee.Leaves.Add(new Leave
                {
                    Type = LeaveType.Paid,
                    AvailableEntitlement = 15
                });
                //Assert
                var paidLeave = employee.Leaves.FirstOrDefault(l => l.Type
                                                                    == LeaveType.Paid);
                Assert.That(paidLeave, Is.Not.Null);
                Assert.That(paidLeave.AvailableEntitlement, Is.EqualTo(15));
            }
    }
}
