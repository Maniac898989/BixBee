using Bixbee.Data.Models;
using BixBee.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixBee.Domain.Interface
{
    public interface IinstitutionService
    {
        Task<Result> GetAllInstitutions();
        Task<Result> GetAllUniversities();
        Task<Result> GetAllPolytechnics();
        Task<Result> GetAllFederalUniversities();
        Task<Result> GetAllStateUniversities();
        Task<Result> GetAllPrivateUniversities();
    }
}
