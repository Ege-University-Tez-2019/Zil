using System.Data.Entity; 
using Licence.Entity.Concrete;

namespace Licence.Dal.DBContext
{
    public class DatabaseContext : DbContext
    {
        public static readonly string connectionString = ConnectionStrings.MyComputerLocal(DatabaseName:"db_Tez");
        public DatabaseContext() : base(connectionString) { }
        public DbSet<tbl_StartUserInfo> tbl_StartUserInfo { get; set; }
        public DbSet<tbl_ProfileInfo> tbl_ProfileInfo { get; set; }
        public DbSet<tbl_OpenLessons> tbl_OpenLessons { get; set; }
    }
}
