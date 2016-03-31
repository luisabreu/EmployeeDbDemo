using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace EFDemo.NH {
    public static class SessionFactoryHelper {
        public static ISessionFactory GetSessionFactory(string cnnString) {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(cnnString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Employee>())
                .BuildSessionFactory();
        }
    }
}