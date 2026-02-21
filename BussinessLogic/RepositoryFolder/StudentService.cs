using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BussinessLogic.RepositoryFolder.ServiceFolder;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using model.DbContextFolder;
using model.StdModel;

namespace BussinessLogic.RepositoryFolder
{
    public class StudentService:IStudentServicecs
    {
        private readonly StudentDbContext _studentDbContext;
        private readonly IMapper _mapper;

        public StudentService(StudentDbContext  studentDbContext, IMapper mapper)
        {
            _studentDbContext = studentDbContext;
            _mapper = mapper;
        }

        public async Task DeleteData(int Id)
        {
            try
            {
                var res = await _studentDbContext.stTable.FirstOrDefaultAsync(x=> x.id == Id);
                if (res == null) 
                {
                    throw new Exception("please Give the Correct Id.");
                }
                 _studentDbContext.stTable.Remove(res);
                await _studentDbContext.SaveChangesAsync();
            }
            catch ( Exception ex)
            {
                 throw new Exception($"{ex.Message} And this is {Id} is not Found");
            }
        }

        public async Task InsertData(StudentDto studentDto)
        {
            try
            {
                if (studentDto != null)
                {
                    var map = _mapper.Map<Studentmodel>(studentDto);
                    await _studentDbContext.stTable.AddAsync(map);
                    await _studentDbContext.SaveChangesAsync();
                }
            }
            catch ( Exception ex ) 
            {
                throw new Exception( ex.Message);
            }

        }

        public async Task<List<StudentDto>> ShowStudentData()
        {
            try
            {
                var result = await _studentDbContext.stTable.ToListAsync();
                if (result == null) 
                {
                    throw new Exception("your data is null.");
                }
                var map = _mapper.Map<List<StudentDto>>(result);
                return map;
            }
            catch ( Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateData(int Id, StudentDto studentDto)
        {
            try
            {
                var Update = await _studentDbContext.stTable.FirstOrDefaultAsync(x => x.id == Id);
                if (Update != null)
                {

                    Update.id = studentDto.stid;
                    Update.name = studentDto.stname;
                    Update.age = studentDto.stage;
                    Update.address = studentDto.staddress;

                    await _studentDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
