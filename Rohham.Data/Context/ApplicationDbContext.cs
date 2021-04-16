using Microsoft.EntityFrameworkCore;
using Rohham.Entities;
using Rohham.Entities.Blogs;
using Rohham.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Article> Articles { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<Service> Services { set; get; }
        public virtual DbSet<ServiceFeature> ServiceFeatures { set; get; }
        public virtual DbSet<ServiceFile> ServiceFiles { set; get; }

    }
}
