using MedicalAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.Repositories
{
    public interface labtestsRepository
    {
        Task<List<labtests>> GetLabtestsAsync();
        Task<labtests> GetLabtestAsync(int labid);
        Task<bool> Exists(int labid);
        Task<labtests> UpdateLabtest(int labid, labtests request);
        Task<labtests> DeleteLabtest(int labid);
        Task<labtests> AddLabtest(labtests request);
    }
}
