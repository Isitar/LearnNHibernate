using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LearnNHibernate.EmployeeBenefits.Persistence.Mappings.Fluent;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Environment = NHibernate.Cfg.Environment;

namespace LearnNHibernate.EmployeeBenefits.Test.Mappings.Fluent
{
    public class InMemoryFluent
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;
        public InMemoryFluent()
        {
            var fluentConfig = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql().FormatSql())
                .Mappings(mapper =>
                {
                    mapper.FluentMappings.Add<EmployeeMappings>();
                    mapper.FluentMappings.Add<CommunityMappings>();
                    mapper.FluentMappings.Add<BenefitMappings>();
                    mapper.FluentMappings.Add<LeaveMappings>();
                    mapper.FluentMappings.Add<SkillsEnhancementAllowanceMappings>();
                    mapper.FluentMappings.Add<SeasonTicketLoanMappings>();
                    mapper.FluentMappings.Add<AddressMappings>();
                });
            var nhConfiguration = fluentConfig.BuildConfiguration();
            var sessionFactory = nhConfiguration.BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            using (var tx = session.BeginTransaction())
            {
                new SchemaExport(nhConfiguration)
                    .Execute(useStdOut: true,
                        execute: true,
                        justDrop: false,
                        connection: session.Connection,
                        exportOutput: Console.Out);
                tx.Commit();
            }
        }
        public ISession Session { get; set; }
        public void Dispose()
        {
            Session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
