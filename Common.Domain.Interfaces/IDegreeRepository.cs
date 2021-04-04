using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces
{
    public interface IDegreeRepository
    {
        Task<Degree> AddDegree(Degree degree);
        Task<IEnumerable<Degree>> GetAllActiveDegree(int degreeLevelId);
        Task<DegreeLevel> AddDegreeLevel(DegreeLevel degreeLevel);
        Task<IEnumerable<DegreeLevel>> GetAllActiveDegreeLevel();
        Task<DegreeMapping> AddDegreeMapping(DegreeMapping degreeMapping);
    }
}
