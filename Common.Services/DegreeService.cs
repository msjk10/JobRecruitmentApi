using Common.Domain.Entities.DataModel;
using Common.Domain.Interfaces;
using Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class DegreeService:IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;
        public DegreeService(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }
        public async Task<Degree> AddDegree(Degree degree)
        {
            try
            {
                return await _degreeRepository.AddDegree(degree);
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
                return await _degreeRepository.GetAllActiveDegree(degreeLevelId);
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
                return await _degreeRepository.AddDegreeLevel(degreeLevel);
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
                return await _degreeRepository.GetAllActiveDegreeLevel();
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
                return await _degreeRepository.AddDegreeMapping(degreeMapping);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
