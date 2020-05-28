using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.AccessControl;
using OnlineBanking.DAL;
using OnlineBanking.Models;

namespace OnlineBanking.dal
{
    public class BankingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BankingContext>
    {
        protected override void Seed(BankingContext context)
        {
            base.Seed(context);
        }
    }
}