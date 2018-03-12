using System;
using System.Collections.Generic;
using System.Linq;
using LearnNHibernate.EmployeeBenefits.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace LearnNHibernate.EmployeeBenefits.Test.Mappings.Xml
{
    [TestClass]
    public class EmployeeMappingsTests
    {
        private InMemoryDatabaseForXmlMappings database;
        private ISession session;

        [TestInitialize]
        public void Setup()
        {
            database = new InMemoryDatabaseForXmlMappings();
            session = database.Session;
        }

        [TestMethod]
        public void MapsPrimitiveProperties()
        {
            object id;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new Employee
                {
                    EmployeeNumber = "5987123",
                    Firstname = "Hillary",
                    Lastname = "Gamble",
                    EmailAddress = "hillary.gamble@corporate.com",
                    DateOfBirth = new DateTime(1980, 4, 23),
                    DateOfJoining = new DateTime(2010, 7, 12),
                    IsAdmin = true,
                    Password = "Password"
                });
                transaction.Commit();
            }

            session.Clear();
            using (var transaction = session.BeginTransaction())
            {
                var employee = session.Get<Employee>(id);
                Assert.AreEqual(employee.EmployeeNumber, "5987123");
                Assert.AreEqual(employee.Firstname, "Hillary");
                Assert.AreEqual(employee.Firstname, "Hillary");
                Assert.AreEqual(employee.Lastname, "Gamble");
                Assert.AreEqual(employee.EmailAddress, "hillary.gamble@corporate.com");
                Assert.AreEqual(employee.DateOfBirth.Year, 1980);
                Assert.AreEqual(employee.DateOfBirth.Month, 4);
                Assert.AreEqual(employee.DateOfBirth.Day, 23);
                Assert.AreEqual(employee.DateOfJoining.Year, 2010);
                Assert.AreEqual(employee.DateOfJoining.Month, 7);
                Assert.AreEqual(employee.DateOfJoining.Day, 12);
                Assert.IsTrue(employee.IsAdmin);
                Assert.AreEqual(employee.Password, "Password");
                transaction.Commit();
            }
        }

        [TestMethod]
        public void MapsBenefits()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new Employee
                {
                    EmployeeNumber = "123456789",
                    Benefits = new HashSet<Benefit>
                    {
                        new SkillsEnhancementAllowance
                        {
                            Entitlement = 1000,
                            RemainingEntitlement = 250
                        },
                        new SeasonTicketLoan
                        {
                            Amount = 1416,
                            MonthlyInstalment = 118,
                            StartDate = new DateTime(2014, 4, 25),
                            EndDate = new DateTime(2015, 3, 25)
                        },
                        new Leave
                        {
                            AvailableEntitlement = 30,
                            RemainingEntitlement = 15,
                            Type = LeaveType.Paid
                        }
                    }
                });
                transaction.Commit();
            }

            session.Clear();
            using (var transaction = session.BeginTransaction())
            {
                var employee = session.Get<Employee>(id);
                Assert.AreEqual(employee.Benefits.Count, 3);

                var seasonTicketLoan = employee.Benefits.OfType<SeasonTicketLoan>().FirstOrDefault();
                Assert.IsNotNull(seasonTicketLoan);
                Assert.AreEqual(seasonTicketLoan.Employee.EmployeeNumber, "123456789");

                var skillsEnhancementAllowance =
                    employee.Benefits.OfType<SkillsEnhancementAllowance>().FirstOrDefault();
                Assert.IsNotNull(skillsEnhancementAllowance);
                Assert.AreEqual(skillsEnhancementAllowance.Employee.EmployeeNumber, "123456789");

                var leave = employee.Benefits.OfType<Leave>().FirstOrDefault();
                Assert.IsNotNull(leave);
                Assert.AreEqual(leave.Employee.EmployeeNumber, "123456789");

                transaction.Commit();
            }
        }

        [TestMethod]
        public void MapsResidentialAddress()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                var residentialAddress = new Address
                {
                    AddressLine1 = "Address line 1",
                    AddressLine2 = "Address line 2",
                    Postcode = "postcode",
                    City = "city",
                    Country = "country"
                };

                var employee = new Employee
                {
                    EmployeeNumber = "123456789",
                    ResidentialAddress = residentialAddress
                };
                residentialAddress.Employee = employee;
                id = session.Save(employee);
                transaction.Commit();
            }

            
            session.Clear();
            using (var transaction = session.BeginTransaction())
            {
                var employee = session.Get<Employee>(id);
                Assert.AreEqual(employee.ResidentialAddress.AddressLine1, "Address line 1");
                Assert.AreEqual(employee.ResidentialAddress.AddressLine2, "Address line 2");
                Assert.AreEqual(employee.ResidentialAddress.Postcode, "postcode");
                Assert.AreEqual(employee.ResidentialAddress.City, "city");
                Assert.AreEqual(employee.ResidentialAddress.Country, "country");
                Assert.AreEqual(employee.ResidentialAddress.Employee.EmployeeNumber, "123456789");
                transaction.Commit();
            }
        }
    }
}
