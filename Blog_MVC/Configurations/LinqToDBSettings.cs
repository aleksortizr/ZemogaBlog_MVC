using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;


namespace Blog_API.Configurations
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;


    }

    public class LinqToDbSettingsDevelopment : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "SqlServer",
                        ProviderName = "SqlServer",
                        ConnectionString = @"Server=tcp:aortiz-dev.database.windows.net,1433;Initial Catalog=Blog;Persist Security Info=False;User ID=aortiz-admin;Password=aort.AZ20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" //Alexander office
                        //ConnectionString = @"Server=DESKTOP-94C82G3;Database=Blog;Trusted_Connection=True;" //Alexander Home
                    };
            }
        }
    }
}
