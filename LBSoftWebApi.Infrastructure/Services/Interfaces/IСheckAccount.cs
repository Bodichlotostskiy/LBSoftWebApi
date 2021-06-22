using LBSoftWebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LBSoftWebApi.Infrastructure.Services.Interfaces
{
    public interface IСheckAccount
    {
        Task<bool> PushCheckAccountAsync(int AccountNumber);
    }
}
