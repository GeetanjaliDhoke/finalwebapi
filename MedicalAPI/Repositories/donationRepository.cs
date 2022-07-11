using MedicalAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.Repositories
{
    public interface donationRepository
    {
        Task<List<donation>> GetdonationAsync();
        Task<donation> GetDonationAsync(int did);
        Task<donation> AdddonationAsync(donation request);
    }
}
