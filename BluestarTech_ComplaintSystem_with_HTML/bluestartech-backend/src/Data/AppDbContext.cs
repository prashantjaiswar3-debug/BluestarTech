using Microsoft.EntityFrameworkCore;
using BluestarTech.Models;

namespace BluestarTech.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> opts): base(opts) {}
        public DbSet<Area> Areas => Set<Area>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Staff> Staff => Set<Staff>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Complaint> Complaints => Set<Complaint>();
        public DbSet<AssignmentLog> AssignmentLogs => Set<AssignmentLog>();
    }
}