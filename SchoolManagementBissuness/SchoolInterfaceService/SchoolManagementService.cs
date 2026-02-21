using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolResitrationDtos;
using SchoolResitrationModel;
using SchoolResitrationModel.SchoolDbContext;

namespace SchoolManagementBissuness.SchoolInterfaceService
{
    public class SchoolManagementService : ISchoolManagementService
    {
        private readonly SchoolManagementData _schoolManagementData;
        private readonly IMapper _mapper;

        public SchoolManagementService(SchoolManagementData schoolManagementData, IMapper mapper)
        {
            _schoolManagementData = schoolManagementData;
            _mapper = mapper;
        }

        public async Task AddSchool(SchoolManagementModelDTO schoolManagementModelDTO)
        {
            try
            {
                var map = _mapper.Map<SchoolManagementModel>(schoolManagementModelDTO);
                await _schoolManagementData.SchoolTAble.AddAsync(map);
                await _schoolManagementData.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteData(int Id)
        {
            try
            {
                var DeleteResult = await _schoolManagementData.SchoolTAble.FirstOrDefaultAsync(x => x.SchoolId == Id);
                if (DeleteResult != null)
                {
                    _schoolManagementData.Remove(DeleteResult);
                    await _schoolManagementData.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SchoolManagementModelDTO>> GetAllData()
        {
            var res = await _schoolManagementData.SchoolTAble.ToListAsync();
            if (res == null)
            {
                throw new Exception("Data is Null.");
            }
            var map = _mapper.Map<List<SchoolManagementModelDTO>>(res);
            return map;
        }

        public async Task UpdataData(int Id, SchoolManagementModelDTO schoolManagementModelDTO)
        {
            try
            {
                var updateresult = await _schoolManagementData.SchoolTAble.FirstOrDefaultAsync(x => x.SchoolId == Id);
                if (updateresult != null)
                {
                    updateresult.SchoolId = schoolManagementModelDTO.SchoolId;
                    updateresult.SchoolName = schoolManagementModelDTO.SchoolName;
                    updateresult.SchoolContect = schoolManagementModelDTO.SchoolContect;
                    updateresult.SchoolAddress = schoolManagementModelDTO.SchoolAddress;

                    await _schoolManagementData.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
