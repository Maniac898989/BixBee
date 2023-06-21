using Bixbee.Data.Contexts;
using BixBee.Domain.Interface;
using BixBee.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixBee.Domain.Implementation
{
    public class InstitutionService : IinstitutionService
    {
        private readonly EducationAppContext _context;

        public InstitutionService(EducationAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result> GetAllInstitutions()
        {
            try
            {
                var AllInstitutions = await _context.Institutions
                .Select(x => new UniversityObject
                {
                    StateCode = x.StateCode,
                    University = x.University,
                    Type = x.Type.Type,
                    Category = x.Category.Category
                }).ToListAsync();
                if (AllInstitutions != null) { return new Result { IsSuccessful = true, Message = "Fetch Successful", ReturnedObject = AllInstitutions }; }
                else
                {
                    return new Result { IsSuccessful = false, Message = "Failed to get request" };
                }

            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }

        }

        public async Task<Result> GetAllUniversities()
        {
            try
            {
                var AllInstitutions = await _context.Institutions.Where(x => x.TypeID == (int)InstitutionType.Univesity)
                .Select(x => new UniversityObject
                {
                    StateCode = x.StateCode,
                    University = x.University,
                    Type = x.Type.Type,
                    Category = x.Category.Category
                }).ToListAsync();

                if (AllInstitutions != null) { return new Result { IsSuccessful = true, Message = "Fetch Successful", ReturnedObject = AllInstitutions }; }
                else
                {
                    return new Result { IsSuccessful = false, Message = "Failed to get request" };
                }

            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }

        }

        public async Task<Result> GetAllPolytechnics()
        {
            try
            {
                var AllInstitutions = await _context.Institutions.Where(x => x.TypeID == (int)InstitutionType.Polytechnic)
                .Select(x => new UniversityObject
                {
                    StateCode = x.StateCode,
                    University = x.University,
                    Type = x.Type.Type,
                    Category = x.Category.Category
                }).ToListAsync();

                if (AllInstitutions != null) { return new Result { IsSuccessful = true, Message = "Fetch Successful", ReturnedObject = AllInstitutions }; }
                else
                {
                    return new Result { IsSuccessful = false, Message = "Failed to get request" };
                }

            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }

        }

        public async Task<Result> GetAllFederalUniversities()
        {
            try
            {

                return await FetchAllInstitutionbyType((int)InstitutionType.Univesity, (int)InstitutionCategory.Federal_University);

            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }

        }

        public async Task<Result> GetAllStateUniversities()
        {
            try
            {
                return await FetchAllInstitutionbyType((int)InstitutionType.Univesity, (int)InstitutionCategory.State_University);

            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }

        }

        public async Task<Result> GetAllPrivateUniversities()
        {
            try
            {
                return await FetchAllInstitutionbyType((int)InstitutionType.Univesity, (int)InstitutionCategory.Private_University);

            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }

        }



        public async Task<Result> FetchAllInstitutionbyType(int Type, int Category)
        {
            try
            {
                var AllInstitutions = await _context.Institutions.Where(x => x.TypeID == Type && x.CategoryID == Category)
                .Select(x => new UniversityObject
                {
                    StateCode = x.StateCode,
                    University = x.University,
                    Type = x.Type.Type,
                    Category = x.Category.Category
                }).ToListAsync();

                if (AllInstitutions != null) { return new Result { IsSuccessful = true, Message = "Fetch Successful", ReturnedObject = AllInstitutions }; }
                else
                {
                    return new Result { IsSuccessful = false, Message = "Failed to get request" };
                }

            }
            catch (Exception ex)
            {
                return new Result { IsSuccessful = false, Message = ex.Message.ToString() };
            }
        }
    }
}
