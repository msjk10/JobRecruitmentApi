using Common.Domain.Entities.BodyModel;
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
    public class CommonAddressRepository: ICommonAddressRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public CommonAddressRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }
        public async Task<Countries> AddCountry(CountryBodyModel countryBodyModel)
        {
            try
            {
                Countries countries = new Countries();
                var entity = await _sqlServerContext.Countries.FirstOrDefaultAsync(item => item.CountryName == countryBodyModel.CountryName && item.CountryCode== countryBodyModel.CountryName);
                if(entity==null)
                {
                    
                    countries.CountryId = countryBodyModel.CountryId;
                    countries.CountryName = countryBodyModel.CountryName; 
                    countries.CountryCode = countryBodyModel.CountryCode;
                    countries.IsActive = countryBodyModel.IsActive;
                    countries.CreatedDate = DateTime.Now;
                    countries.CreatedBy = countryBodyModel.UserId;
                    countries.UpdatedBy = 0;
                    countries.UpdatedDate= DateTime.Now;

                    await _sqlServerContext.Countries.AddAsync(countries);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    countries.CountryName ="";
                    countries.CountryCode = "";
                    countries.IsActive =false;
                    countries.CreatedDate = DateTime.Now;
                    countries.CreatedBy = 0;
                    countries.UpdatedBy = 0;
                    countries.UpdatedDate = DateTime.Now;
                }
                return countries;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Countries>> GetAllActiveCountry()
        {
            try
            {
                IQueryable<Countries> response = (from s in _sqlServerContext.Countries
                                                  where s.IsActive == true
                                                  select new Countries
                                                  {
                                                      CountryId = s.CountryId,
                                                      CountryName = s.CountryName,
                                                      CountryCode = s.CountryCode,
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
        
        public async Task<District> AddDistrict(District district)
        {
            try
            {
                var entity = await _sqlServerContext.District.FirstOrDefaultAsync(item => item.DistrictName == district.DistrictName);
                if (entity == null)
                {

                    await _sqlServerContext.District.AddAsync(district);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    district.DistrictId = 0;
                    district.DistrictName = "";
                    district.DistrictZipCode = "";
                    district.CountryId = 0;
                    district.IsActive = false;
                    district.CreatedDate = DateTime.Now;
                    district.CreatedBy = 0;
                    district.UpdatedBy = 0;
                    district.UpdatedDate = DateTime.Now;
                }
                return district;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<District>> GetAllActiveDistrict()
        {
            try
            {
                IQueryable<District> response = (from s in _sqlServerContext.District
                                                 where s.IsActive == true
                                                  select new District
                                                  {
                                                      CountryId = s.CountryId,
                                                      DistrictId = s.DistrictId,
                                                      DistrictName = s.DistrictName,
                                                      DistrictZipCode = s.DistrictZipCode,
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
        public async Task<Thana> AddThana(Thana thana)
        {
            try
            {
                var entity = await _sqlServerContext.Thana.FirstOrDefaultAsync(item => item.ThanaName == thana.ThanaName);
                if (entity == null)
                {

                    await _sqlServerContext.Thana.AddAsync(thana);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    thana.ThanaId = 0;
                    thana.ThanaName = "";
                    thana.DistrictId = 0;
                    thana.CountryId = 0;
                    thana.IsActive = false;
                    thana.CreatedDate = DateTime.Now;
                    thana.CreatedBy = 0;
                    thana.UpdatedBy = 0;
                    thana.UpdatedDate = DateTime.Now;
                }
                return thana;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Thana>> GetAllActiveThana()
        {
            try
            {
                IQueryable<Thana> response = (from s in _sqlServerContext.Thana
                                              where s.IsActive == true
                                              select new Thana
                                                 {
                                                     CountryId = s.CountryId,
                                                     DistrictId = s.DistrictId,
                                                     ThanaId = s.ThanaId,
                                                     ThanaName = s.ThanaName,
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
    }
}
