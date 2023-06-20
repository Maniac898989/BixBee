﻿using Bixbee.Data.Contexts;
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
    public class GenericService : IgenericService
    {
        private readonly EducationAppContext _context;
        public GenericService(EducationAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result> GetInstitutionTypes()
        {
            try
            {
                var institutionTypes = await _context.InstitutionTypes.Select(x => new { ID = x.ID, Type = x.Type }).ToListAsync();
                if (institutionTypes != null)
                {
                    return new Result { IsSuccessful = true, Message = "Fetch Successful", ReturnedObject = institutionTypes };
                }
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

        public async Task<Result> GetInstitutionCategory()
        {
            try
            {
                var institutionTypes = await _context.InstitutionCategories.Select(x => new {ID = x.Id, Category = x.Category}).ToListAsync();
                if (institutionTypes != null)
                {
                    return new Result { IsSuccessful = true, Message = "Fetch Successful", ReturnedObject = institutionTypes };
                }
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

        public async Task<Result> GetAllStates()
        {
            Result res = new Result();
            try
            {
                var States = await _context.States.ToListAsync();
                if (States != null)
                {
                    var StateObj = new List<StateObject>();
                    States.ForEach(x =>
                    {
                        var so = new StateObject();

                        so.Code = x.Code;
                        so.State = x.State1;
                        so.Capital = x.Capital;
                        so.Longtitude = x.Longtitude;
                        so.Latitude = x.Latitude;

                        StateObj.Add(so);
                    });

                    res.IsSuccessful = true;
                    res.Message = "Fetch Successful";
                    res.ReturnedObject = StateObj;
                }
                else
                {
                    res.IsSuccessful = false;
                    res.Message = "Failed to get request";
                }

            }
            catch (Exception ex)
            {
                res.Message = ex.Message.ToString(); ;
            }
            return res;
        }

        public async Task<Result> GetAllLGAs()
        {
            Result res = new Result();
            try
            {
                var LGAs = await _context.LGAs.Include(x => x.State).ToListAsync();
                if (LGAs != null)
                {
                    var Lga = new List<LgaObject>();
                    LGAs.ForEach(x =>
                    {
                        var LgaObject = new LgaObject();

                        LgaObject.State = x.State?.State1;
                        LgaObject.Town = x.Town;
                        LgaObject.StateCode = x.StateCode;

                        Lga.Add(LgaObject);
                    });

                    res.IsSuccessful = true;
                    res.Message = "Fetch Successful";
                    res.ReturnedObject = Lga;
                }
                else
                {
                    res.IsSuccessful = false;
                    res.Message = "Failed to get request";
                }

            }
            catch (Exception ex)
            {
                res.Message = ex.Message.ToString(); ;
            }
            return res;
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
                return new Result { IsSuccessful = false, Message = ex.Message.ToString()}               ;
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
