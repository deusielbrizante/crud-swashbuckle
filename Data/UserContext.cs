using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_swashbuckle.Model;
using Microsoft.EntityFrameworkCore;

namespace crud_swashbuckle.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();

            user.HasKey(x => x.Id);
            modelBuilder.Entity<User>().ToTable("tb_user");

            user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Name).HasColumnName("name").IsRequired();
            user.Property(x => x.DateOfBirth).HasColumnName("dateOfBirth");
        }
    }
}