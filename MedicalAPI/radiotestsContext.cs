using MedicalAPI.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI
{
    public class radiotestsContext : DbContext
    {
        public radiotestsContext(DbContextOptions<radiotestsContext> options) : base(options)
        {

        }

        public DbSet<radiotests> radiotests { get; set; }
    }
}
