
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class EmployeeStoreContext(DbContextOptions <EmployeeStoreContext> options) 
    :DbContext(options)
{

 public DbSet<EmpJob> Employees  =>Set<EmpJob>();

 public DbSet<JobType> Jobs =>Set<JobType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<JobType>().HasData(
            new{Id = 1, Name = "Software"},
            new{Id = 2, Name = "Management"},
            new{Id = 3, Name = "Business"},
            new{Id = 4, Name = "Communication"},
            new{Id = 5, Name = "Marketing"}
        );
    }
}
