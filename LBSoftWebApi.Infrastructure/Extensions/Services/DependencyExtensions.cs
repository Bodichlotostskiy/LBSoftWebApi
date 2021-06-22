using LBSoftWebApi.Data.Core;
using LBSoftWebApi.Infrastructure.Services.Implementation;
using LBSoftWebApi.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBSoftWebApi.Infrastructure.Extensions.Services
{
	internal static class DependencyExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IDatabaseTransaction, DatabaseTransaction>();
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddScoped<ICheckPayment, PaymentService>();
			services.AddScoped<IMakingPayment, PaymentService>();
			services.AddScoped<IСheckAccount, PaymentService>();
			return services;
		}
	}
}
