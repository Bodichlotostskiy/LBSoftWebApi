using LBSoftWebApi.Data.Context;
using LBSoftWebApi.Infrastructure.Extensions.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBSoftWebApi.Infrastructure.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
		{
			services.AddRepositories();

			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
		{
			services
				.AddEntityFrameworkSqlServer()
				.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			return services;
		}
	}
}
