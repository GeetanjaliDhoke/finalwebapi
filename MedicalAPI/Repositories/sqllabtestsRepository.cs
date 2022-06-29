using MedicalAPI.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.Repositories
{
    public class sqllabtestsRepository : labtestsRepository
    {
        private readonly labtestsContext context;
        public sqllabtestsRepository(labtestsContext context)
        {
            this.context = context;
        }

        public async Task<List<labtests>> GetLabtestsAsync()
        {
            return await context.labtests.ToListAsync();
        }

        public async Task<labtests> GetLabtestAsync(int labid)
        {
            return await context.labtests.FirstOrDefaultAsync(x => x.labid == labid);
        }

        public async Task<bool> Exists(int labid)
        {
           return await context.labtests.AnyAsync(x => x.labid == labid);
        }

        public async Task<labtests> UpdateLabtest(int labid, labtests request)
        {
            var ExistingLabtests = await GetLabtestAsync(labid);
            if(ExistingLabtests != null)
            {
                ExistingLabtests.name = request.name;
                ExistingLabtests.email = request.email;
                ExistingLabtests.phone = request.phone;
                ExistingLabtests.date = request.date;
                ExistingLabtests.test = request.test;

                await context.SaveChangesAsync();
                return ExistingLabtests;
            }
            return null;
        }

        public async Task<labtests> DeleteLabtest(int labid)
        {
            var labtest = await GetLabtestAsync(labid);
            if(labtest != null)
            {
                context.labtests.Remove(labtest);
                await context.SaveChangesAsync();
                return labtest;
            }
            return null;
        }

        public async Task<labtests> AddLabtest(labtests request)
        {
            var labtest = await context.labtests.AddAsync(request);
            await context.SaveChangesAsync();
            return labtest.Entity;
        }
    }
}
