using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using model.StdModel;

namespace BussinessLogic.RepositoryFolder.ServiceFolder
{
    public interface IStudentServicecs
    {
        Task<List<StudentDto>> ShowStudentData();
        Task InsertData(StudentDto studentDto);
        Task UpdateData(int Id,StudentDto studentDto);
        Task DeleteData(int Id);
    }
}
