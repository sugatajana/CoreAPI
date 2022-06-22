using CoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Data
{
    public class APIDBContext : DbContext
    {
        public APIDBContext() { }
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) { }
        public DbSet<CustomerMaster> customers { get; set; }
        public DbSet<CustomerProfile> customerProfiles { get; set; }
    }
}
