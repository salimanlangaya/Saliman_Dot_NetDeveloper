using Microsoft.EntityFrameworkCore;
using System;
namespace Saliman_Dot_NetDeveloper.Context
{
    public class StudentAppDbContext: DbContext
    {
        public StudentAppDbContext(DbContextOptions<StudentAppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
       
        public DbSet<ClassMaster> ClassMasters { get; set; }
        public DbSet<SubjectMaster> SubjectMasters { get; set; }
        public DbSet<StudentMaster> StudentMasters { get; set; }       

        public DbSet<StudentSubjectRef> StudentSubjectRefs { get; set; }
    }
}
