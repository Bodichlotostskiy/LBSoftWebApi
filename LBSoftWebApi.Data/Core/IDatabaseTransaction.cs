using System;
using System.Collections.Generic;
using System.Text;

namespace LBSoftWebApi.Data.Core
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
