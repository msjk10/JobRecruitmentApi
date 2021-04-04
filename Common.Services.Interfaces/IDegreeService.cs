using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IDegreeService
    {
        Task<Degree> AddDegree(Degree degree);
        Task<IEnumerable<Degree>> GetAllActiveDegree(int degreeLevelId);
        Task<DegreeLevel> AddDegreeLevel(DegreeLevel degreeLevel);
        Task<IEnumerable<DegreeLevel>> GetAllActiveDegreeLevel();
        Task<DegreeMapping> AddDegreeMapping(DegreeMapping degreeMapping);
    }
}
