using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBSoftWebApi.Data.Context
{
    internal class ApplicationContextFactory : BaseContextFactory<ApplicationDbContext>
    {
        public ApplicationContextFactory() : base("DefaultConnection", typeof(ApplicationDbContext).Assembly.GetName().Name)
        { }
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}
