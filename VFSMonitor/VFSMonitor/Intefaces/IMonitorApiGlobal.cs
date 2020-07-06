using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VFSMonitor.Models;

namespace VFSMonitor.Intefaces
{
    public interface IMonitorApiGlobal
    {
        [Get("/users/all/average")]
        Task<GlobalAverageData> GetGlobal();
    }
}
