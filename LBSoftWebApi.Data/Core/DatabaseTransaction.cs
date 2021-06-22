using LBSoftWebApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBSoftWebApi.Data.Core
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private ApplicationDbContext context;

        public DatabaseTransaction(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Begin()
        {
            context.Database.BeginTransaction();
        }
    }
}
