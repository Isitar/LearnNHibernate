﻿using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Environment = NHibernate.Cfg.Environment;

namespace LearnNHibernate.EmployeeBenefits.Test
{
    public class InMemoryDatabaseForXmlMappings
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;
        public InMemoryDatabaseForXmlMappings()
        {
            config = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, "datasource =:memory: ")
                .AddFile("Mappings/Xml/Employee.hbm.xml")
                .AddFile("Mappings/Xml/Address.hbm.xml")
                .AddFile("Mappings/Xml/Benefit.hbm.xml");
            sessionFactory = config.BuildSessionFactory();
            Session = sessionFactory.OpenSession();
            new SchemaExport(config).Execute(true, true, false,
                Session.Connection, Console.Out);
        }
        public ISession Session { get; set; }
        public void Dispose()
        {
            Session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
