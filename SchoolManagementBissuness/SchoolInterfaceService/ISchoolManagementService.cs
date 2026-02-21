using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolResitrationDtos;
using SchoolResitrationModel;

namespace SchoolManagementBissuness.SchoolInterfaceService
{
    public interface ISchoolManagementService
    {
        Task AddSchool(SchoolManagementModelDTO schoolManagementModelDTO);
        Task<List<SchoolManagementModelDTO>> GetAllData();

        Task UpdataData(int Id , SchoolManagementModelDTO schoolManagementModelDTO);
        Task DeleteData(int Id);
    }
}
