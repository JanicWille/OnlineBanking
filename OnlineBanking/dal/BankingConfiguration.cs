using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using OnlineBanking.DAL;

namespace OnlineBanking.DAL
{
    public class BankingConfiguration : DbConfiguration
    {
        public BankingConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new BankingInterceptorTransientErrors());
            DbInterception.Add(new BankingInterceptorLogging());
        }
    }
}