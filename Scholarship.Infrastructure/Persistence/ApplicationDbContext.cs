using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Entities.ParentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
           
        }
        

        public DbSet<Registration> Students => Set<Registration>();
        public DbSet<Biodata> Biodata => Set<Biodata>();
        public DbSet<FathersInfo> FathersInfo => Set<FathersInfo>();
        public DbSet<MothersInfo> MothersInfo => Set<MothersInfo>();
        public DbSet<NextOfKinInfo> NextOfKinInfo => Set<NextOfKinInfo>();
        public DbSet<AcademicLevel> AcademicInfo => Set<AcademicLevel>();
        public DbSet<Certificate> Certificates => Set<Certificate>();
    }
}
