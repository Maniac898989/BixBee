using Bixbee.Data.Models;
using BixBee.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixBee.Domain.Interface
{
    public interface IgenericService
    {
        Task<Result> GetInstitutionTypes();
        Task<Result> GetInstitutionCategory();
        Task<Result> GetAllStates();
        Task<Result> GetAllLGAs();
        Task<Result> GetAllInstitutions();
        Task<Result> GetAllUniversities();
        Task<Result> GetAllPolytechnics();
        Task<Result> GetAllFederalUniversities();
        Task<Result> GetAllStateUniversities();
        Task<Result> GetAllPrivateUniversities();

    }
}
