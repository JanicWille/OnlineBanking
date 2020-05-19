using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBanking.DAL;

namespace OnlineBanking.dal
{
    public class BankingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BankingContext>
    {
        public override void InitializeDatabase(BankingContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}