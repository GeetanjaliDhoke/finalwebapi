using MedicalAPI.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.Repositories
{
    public class sqlradiotestsRepository : radiotestsRepository
    {
        private readonly radiotestsContext context;

        public sqlradiotestsRepository(radiotestsContext context)
        {
            this.context = context;
        }

        public async Task<List<radiotests>> GetRadiotestsAsync()
        {
            return await context.radiotests.ToListAsync();
        }

        public async Task<radiotests> GetRadiotestAsync(int rid)
        {
            return await context.radiotests.FirstOrDefaultAsync(x => x.rid == rid);
        }

        public async Task<bool> Exists(int rid)
        {
            return await context.radiotests.AnyAsync(x => x.rid == rid);
        }

        public async Task<radiotests> Updateradiotest(int rid, radiotests request)
        {
            var Existingradiotest = await GetRadiotestAsync(rid);
            if (Existingradiotest != null)
            {
                Existingradiotest.name = request.name;
                Existingradiotest.email = request.email;
                Existingradiotest.phone = request.phone;
                Existingradiotest.date = request.date;
                Existingradiotest.timing = request.timing;
                Existingradiotest.test = request.test;

                await context.SaveChangesAsync();
                return Existingradiotest;
            }
            return null;
        }

        public async Task<radiotests> Deleteradiotest(int rid)
        {
            var radiotest = await GetRadiotestAsync(rid);

            if(radiotest != null)
            {
                context.radiotests.Remove(radiotest);
                await context.SaveChangesAsync();
                return radiotest;
            }
            return null;
        }

        public async Task<radiotests> Addradiotest(radiotests request)
        {
            var radiotest = await context.radiotests.AddAsync(request);
            await context.SaveChangesAsync();
            return radiotest.Entity;
        }
    }
}
