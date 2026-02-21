using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolResitrationModel.SchoolDbContext
{
    public class SchoolManagementData:DbContext
    {
        public SchoolManagementData(DbContextOptions<SchoolManagementData> options):base(options)
        {
            
        }

        public DbSet<SchoolManagementModel> SchoolTAble { get; set; }       
    }
}
