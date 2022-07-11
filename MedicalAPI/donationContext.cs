using MedicalAPI.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI
{
    public class donationContext : DbContext
    {
        public donationContext(DbContextOptions<donationContext> options):base(options)
        {

        }
        public DbSet<donation> donation { get; set; }
    }
}
