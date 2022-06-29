using MedicalAPI.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI
{
    public class labtestsContext : DbContext
    {
        public labtestsContext(DbContextOptions<labtestsContext> options): base(options)
        {
        }
        public DbSet<labtests> labtests { get; set; }

    }
}
