using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUD.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
}
