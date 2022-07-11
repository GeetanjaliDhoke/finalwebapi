using MedicalAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.Repositories
{
    public interface radiotestsRepository
    {
        Task<List<radiotests>> GetRadiotestsAsync();
        Task<radiotests> GetRadiotestAsync(int rid);
        Task<bool> Exists(int rid);
        Task<radiotests> Updateradiotest(int rid, radiotests request);
        Task<radiotests> Deleteradiotest(int rid);
        Task<radiotests> Addradiotest(radiotests request);
    }
}
