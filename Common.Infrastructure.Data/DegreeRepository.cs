using Common.Domain.Entities.DataModel;
using Common.Domain.Interfaces;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Data
{
    public class DegreeRepository:IDegreeRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public DegreeRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }
        public async Task<Degree> AddDegree(Degree degree)
        {
            try
            {
                var entity = await _sqlServerContext.Degree.FirstOrDefaultAsync(item => item.DegreeName == degree.DegreeName);
                if (entity == null)
                {
                    await _sqlServerContext.Degree.AddAsync(degree);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    degree.DegreeId = 0;
                    degree.DegreeName = "";
                    degree.IsActive = false;
                    degree.CreatedDate = DateTime.Now;
                    degree.CreatedBy = 0;
                    degree.UpdatedBy = 0;
                    degree.UpdatedDate = DateTime.Now;
                }
                return degree;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Degree>> GetAllActiveDegree(int degreeLevelId)
        {
            try
            {
                IQueryable<Degree> response = (from s in _sqlServerContext.Degree
                                               join dm in _sqlServerContext.DegreeMapping on s.DegreeId equals dm.DegreeId
                                               where s.IsActive == true && dm.DegreeLevelId== degreeLevelId
                                               select new Degree
                                                  {
                                                      DegreeId = s.DegreeId,
                                                      DegreeName = s.DegreeName,
                                                      IsActive = s.IsActive,
                                                      CreatedDate = s.CreatedDate,
                                                      CreatedBy = s.CreatedBy,
                                                      UpdatedBy = s.UpdatedBy,
                                                      UpdatedDate = s.UpdatedDate
                                                  });
                return await response.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<DegreeLevel> AddDegreeLevel(DegreeLevel degreeLevel)
        {
            try
            {
                var entity = await _sqlServerContext.DegreeLevel.FirstOrDefaultAsync(item => item.DegreeLevelName == degreeLevel.DegreeLevelName);
                if (entity == null)
                {

                    await _sqlServerContext.DegreeLevel.AddAsync(degreeLevel);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    degreeLevel.DegreeLevelId = 0;
                    degreeLevel.DegreeLevelName = "";
                    degreeLevel.IsActive = false;
                    degreeLevel.CreatedDate = DateTime.Now;
                    degreeLevel.CreatedBy = 0;
                    degreeLevel.UpdatedBy = 0;
                    degreeLevel.UpdatedDate = DateTime.Now;
                }
                return degreeLevel;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<DegreeLevel>> GetAllActiveDegreeLevel()
        {
            try
            {
                IQueryable<DegreeLevel> response = (from s in _sqlServerContext.DegreeLevel
                                                    where s.IsActive == true
                                                 select new DegreeLevel
                                                 {
                                                     DegreeLevelId = s.DegreeLevelId,
                                                     DegreeLevelName = s.DegreeLevelName,
                                                     IsActive = s.IsActive,
                                                     CreatedDate = s.CreatedDate,
                                                     CreatedBy = s.CreatedBy,
                                                     UpdatedBy = s.UpdatedBy,
                                                     UpdatedDate = s.UpdatedDate
                                                 });
                return await response.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<DegreeMapping> AddDegreeMapping(DegreeMapping degreeMapping)
        {
            try
            {
                    await _sqlServerContext.DegreeMapping.AddAsync(degreeMapping);
                    await _sqlServerContext.SaveChangesAsync();
                
                return degreeMapping;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        
    }
}
