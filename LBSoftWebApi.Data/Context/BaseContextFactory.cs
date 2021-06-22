using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LBSoftWebApi.Data.Context
{
    internal abstract class BaseContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected string ConnectionStringName { get; }
        protected string MigrationsAssemblyName { get; }

        public BaseContextFactory(string connectionStringName, string migrationsAssemblyName)
        {
            ConnectionStringName = connectionStringName;
            MigrationsAssemblyName = migrationsAssemblyName;
        }

        public TContext CreateDbContext(string[] args)
        {
            return Create(@$"{Directory.GetCurrentDirectory()}\..\LBSoftWebApi\",
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                ConnectionStringName, MigrationsAssemblyName);
        }
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName, string connectionStringName, string migrationsAssemblyName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString(connectionStringName);

            if (string.IsNullOrWhiteSpace(connstr))
                throw new InvalidOperationException($"Could not find a connection string named '{connectionStringName}'.");

            else
                return CreateWithConnectionString(connectionStringName, connstr, migrationsAssemblyName);
        }

        private TContext CreateWithConnectionString(string connectionStringName, string connectionString, string migrationsAssembly)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"{nameof(connectionString)} is null or empty.", nameof(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlServer(connectionString, db => db.MigrationsAssembly(migrationsAssembly));

            DbContextOptions<TContext> options = optionsBuilder.Options;

            return CreateNewInstance(options);
        }
    }
}
