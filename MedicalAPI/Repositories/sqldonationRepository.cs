using MedicalAPI.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.Repositories
{
    public class sqldonationRepository : donationRepository
    {
        private readonly donationContext context;

        public sqldonationRepository(donationContext context)
        {
            this.context = context;
        }

        public async Task<List<donation>> GetdonationAsync()
        {
            return await context.donation.ToListAsync();
        }

        public async Task<donation> GetDonationAsync(int did)
        {
            return await context.donation.FirstOrDefaultAsync(x => x.did == did);
        }

        public async Task<donation> AdddonationAsync(donation request)
        {
            var donation = await context.donation.AddAsync(request);
            await context.SaveChangesAsync();
            return donation.Entity;
        }

    }
}
