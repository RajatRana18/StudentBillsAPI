using Microsoft.EntityFrameworkCore;
using StudentBillsAPI.Models;

namespace StudentBillsAPI.Data
{
    public class StudentBillAPIDbContext : DbContext
    {
        public StudentBillAPIDbContext(DbContextOptions Options) : base(Options) 
        {
        
        }
        public DbSet<StudentBill> StudentBills { get; set; }    
    }
}
